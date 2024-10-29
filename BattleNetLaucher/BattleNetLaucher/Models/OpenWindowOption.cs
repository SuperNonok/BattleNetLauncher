using BattleNetLaucher.MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace BattleNetLaucher.Models
{
    public class OpenWindowOption : Option
    {
        public Window CustomWindow { get; private set; }

        public OpenWindowOption(string _label = "OpenWindowOption", RelayCommand _command = null, Window _window = null, Image _icon = null) : base(_label, _command, _icon)
        {
            CustomWindow = _window;
        }
    }
}
