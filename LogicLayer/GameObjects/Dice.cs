using System;

namespace Ludo.LogicLayer
{
    public class Dice : GameObject
    {
        private int diceValue;
        private Random rnd;

        public Dice()
        {
            rnd = new Random();
        }

        public Dice Instance()
        {
            Dice dice = new Dice();
            return dice;
        }

        public int RollDice()
        {
            diceValue = rnd.Next(1, 7);
            return 6;
        }

        public int GetDiceValue() => diceValue;
    }
}
