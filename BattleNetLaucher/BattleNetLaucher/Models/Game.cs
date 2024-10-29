using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace BattleNetLaucher.Models
{
    public class Game
    {
        public string Label { get; set; }
        public Image Image { get; set; }

        public string URL { get; set; }
        public string Description { get; set; }

        public Game(string _label, Image _image, string _url, string _description) 
        {
            Label = _label;
            Image = _image;
            URL = _url;
            Description = _description;
        }
    }
}
