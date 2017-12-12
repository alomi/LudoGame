using DataTransfer;
using System;
using System.Collections.Generic;

namespace Ludo.LogicLayer
{
    public class Board : GameObject
    {
        private BoardData data;

        public Board(BoardData data)
        {
            this.data = data;
        }
    
        public int Move(int player, int pieceIndex, int nextPos, int finishPos)
        {
            if (nextPos >= finishPos)
            {
                data.Tiles[data.GetPiecePos(player, pieceIndex)].RemovePiece();
                data.PieceMap[player].RemoveAt(pieceIndex);

                return finishPos + 1;
            }

            Piece old = data.Tiles[nextPos].MovePiece(GetPiece(player, pieceIndex));

            if (old != null)
            {
                data.PieceMap[old.GetColor()][data.PieceMap[old.GetColor()].IndexOf(nextPos)] = -1;
            }
            data.PieceMap[player][pieceIndex] = nextPos;

            return nextPos;
        }
    
        public Piece GetPiece(int player, int pieceIndex)
        {
            int piecePos = data.GetPiecePos(player, pieceIndex);

            if (piecePos == -1)
            {
                Piece piece = data.Nests[player].GetPiece();
                return piece;
            }
            else
            {
                Piece piece = data.Tiles[piecePos].RemovePiece();
                return piece;
            }
        }
        
        public BoardData GetBoardInfo()
        {
            return data;
        }

        public void SetBoardData(Dictionary<int, List<int>> pieceMap)
        {
            data.PieceMap = pieceMap;

            for (int i = 0; i < pieceMap.Count; i++)
            {
                for (int j = 0; j < pieceMap[i].Count; j++)
                {
                    data.Tiles[data.PieceMap[i][j]].AddPiece(data.Nests[i].GetPiece());
                }
            }
        }
    }
}
