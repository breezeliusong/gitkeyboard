using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace KeyBoard2
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            MyFrame.Navigate(typeof(KeyBoard1));
            Windows.UI.Core.SystemNavigationManager.GetForCurrentView().BackRequested
               += App_BackRequested;
        }

        private void App_BackRequested(object sender, Windows.UI.Core.BackRequestedEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;
            if (rootFrame == null) return;
            if (rootFrame.CanGoBack && e.Handled == false)
            {
                e.Handled = true;
                rootFrame.GoBack();
            }

        }
        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {

            var appBar = sender as AppBarButton;
            string appBarLable = appBar.Label;
            switch (appBarLable)
            {

                case "back":
                    if (MyFrame == null) return;
                    if (MyFrame.CanGoBack)
                    {
                        MyFrame.GoBack();
                    }
                    break;
                case "forward":
                    if (MyFrame.CanGoForward) MyFrame.GoForward();
                    break;
            }
        }




    }
}
