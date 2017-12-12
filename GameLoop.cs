using Exceptions;
using Ludo.DataLayer;
using Ludo.LogicLayer;
using Ludo.LogicLayer.GameObjects;
using Ludo.PresentationLayer;
using System;
using System.Collections.Generic;

/*
 * Kvar att göra: 
 * - ha page istället för window?
 * - objektorientera gameloopen?
 * - felhantering
 * - interfaces
 * - dependecy injection
 */

namespace Ludo
{
    public class GameLoop
    {
        private PresentationFacade presentationFacade;
        private LogicFacade logicFacade;
        private DataFacade dataFacade;

        private ObjectFactory objectFactory;
        private Validator ruleBook;

        private int playerNum, currPlayer;

        private Player[] players;

        public GameLoop(ObjectFactory objectFactory, Validator ruleBook)
        {
            presentationFacade = new PresentationFacade(new EventManager(this));
            logicFacade = new LogicFacade();
            dataFacade = new DataFacade();

            this.objectFactory = objectFactory;
            this.ruleBook = ruleBook;
        }

        public void NewGame(int playerNum, bool loadGame)
        {
            presentationFacade.NewGame();
            StartGame(playerNum, loadGame);
        }

        public void StartGame(int numberOfPlayers, bool load)
        {
            State startState = dataFacade.StartState(load, numberOfPlayers);
            try
            {
                if (startState.PieceMap == null)
                {
                    throw new CouldNotLoadGameException();
                }

                SetPlayerNum(startState);
                logicFacade.StartGame(ruleBook, startState, CreatePlayers(), CreateGameObjects(startState));
                
                presentationFacade.SetState(startState.PieceMap);

                Run();
            }
            catch (CouldNotLoadGameException)
            {
                presentationFacade.ShowErrorMessage();
            }
        }
        
        public void SetPlayerNum(State startState)
        {
            playerNum = startState.PlayerNum;
            ruleBook.SetPlayerNum(playerNum);
            dataFacade.SetPlayerNum(playerNum);
        }

        public Player[] CreatePlayers()
        {
            Player[] players = new Player[playerNum];

            for (int i = 0; i < playerNum; i++)
            {
                players[i] = new Player("Player " + (i + 1), i, ruleBook);
            }

            this.players = players;
            return players;
        }

        public GameObject[] CreateGameObjects(State startState)
        {
            GameObject[] objects = new GameObject[2];

            Dictionary<int, Piece[]> pieces = new Dictionary<int, Piece[]>();

            for (int player = 0; player < playerNum; player++)
            {
                pieces.Add(player, (Piece[])objectFactory.CreateGameObjects(new Object[] { "piece", ruleBook.GetPieceNum(), player }));
            }

            objects[0] = (Board)objectFactory.CreateGameObject(new Object[] { "board", playerNum, ruleBook.GetBoardSize(), pieces, startState.PieceMap });
            objects[1] = (Dice)objectFactory.CreateGameObject(new Object[] { "dice" });
            
            return objects;
        }


        public void Run() //while no winner (recalling Run())
        {
            //auto save before each turn
            dataFacade.SaveGame(logicFacade.GetCurrentPlayer(), logicFacade.GetPieceMap()); 
                        
            //disable all buttons
            presentationFacade.DisableButtons();

            //show start message, which player starts, switch of player is made here aswell
            currPlayer = logicFacade.GetCurrPlayer();
            presentationFacade.ShowCurrPlayer(currPlayer);

            //enable dice
            presentationFacade.EnableDice();

            //continue in DiceRoll()
        }

        public void DiceRoll()
        {
            //when player has pressed dice make diceRoll in logic
            int diceRoll = logicFacade.DiceRoll(currPlayer);
            
            //int diceRoll = players[currPlayer].RollDice(dice);

            //show diceRoll result in window
            presentationFacade.ShowDice(diceRoll);

            //disable dice
            presentationFacade.DisableDice();

            //contuinue in CheckPosMoves()
            CheckPosMoves(diceRoll);
        }

        public void CheckPosMoves(int diceRoll)
        {
            //get possible moves from logic
            List<int> moves = logicFacade.GetPosMoves(currPlayer, diceRoll);

            if (moves.Count != 0) //if there are moves
            {
                //highlight the pieces that can move and enable these buttons
                presentationFacade.ShowPosMoves(currPlayer, moves);

                //continue to MakeMove()
            }
            else //else if no moves are possible
            {
                //show message and start from the top of the loop
                presentationFacade.NoMoves();
                //check if any more players ------------> not done
                Run();
            }
        }

        public void MakeMove(int pieceIndex)
        {
            //when player has chosen piece and pressed move - make move in logic
            int move = logicFacade.Move(currPlayer, pieceIndex);

            //repaint and place the piece on the new tile in window
            presentationFacade.ShowMove(currPlayer, pieceIndex, move);

            //if winner
            if (logicFacade.HasWon(currPlayer))
            {
                //show message and show start menu
                presentationFacade.ShowWinner();
            }
            else
            {
                Run();
            }
            //else continue in loop (change player)
        }

    }
}
