using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上有介绍

namespace KeyBoard2
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class KeyBoard4 : Page
    {
        
   private List<NameColor> NameColors = new List<NameColor>();
        public KeyBoard4()
        {
            this.InitializeComponent();
            IEnumerable<PropertyInfo> propertyInfos = typeof(Colors).GetRuntimeProperties();
            for(int i = 0; i < propertyInfos.Count(); i++)
            {
                NameColors.Add(new NameColor(propertyInfos.ElementAt(i).Name, 
                    (Color)propertyInfos.ElementAt(i).GetValue(null)));
            }
            //TODO 
            MyGridView.ItemsSource = NameColors;
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            Windows.UI.ViewManagement.InputPane.GetForCurrentView().TryHide();
            FlyoutBase.ShowAttachedFlyout((FrameworkElement)sender);
            
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {

        }

        private void TextBox_Tapped(object sender, TappedRoutedEventArgs e)
        {
        }
        List<string> selectedItems=new List<string>();

        private void MyGridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            
            string text=e.ClickedItem.ToString();
            if (text == "Backspace")
            {
               int num= selectedItems.Count;
                if (num >= 1)
                {
                selectedItems.Remove(selectedItems[num - 1]);
                //MyTextBox.Text= selectedItems.Join("",selectedItems.ToArray).ToString();
                StringBuilder builder = new StringBuilder();
                foreach (string s in selectedItems) // Loop through all strings
                {
                    builder.Append(s).Append(""); // Append string to StringBuilder
                }
                string result = builder.ToString(); // Get string from StringBuilder
                MyTextBox.Text = result;
                }
            }
            else
            {
                selectedItems.Add(e.ClickedItem.ToString());
                MyTextBox.Text+=e.ClickedItem.ToString();
            }
        }


        private void Fly_Closed(object sender, object e)
        {
            Bt.Focus(FocusState.Programmatic);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
        }
    }
    class NameColor
    {
        public NameColor(string colorName,Color colorValue)
        {
            Name = colorName;
            Color = colorValue;
        }
        public string Name { get; set; }
        public Color Color { get; set; }
        public SolidColorBrush Brush
        {
            get { return new SolidColorBrush(Color); }
        }
    }
}
