using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace KeyBoard2
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class KeyBoard3 : Page
    {
        public KeyBoard3()
        {
            this.InitializeComponent();
            Windows.UI.ViewManagement.InputPane.GetForCurrentView().Showing += (input, arg) =>
            {
                input.TryHide();
                MyScrollViewer.ChangeView(null, height, null, true);
            };
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            G1.Visibility = Visibility.Visible;
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            G1.Visibility = Visibility.Collapsed;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            height = G1.ActualHeight;
            G1.Visibility = Visibility.Collapsed;
        }
        double height;

        private void NewClick(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(KeyBoard4));
        }
    }
}
