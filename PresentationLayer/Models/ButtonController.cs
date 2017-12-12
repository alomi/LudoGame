using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Ludo.PresentationLayer.Models
{
    public class ButtonController
    {
        public void Clickable(Button button, bool clickable)
        {
            button.IsHitTestVisible = clickable;
        }

        public void SetStyle(Button button, string style, Button buttonStyle)
        {
            switch (style)
            {
                case "clear":
                    button.ClearValue(Button.BorderBrushProperty);
                    button.ClearValue(Button.BorderThicknessProperty);
                    Clickable(button, false);
                    break;
                case "enable":
                    button.BorderBrush = new SolidColorBrush(Colors.Orange);
                    button.BorderThickness = new Thickness(5, 5, 5, 5);
                    Clickable(button, true);
                    break;
                case "clicked":
                    button.BorderBrush = new SolidColorBrush(Colors.Purple);
                    break;
                case "move":
                    button.Content = buttonStyle.Content;
                    button.Tag = buttonStyle.Tag;
                    break;
                default:
                    break;
            }
        }
    }

}
