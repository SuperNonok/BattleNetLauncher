using BattleNetLaucher.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BattleNetLaucher.MVVM
{
    public class OptionsCallbacks
    {
        public static void URLCallBack(object _obj)
        {
            URLOption _option = (URLOption)_obj;
            if (_option == null || string.IsNullOrEmpty(_option.URL))
                return;

            MessageBox.Show("Open Url from " + _option.Label);
            string _url = _option.URL;
            ProcessStartInfo _psi = new ProcessStartInfo(_url);
            _psi.UseShellExecute = true;
            Process.Start(_psi);
        }

        public static void WindowOpeningCallBack(object _obj)
        {
            OpenWindowOption _option = (OpenWindowOption)_obj;
            if(_option == null || _option.CustomWindow == null)
                return;

            MessageBox.Show("Open Window from " + _option.Label);
            Window _window = _option.CustomWindow;


            _window = new Window();
            _window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            _window.Show();
        }

        public static void GuidedTourCallBack(object _obj)
        {
            MessageBox.Show("Visite guidée");
        }

        public static void LeaveOrDisconnectCallBack(object _obj)
        {
            MessageBox.Show("Close MainWindow");
        }

        public static void HomeButtonCallback(object _obj)
        {
            MessageBox.Show("Home");
        }

        public static void GamesButtonCallback(object _obj)
        {
            MessageBox.Show("Games");
        }

        public static void ShopButtonCallback(object _obj)
        {
            MessageBox.Show("Shop");
        }
    }
}
