﻿using System;
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
        double height;
        public MainPage()
        {
            this.InitializeComponent();
            
        }
        

        private void T2_GotFocus(object sender, RoutedEventArgs e)
        {
            InputPane.GetForCurrentView().TryHide();
            Row2.Height = new GridLength(height);
        }

        private void T2_LostFocus(object sender, RoutedEventArgs e)
        {

            Row2.Height = new GridLength(0);
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            height = G1.ActualHeight;
            Row2.Height = new GridLength(0);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(KeyBoard3));
        }

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            var appBar = sender as AppBarButton;
            string appBarLable = appBar.Label;
            switch (appBarLable)
            {
                case "back":
                    if (Frame.CanGoBack)
                    {
                        Frame.GoBack();
                    }
                    break;
                case "forward":
                    if (Frame.CanGoForward) Frame.GoForward();
                    break;
            }
        }

    }
}
