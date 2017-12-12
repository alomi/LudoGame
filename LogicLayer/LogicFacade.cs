using System.Collections.Generic;
using Ludo.DataLayer;
using Ludo.LogicLayer.GameObjects;

namespace Ludo.LogicLayer
{
    public class LogicFacade
    {
        private PlayState playState;
        
        public void StartGame(Validator ruleBook, State initState, Player[] players, GameObject[] objects)
        {
            playState = new PlayState(ruleBook, initState, players, objects);
        }

        public int GetCurrentPlayer()
        {
            return playState.GetCurrentPlayer();
        }

        public Dictionary<int, List<int>> GetPieceMap()
        {
            return playState.GetPieceMap();
        }

        public int GetCurrPlayer()
        {
            return playState.GetCurrPlayer();
        }

        public int DiceRoll(int player)
        {
            return playState.RollDice(player);
        }

        public List<int> GetPosMoves(int player, int diceRoll)
        {
            return playState.GetPosMoves(player, diceRoll);
        }

        public int Move(int player, int pieceIndex)
        {
            return playState.Move(player, pieceIndex);
        }

        public bool HasWon(int player)
        {
            return playState.HasWon(player);
        }

    }
}
