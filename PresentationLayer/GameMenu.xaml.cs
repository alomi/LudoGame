using System;
using System.Windows;
using System.Windows.Controls;

namespace Ludo.PresentationLayer
{
    /// <summary>
    /// Interaction logic for GameMenu.xaml
    /// </summary>
    public partial class GameMenu : Window
    {
        EventManager eventHandler;

        public GameMenu(EventManager eventHandler)
        {
            InitializeComponent();
            Show();
            this.eventHandler = eventHandler;
        }

        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            //button clicked on
            Button button = (Button)sender;

            int pressed = Convert.ToInt32(button.Uid);

            if (pressed <= 4 && pressed >= 1)
            {
                Hide();
                eventHandler.NewGame(pressed, false);

            }
            else if (pressed == 5)
            {
                Hide();
                eventHandler.NewGame(0, true);
            }
            else if (pressed <= 6)
            {
                Environment.Exit(1);
            }
        }
    }
}
