using System.Collections.Generic;
namespace Ludo.LogicLayer
{
    public class Validator
    {
        private int playerNum;
        private const int BOARDSIZE = 52, FINISHSIZE = 5, PIECENUM = 4;

        public int GetBoardSize() => BOARDSIZE;
        public int GetFinishSize() => FINISHSIZE;
        public int GetPieceNum() => PIECENUM;
        public void SetPlayerNum(int playerNum) => this.playerNum = playerNum;

        public bool InNest(int piecePosition)
        {
            return piecePosition == -1;
        }

        /*
         * Kollar om ett lag har vunnit.
         */ 
        public bool HasWon(int piecesLeft)
        {
            return piecesLeft == 0;
        }

        /* Hämtar nästa move för en viss spelares pjäs
         * Om Pjäsen är i nästet returneras -1
         * Om Pjäsen är i nästet och kan komma ut returneras spelarens start position
         * Om Pjäsen är på brädet returneras nästa position Modulu (%) brädets längd.
         */
        public int GetNextMove(int piecePos, int diceRoll, int player)
        {
            if (InNest(piecePos))
            {
                if (diceRoll == 1 || diceRoll == 6)
                {
                    return StartPosition(player); 
                }

                return -1;
            }
            else if (piecePos > FinishLine(player) -1 && piecePos < Finish(player))
            {
                return piecePos + diceRoll;
            }
            else if (piecePos <= LastTile(player) && LastTile(player) < piecePos + diceRoll)
            {
                int stepsLeft = piecePos + diceRoll - LastTile(player) - 1; // -1 to get index ending with 0
                return FinishLine(player) + stepsLeft;
            }
            return (piecePos + diceRoll) % BOARDSIZE;
        }

        public List<Dictionary<bool, int>> GetValidActions(int player, int diceRoll, List<int> pieceMap)
        {

            List<Dictionary<bool, int>> actions = new List<Dictionary<bool, int>>();

            for (int i = 0; i < pieceMap.Count; i++)
            {
                int nextMove = GetNextMove(pieceMap[i], diceRoll, player);
                bool valid = Contains(nextMove, i, pieceMap);
                Dictionary<bool, int> toAdd = new Dictionary<bool, int>
                {
                    { valid, nextMove }
                };

                actions.Add(toAdd);
            }

            return actions;
        }

        /*
         * Kontrollerar om ett element finns i listan.
         * Använder wrap around så den behöver ett startindex
         */
        private bool Contains(int newPos, int startindex, List<int> pieces)
        {
            for (int i = 0; i < pieces.Count; i++)
            {
                if (newPos == pieces[(startindex + i) % pieces.Count])
                {
                    return false;
                }
            }
            return true;
        }

        /*
         * Returnerar en spelares startposition. 
         */
        public int StartPosition(int player)
        {
            return player * (BOARDSIZE / 4);
        }

        public int LastTile(int player)
        {
            return (StartPosition(player) + BOARDSIZE - 1) % BOARDSIZE; 
        }

        public int FinishLine(int player)
        {
            return (player + 1) * 100;
        }

        public int Finish(int player)
        {
            return FinishLine(player) + FINISHSIZE;
        }
    }
}
