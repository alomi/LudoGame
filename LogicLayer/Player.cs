namespace Ludo.LogicLayer
{
    public class Player : GameObject
    {
        private string name;
        private int color;
        Validator ruleBook;

        public Player(string name, int color, Validator ruleBook)
        {
            this.name = name;
            this.color = color;
            this.ruleBook = ruleBook;
        }

        public string GetName()
        {
            return name;
        }

        public int GetColor()
        {
            return color;
        }

        public int DoMove(int piece, int nextPos, Board board)
        {
            
            return board.Move(color, piece, nextPos, ruleBook.Finish(color));
        }

        public int RollDice(Dice dice)
        {
            return dice.RollDice();
        }

    }
}
