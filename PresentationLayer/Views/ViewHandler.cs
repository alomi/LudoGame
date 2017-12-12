using System.Collections.Generic;
using System.Windows.Controls;

namespace Views
{
    public class ViewHandler
    {
        Stack<Page> views;

        public ViewHandler()
        {
            views = new Stack<Page>();
        }

        public void Add(Page page)
        {
            views.Push(page);
        }

        public Page Content()
        {
            return views.Peek();
        }
    }
}
