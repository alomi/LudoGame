using System.Collections.Generic;
using Ludo.DataLayer;
using DataTransfer;

namespace Ludo.LogicLayer
{
    class PlayState
    {
        private Board board;
        private Dice dice;
        private Player[] players;

        private Validator ruleBook;

        private int currPlayer, playerNum;

        private List<Dictionary<bool, int>> actions;
        private List<int> pieces;

        public PlayState(Validator ruleBook, State startState, Player[] players, GameObject[] objects)
        {
            playerNum = startState.PlayerNum;
            currPlayer = startState.PlayerTurn;

            this.players = players;
            this.ruleBook = ruleBook;

            board = (Board)objects[0];
            dice = (Dice)objects[1];
        }

        public Dictionary<int, List<int>> GetPieceMap()
        {
            BoardData data = board.GetBoardInfo();
            return data.PieceMap;
        }

        public int RollDice(int player)
        {
            return players[player - 1].RollDice(dice);
        }

        public List<int> GetPosMoves(int player, int diceRoll)
        {
            BoardData boardData = board.GetBoardInfo();

            pieces = boardData.PlayerPieces(player - 1);

            actions = ruleBook.GetValidActions(player - 1, diceRoll, pieces);

            List<int> moves = new List<int>();
            for (int i = 0; i < actions.Count; i++)
            {
                if (actions[i].ContainsKey(true))
                {
                    moves.Add(pieces[i]);
                }
            }

            return moves;
        }

        public int Move(int player, int pieceIndex)
        {
            int piece = pieces.IndexOf(pieceIndex);
            return players[player - 1].DoMove(piece, actions[piece][true], board);

        }

        public bool HasWon(int player)
        {
            BoardData boardData = board.GetBoardInfo();
            return ruleBook.HasWon(boardData.PiecesLeft(players[player - 1].GetColor()));
        }

        public int GetCurrPlayer()
        {
            int player = currPlayer + 1;
            currPlayer = (currPlayer + 1) % (playerNum);
            return player;
        }

        public int GetCurrentPlayer()
        {
            return currPlayer;
        }
    }
}
