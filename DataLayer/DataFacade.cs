using System;
using System.Collections.Generic;

namespace Ludo.DataLayer
{
    class DataFacade
    {
        private State curState;

        public DataFacade()
        {
            curState = new State();
        }

        public void SaveGame(int playerTurn, Dictionary<int, List<int>> pieceMap)
        {
            curState.SaveGame(playerTurn, pieceMap);
        }

        public void SetPlayerNum(int playerNum)
        {
            curState.SetPlayerNum(playerNum);
        }

        public State StartState(bool load, int playerNum)
        {

            return curState.StartState(load, playerNum);
        }
    }
}
