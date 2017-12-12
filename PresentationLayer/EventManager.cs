using Exceptions;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Ludo.PresentationLayer
{
    public class EventManager
    {
        private GameLoop gameLoop;
        private string pieceChosen;

        public EventManager(GameLoop gameLoop)
        {
            this.gameLoop = gameLoop;
            pieceChosen = "";
        }

        public void NewGame(int playerNum, bool load)
        {
            gameLoop.NewGame(playerNum, load);
        }

        public void DiceRoll()
        {
            gameLoop.DiceRoll();
        }

        public string BoardClick(Button button)
        {
            if (button.Name.Contains("Nest"))
            {
                pieceChosen = "-1";
                return button.Name;
            }
            else
            {
                string name = button.Name;
                int numberIndex = name.IndexOfAny("0123456789".ToCharArray());
                pieceChosen = name.Substring(numberIndex);
            }
            return "";
        }

        public void Move(Grid Board)
        {
            try
            {
                //if no piece has been chosen nothing happens
                if (!pieceChosen.Equals(""))
                {
                    //make move
                    MakeMove(Convert.ToInt32(pieceChosen));
                    pieceChosen = "";
                }
                else
                {
                    throw new NoChosenMoveException();
                }
            }
            catch (NoChosenMoveException)
            {
                MessageBox.Show("You need to choose a piece to move before pressing Move. Try Again!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void MakeMove(int pieceIndex)
        {
            gameLoop.MakeMove(pieceIndex);
        }
    }
}
