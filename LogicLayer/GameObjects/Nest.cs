using System;
using System.Collections.Generic;
using System.Linq;
using static Ludo.LogicLayer.Util;

namespace Ludo.LogicLayer
{
    public class Nest
    {
        private int color, startTile;
        private const int MAXSIZE = 4;

        private Stack<Piece> nest;

        public Nest(int startTile, int color, Piece[] pieces)
        {
            nest = new Stack<Piece>();

            this.startTile = startTile;
            this.color = color;

            for (int i = pieces.Length - 1; i >= 0 && !IsFull(); i--)
            {
                AddPiece(pieces[i]);
            }
        }

        public void AddPiece(Piece piece)
        {
            if(!IsFull())
                nest.Push(piece);
        }

        public Piece GetPiece()
        {
            if (!IsEmpty())
            {
                return nest.Pop();
            }
            return null;
        }

        public Piece PieceInNest()
        {
            return nest.Peek();
        }

        public bool IsEmpty()
        {
            return nest.Count == 0;
        }

        public bool IsFull()
        {
            return nest.Count == MAXSIZE;
        }

        public int GetColor()
        {
            return color;
        }
        
    }
}
