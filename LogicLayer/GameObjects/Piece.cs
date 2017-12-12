using System;
namespace Ludo.LogicLayer
{
    public class Piece : GameObject
    {
        private int color, id;
        private Nest nest;
        
        public Piece(int color, int id)
        {
            this.color = color;
            this.id = id;
        }

        public void SetNest(Nest nest)
        {
            this.nest = nest;
        }
        
        public void AddToNest()
        {
            nest.AddPiece(this);
        }

        public int GetColor()
        {
            return color;
        }    

        public int GetId()
        {
            return id;
        }

    }
}
