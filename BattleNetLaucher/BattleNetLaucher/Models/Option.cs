using BattleNetLaucher.MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace BattleNetLaucher.Models
{
    public class Option
    {
        public string Label { get; private set; } = "option";
        public RelayCommand OptionCommand { get; set; }

        public Image Icon { get; private set; } = null;

        public Option(string _label = "option", RelayCommand _command = null, Image _icon = null) 
        {
            Label = _label;
            OptionCommand = _command;
            Icon = _icon;
        }

    }
}
