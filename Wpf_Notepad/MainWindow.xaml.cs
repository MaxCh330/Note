using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BasicWpfNotepad
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        string filePath = "";

        public MainWindow()
        {
            InitializeComponent();
        }
        //New button

        // 開啟檔案按鈕
        private void OpenBtn_Click(object sender, RoutedEventArgs e)
        {
            // 產生開啟檔案視窗 OpenFileDialog 
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

            // 顯示視窗
            Nullable<bool> result = dlg.ShowDialog();

            // 當按下開啟之後的反應 
            if (result == true)
            {
                // 取得檔案路徑 
                filePath = dlg.FileName;

                // 讀取檔案
                TextArea.Text = System.IO.File.ReadAllText(filePath);
            }
        }


        // 存檔檔案按鈕
        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            // 產生開啟檔案視窗 OpenFileDialog 
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();

            // 顯示視窗
            Nullable<bool> result = dlg.ShowDialog();

            // 當按下開啟之後的反應 
            if (result == true)
            {
                // 取得檔案路徑 
                filePath = dlg.FileName;

                // 儲存檔案
                System.IO.File.WriteAllText(filePath, TextArea.Text);
            }
        }
        //快速存檔
        private void QuickSaveBtn_Click(object sender, RoutedEventArgs e)
        {

        }
        //新開檔案
        private void NewBtn_Click(object sender, RoutedEventArgs e)
        {
            if (TextArea.Text != "")
            {
                Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();

                // 顯示視窗
                Nullable<bool> result = dlg.ShowDialog();

                // 當按下開啟之後的反應 
                if (result == true)
                {
                    // 取得檔案路徑 
                    filePath = dlg.FileName;

                    // 儲存檔案
                    System.IO.File.WriteAllText(filePath, TextArea.Text);
                }
                TextArea.Text = "";
            }
            else
            {
                TextArea.Text = "";
            }           
        }

        private void DarkmodeSwitch_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (TextArea.Background == Brushes.White)
            {
                TextArea.Foreground = Brushes.White;
                TextArea.Background = Brushes.Gray;
            } else if (TextArea.Foreground == Brushes.White)
            {
                TextArea.Foreground = Brushes.Black;
                TextArea.Background = Brushes.White;
            }
            if (DarkmodeSwitchInside.Fill == Brushes.Gray)
            {
                DarkmodeSwitchInside.Fill = Brushes.White;
            }
            else
            {
                DarkmodeSwitchInside.Fill = Brushes.Gray;
            }
            
        }

        private void frontSize12_Click(object sender, RoutedEventArgs e)
        {
            TextArea.FontSize = 12;
        }

        private void frontSize18_Click(object sender, RoutedEventArgs e)
        {
            TextArea.FontSize = 18;
        }

        private void frontSize24_Click(object sender, RoutedEventArgs e)
        {
            TextArea.FontSize = 24;
        }
    }
}
