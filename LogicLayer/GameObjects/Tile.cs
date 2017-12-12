using System;
namespace Ludo.LogicLayer
{
    public class Tile
    {
        private Piece piece;

        public void AddPiece(Piece piece)
        {
            this.piece = piece;
        }

        public Piece RemovePiece()
        {
            Piece tmpPiece = piece;
            piece = null;
            return tmpPiece;
        }

        public bool HasPiece()
        {
            return piece != null;
        }

        public Piece GetPiece()
        {
            if (HasPiece()) return piece;

            return null;
        }

        public Piece MovePiece(Piece toMove)
        {
            Piece old = null;

            if (HasPiece())
            {
                old = RemovePiece();
                old.AddToNest();
            }

            AddPiece(toMove);

            return old;
        }
        
        public Piece HandleCollision()
        {
            if (piece != null)
            {
                piece.AddToNest();
                Piece tmp = RemovePiece();
                return tmp;
            }
            return piece;
        }
        
    }
}
