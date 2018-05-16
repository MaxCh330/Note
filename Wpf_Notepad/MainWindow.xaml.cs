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
        //定義儲存路徑
        string filePath = "";
        //定義用作判斷是否儲存的參考值
        string savedtext = "";
        

        public MainWindow()
        {
            InitializeComponent();
        }

        // 開啟檔案按鈕Open
        private void OpenBtn_Click(object sender, RoutedEventArgs e)
        {
            if (TextArea.Text != savedtext)
            {
                if (MessageBox.Show("Do you want to Save?", "YES or NO", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    save();
                    open();
                }
                else
                {
                    open();
                }
                
            }
            else
            {
                open();
            }
            
        }

        // 存檔檔案按鈕 Save As
        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            save();
            savedtext = TextArea.Text;
        }

        // 快速存檔 Save
        private void QuickSaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (filename.Text == filePath)
            {
                System.IO.File.WriteAllText(filePath, TextArea.Text);
                savedtext = TextArea.Text;
            }
            else
            {
                save();
                savedtext = TextArea.Text;
            }
            
        }

        //新開檔案 New
        private void NewBtn_Click(object sender, RoutedEventArgs e)
        {
            if (savedtext != TextArea.Text)
            {
                if (MessageBox.Show("Do you want to Save?", "YES or NO", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    save();
                }
                else
                {
                    //設定案名為NEW 用作Save的判斷
                    filename.Text = "New";

                    //清空文字方格
                    TextArea.Text = "";

                    //設定判斷是否儲存過的參考值
                    savedtext = TextArea.Text;
                }                    
            }
            else
            {
                //設定案名為NEW 用作Save的判斷
                filename.Text = "New";

                //清空文字方格
                TextArea.Text = "";

                //設定判斷是否儲存過的參考值
                savedtext = TextArea.Text;
            }           
        }

        //黑夜模式切換
        private void DarkmodeSwitch_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            //背景與字的顏色判斷
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

        //字的大小切換
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

        //另存共用Void
        void save()
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

                ////設定判斷是否儲存過的參考值
                savedtext = TextArea.Text;

                //設定是否需要另存的判斷參考值
                filename.Text = filePath;
                
            }
        }

        //開案共用Void
        void open()
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

                //設定判斷是否儲存過的參考值
                savedtext = TextArea.Text;

                //設定是否需要另存的判斷參考值
                filename.Text = filePath;
            }
        }

        //移動視窗
        private void TitleBar_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        //關閉視窗
        private void stopButton_Click(object sender, RoutedEventArgs e)
        {
            if (savedtext != TextArea.Text)
            {
                if (MessageBox.Show("Do you want to Save?", "Save or Not", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    save();
                    this.Close();
                }
                else
                {
                    this.Close();
                }
            }
            else
            {
                this.Close();
            }
        }

        //最大化或還原
        private void maximumButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState != WindowState.Maximized)
            {
                this.WindowState = WindowState.Maximized;
            }
            else
            {
                this.WindowState = WindowState.Normal;
            }
        }
        
        //最小化
        private void minimunButton_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
    }
}
