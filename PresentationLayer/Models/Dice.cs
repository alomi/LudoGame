using System;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Ludo.PresentationLayer.GameObjects
{
    class Dice
    {
        private GameWindow gameWindow;
        private Button diceButton;

        public Dice(GameWindow gameWindow)
        {
            this.gameWindow = gameWindow;
            diceButton = new Button();
        }

        /*public void EnableDice()
        {
            diceButton.BorderBrush = new SolidColorBrush(Colors.Orange);
            diceButton.BorderThickness = new Thickness(5, 5, 5, 5);
            diceButton.IsHitTestVisible = true;
            gameWindow.EnableDice(diceButton);
        }*/

        public void ShowDice(int diceRoll)
        {
            string imgPath = "../../PresentationLayer/Images/Dice/Dice" + diceRoll + ".png";

            Uri uri = new Uri(imgPath, UriKind.RelativeOrAbsolute);
            gameWindow.ShowDice(new BitmapImage(uri));
        }

        /* void DisableDice()
        {
            diceButton.IsHitTestVisible = false;
            diceButton.ClearValue(Button.BorderBrushProperty);
            diceButton.ClearValue(Button.BorderThicknessProperty);
            gameWindow.DisableDice(diceButton);
        }*/
    }
}
