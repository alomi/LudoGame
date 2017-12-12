using Ludo.PresentationLayer.GameObjects;
using Ludo.PresentationLayer.Models;
using System;
using System.Collections.Generic;

namespace Ludo.PresentationLayer
{
    public class PresentationFacade
    {
        private EventManager eventHandler;
        private GameWindow gameWindow;
        private Dice dice;
        private Board board;


        //private TestWindow window;

        public PresentationFacade(EventManager eventHandler)
        {
            this.eventHandler = eventHandler;
            //window = new TestWindow(new ViewHandler());
            new GameMenu(eventHandler);
        }

        public void NewGame()
        {
            gameWindow = new GameWindow(eventHandler, new ButtonController());
            dice = new Dice(gameWindow);
            board = new Board(gameWindow);
        }

        public void ShowErrorMessage()
        {
            gameWindow.ShowErrorMessage();
        }

        public void SetState(Dictionary<int, List<int>> pieceMap)
        {
            gameWindow.SetState(pieceMap);
        }

        public void DisableButtons()
        {
            gameWindow.DisableButtons();
        }

        public void ShowCurrPlayer(int player)
        {
            gameWindow.ShowCurrPlayer(player);
        }

        public void EnableDice()
        {
            gameWindow.EnableDice();
        }

        /*public void DiceRoll()
        {
            gameLoop.DiceRoll();
        }*/

        public void ShowDice(int diceRoll)
        {
            dice.ShowDice(diceRoll);
        }

        public void DisableDice()
        {
            gameWindow.DisableDice();
        }

        public void ShowPosMoves(int player, List<int> moves)
        {
            for (int i = 0; i < moves.Count; i++)
            {
                board.ShowPosMoves(player, moves[i]);
            }
        }

        /*public void MakeMove(int pieceIndex)
        {
            gameLoop.MakeMove(pieceIndex);
        }*/

        public void ShowMove(int player, int start, int finish)
        {
            board.ShowMove(player, start, finish);
        }

        public void NoMoves()
        {
            gameWindow.NoMoves();
        }

        public void ShowWinner()
        {
            gameWindow.ShowWinner();
        }
    }
}
