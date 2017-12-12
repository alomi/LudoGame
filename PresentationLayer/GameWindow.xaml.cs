using Ludo.PresentationLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Ludo.PresentationLayer
{
    public partial class GameWindow : Window
    {
        private EventManager eventHandler;
        private ButtonController buttonController;
        private int player;
        private string nest;

        public GameWindow(EventManager eventHandler, ButtonController buttonController)
        {
            InitializeComponent();
            Show();
            this.eventHandler = eventHandler;
            this.buttonController = buttonController;
        }

        public void ShowErrorMessage()
        {
            MessageBox.Show("No game to load, start a new game.");
            new GameMenu(eventHandler);
            Hide();
        }

        //at new game or loaded game - set pieces on board
        public void SetState(Dictionary<int, List<int>> pieceMap)
        {
            for (int i = 0; i < pieceMap.Count; i++)
            {
                for (int j = 0; j < pieceMap[i].Count; j++)
                {
                    string name = "Button";
                    if (pieceMap[i][j] == -1)
                    {
                        name += "Nest" + (i + 1) + j;
                    }
                    else
                    {
                        name += pieceMap[i][j];
                    }

                    Button button = (Button)Board.FindName(name);
                    button.Content = new Image { Source = new BitmapImage(new Uri("Images/Pieces/Piece" + (i + 1) + ".png", UriKind.Relative)) };
                    button.Tag = i + 1;
                }
            }
        }

        //make all buttons unclickable
        public void DisableButtons()
        {

            Board.Children.OfType<Button>().ToList().ForEach(button =>
            {
                buttonController.Clickable(button, false);
                //button.IsHitTestVisible = false;
                if (!button.Name.Equals("ButtonDice"))
                { //keeps from preventing dice button from highlighting
                    buttonController.SetStyle(button, "clear", null);
                    /*button.ClearValue(Button.BorderBrushProperty);
                    button.ClearValue(Button.BorderThicknessProperty);*/
                }
            });

            //pieceChosen = "";
        }

        //show who's turn it is to play
        public void ShowCurrPlayer(int player)
        {
            this.player = player;
            MessageBox.Show("Player " + player + "'s turn!");
            PlayerTurn.Text = "Player " + player + "\nyour turn!";
        }

        //make dice clickable
        public void EnableDice()
        {
            buttonController.SetStyle(ButtonDice, "enable", null);
            /*ButtonDice.BorderBrush = button.BorderBrush;
            ButtonDice.BorderThickness = button.BorderThickness;
            ButtonDice.IsHitTestVisible = button.IsHitTestVisible;*/
        }

        //button to roll dice
        public void RollDice(object sender, RoutedEventArgs e)
        {
            eventHandler.DiceRoll();
        }

        //show dice result with the correct dice image
        public void ShowDice(BitmapImage bitmap)
        {
            DiceImage.ImageSource = bitmap;
        }

        //make dice uncklickable
        public void DisableDice()
        {
            buttonController.SetStyle(ButtonDice, "clear", null);
            /*ButtonDice.IsHitTestVisible = button.IsHitTestVisible;
            ButtonDice.BorderBrush = button.BorderBrush;
            ButtonDice.BorderThickness = button.BorderThickness;*/
        }

        //highlight all the possible moves the player has
        public void ShowPosMoves(string name)
        {
            Button button = (Button)Board.FindName(name);
            if (button.Content != null)
            {
                buttonController.SetStyle(button, "enable", null);
                /*button.BorderBrush = style.BorderBrush;
                button.BorderThickness = style.BorderThickness;
                button.IsHitTestVisible = style.IsHitTestVisible;*/
            }

            //buttonController.Clickable(ButtonMove, true);
            //ButtonMove.IsHitTestVisible = true;
        }

        //button for pressed tile/nest
        private void BoardClick(object sender, RoutedEventArgs e)
        {
            //highlight move button
            buttonController.SetStyle(ButtonMove, "enable", null);
            /*ButtonMove.BorderBrush = new SolidColorBrush(Colors.Orange);
            ButtonMove.BorderThickness = new Thickness(5, 5, 5, 5);*/

            //set chosen piece and present it to the player
            Button button = (Button)sender;
            buttonController.SetStyle(button, "clicked", null);
            //button.BorderBrush = new SolidColorBrush(Colors.Purple);

            nest = eventHandler.BoardClick(button);
        }

        //button for move action
        public void Move(object sender, RoutedEventArgs e)
        {
            eventHandler.Move(Board);
        }

        //shows the result of the move, pieces are moved
        public void ShowMove(string name, Button style)
        {
            Button button = (Button)Board.FindName(name);
            buttonController.SetStyle(button, "move", style);
            /*button.Content = style.Content;
            button.Tag = style.Tag;*/
        }

        //message showing there are no possible moves
        public void NoMoves()
        {
            MessageBox.Show("No moves possible!");
        }

        //if player has won
        public void ShowWinner()
        {
            MessageBox.Show("Player " + player + " has won!!!", "Game over");
            new GameMenu(eventHandler); //fullösning, skapar ett nytt window
            Hide();
        }

        public string GetNestName()
        {
            return nest;
        }

        public Button GetButton(string name)
        {
            return (Button)Board.FindName(name);
        }
    }
}
