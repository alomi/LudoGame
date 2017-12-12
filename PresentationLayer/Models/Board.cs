using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Ludo.PresentationLayer.GameObjects
{
    class Board
    {
        private GameWindow gameWindow;

        public Board(GameWindow gameWindow)
        {
            this.gameWindow = gameWindow;
        }

        public void ShowPosMoves(int player, int move)
        {
            string name = "Button";

            //if piece is in nest
            if (move == -1)
            {
                name += "Nest" + player;

                for (int i = 0; i < 4; i++)
                {
                    name += i;
                    gameWindow.ShowPosMoves(name);
                    name = "ButtonNest" + player;
                }
            }
            //if piece is on tiles
            else
            {
                name += move;
                gameWindow.ShowPosMoves(name);
            }
        }

        public void ShowMove(int player, int start, int finish)
        {
            //find start button
            string startName = "Button";
            if (start == -1)
            {
                startName = gameWindow.GetNestName();
            }
            else
            {
                startName += start;
            }

            //find finish button
            string finishName = "Button" + finish;

            //remove piece from start button
            Button startButton = gameWindow.GetButton(startName);
            startButton.Content = null;
            startButton.Tag = 0;
            gameWindow.ShowMove(startName, startButton);

            //Button finishButton = (Button)Board.FindName(finishName);
            Button finishButton = gameWindow.GetButton(finishName);

            //if there are another piece on the finishposition, push it back to it's nest
            if (finishButton != null)
            {
                string tag = finishButton.Tag.ToString();

                if (!tag.Equals("0"))
                {
                    string name = "ButtonNest";
                    switch (tag)
                    {
                        case "1":
                            for (int i = 0; i < 4; i++)
                            {
                                name += "1" + i;
                                Button nest = gameWindow.GetButton(name);
                                if (nest.Content == null)
                                {
                                    nest.Content = finishButton.Content;
                                    nest.Tag = 1;
                                    gameWindow.ShowMove(name, nest);
                                    break;
                                }
                                name = "ButtonNest";
                            }
                            break;
                        case "2":
                            for (int i = 0; i < 4; i++)
                            {
                                name += "2" + i;
                                Button nest = gameWindow.GetButton(name);
                                if (nest.Content == null)
                                {
                                    nest.Content = finishButton.Content;
                                    nest.Tag = 2;
                                    gameWindow.ShowMove(name, nest);
                                    break;
                                }
                                name = "ButtonNest";
                            }
                            break;
                        case "3":
                            for (int i = 0; i < 4; i++)
                            {
                                name += "3" + i;
                                Button nest = gameWindow.GetButton(name);
                                if (nest.Content == null)
                                {
                                    nest.Content = finishButton.Content;
                                    nest.Tag = 3;
                                    gameWindow.ShowMove(name, nest);
                                    break;
                                }
                                name = "ButtonNest";
                            }
                            break;
                        case "4":
                            for (int i = 0; i < 4; i++)
                            {
                                name += "4" + i;
                                Button nest = gameWindow.GetButton(name);
                                if (nest.Content == null)
                                {
                                    nest.Content = finishButton.Content;
                                    nest.Tag = 4;
                                    gameWindow.ShowMove(name, nest);
                                    break;
                                }
                                name = "ButtonNest";
                            }
                            break;
                    }
                }

                //set new piece on finsihButton
                finishButton.Content = new Image { Source = new BitmapImage(new Uri("Images/Pieces/Piece" + player + ".png", UriKind.Relative)) };
                finishButton.Tag = player;
                gameWindow.ShowMove(finishButton.Name, finishButton);
            }
        }
    }
}
