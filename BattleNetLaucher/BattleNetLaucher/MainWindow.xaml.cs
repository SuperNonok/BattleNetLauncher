﻿using BattleNetLaucher.ModelView;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BattleNetLaucher
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainWindowModelView _mwmv = new MainWindowModelView(this);
            DataContext = _mwmv;
        }

        private void OpenPopup(object sender, RoutedEventArgs e)
        {
            OptionsPopup.IsOpen = true;
        }
    }
}