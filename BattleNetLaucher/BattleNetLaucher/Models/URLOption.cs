using BattleNetLaucher.MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace BattleNetLaucher.Models
{
    public class URLOption : Option
    {
        public string URL { get; private set; }
        public URLOption(string _label= "URLOption", RelayCommand _command = null,string _url = "baseURL" ,Image _icon =null) : base(_label, _command, _icon)
        {
            URL = _url;
        }
    }
}
