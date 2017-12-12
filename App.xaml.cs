using Ludo.LogicLayer;
using Ludo.LogicLayer.GameObjects;
using System.Windows;

namespace Ludo
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            new GameLoop(new ObjectFactory(), new Validator());
        }
    }
}
