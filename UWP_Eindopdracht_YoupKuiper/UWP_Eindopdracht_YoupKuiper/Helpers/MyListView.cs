using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace UWP_Eindopdracht_YoupKuiper.Helpers
{
    public sealed class MyListView : ListView
    {
        private int _numberOfContainers;

        protected override DependencyObject GetContainerForItemOverride()
        {
            ++_numberOfContainers;
            Debug.WriteLine("Creating new container; count = " + _numberOfContainers);

            return base.GetContainerForItemOverride();
        }

        protected override void PrepareContainerForItemOverride(DependencyObject element, object item)
        {
            Debug.WriteLine("Preparing container for item " + item);
            base.PrepareContainerForItemOverride(element, item);
        }

        protected override void ClearContainerForItemOverride(DependencyObject element, object item)
        {
            Debug.WriteLine("Clearing container for item " + item);
            base.ClearContainerForItemOverride(element, item);
        }
    }
}
