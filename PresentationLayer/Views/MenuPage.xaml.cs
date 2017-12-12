using Ludo.PresentationLayer;
using System;
using System.Windows;
using System.Windows.Controls;


namespace Views
{
    /// <summary>
    /// Interaction logic for MenuPage.xaml
    /// </summary>
    public partial class MenuPage : Page
    {
        PresentationFacade presentationFacade;

        ViewHandler handler;

        public MenuPage()
        {
            InitializeComponent();
            
        }
        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            //button clicked on
            Button button = (Button)sender;

            int pressed = Convert.ToInt32(button.Uid);

            if (pressed <= 4 && pressed >= 1)
            {
                handler.Add(new GamePage());
                
            }
            /*else if (pressed == 5)
            {
                presentationFacade.LoadGame();
            }*/
            else if (pressed <= 6)
            {
                Environment.Exit(1);
            }
        }
    }
}
