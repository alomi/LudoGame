using Ludo.LogicLayer;
using System.Collections.Generic;

namespace DataTransfer
{
    public class BoardData : DataTransferObject
    {
        private int boardSize;

        private Tile[] tiles;

        private Dictionary<int, Nest> nests;
        private Dictionary<int, List<int>> pieceMap;

        public BoardData(int boardSize, Tile[] tiles, Dictionary<int,Nest> nests, Dictionary<int,List<int>> pieceMap)
        {
            this.boardSize = boardSize;
            this.tiles = tiles;
            this.nests = nests;
            this.pieceMap = pieceMap;
        }

        public Dictionary<int, List<int>> PieceMap { get => pieceMap; set => pieceMap = value; }
        public Tile[] Tiles { get => tiles; set => tiles = value; }
        public Dictionary<int, Nest> Nests { get => nests; set => nests = value; }

        public int GetPiecePos(int player, int pieceIndex)
        {
            return pieceMap[player][pieceIndex];
        }

        public List<int> PlayerPieces(int player)
        {
            return pieceMap[player];
        }

        public int PiecesLeft(int player)
        {
            return pieceMap[player].Count;
        }
    }
}
