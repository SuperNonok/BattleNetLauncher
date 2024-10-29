using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace BattleNetLaucher.Models
{
    public class Game
    {
        public string Label { get; set; }
        public Image Image { get; set; }

        public string URL { get; set; }
        public string Description { get; set; }

        public string ImageURI { get; set; }

        public Game(string _label, Image _image, string _url, string _description, string _imageURI = "") 
        {
            Label = _label;
            Image = _image;
            URL = _url;
            Description = _description;
            ImageURI = _imageURI;
            if (Image == null)
                InitImage();
        }

        void InitImage()
        {
            Image = new Image();
            Image.Width = 200;

            // Create source
            BitmapImage _myBitmapImage = new BitmapImage();

            // BitmapImage.UriSource must be in a BeginInit/EndInit block
            _myBitmapImage.BeginInit();
            _myBitmapImage.UriSource = new Uri(ImageURI);
            _myBitmapImage.DecodePixelWidth = 200;
            _myBitmapImage.EndInit();
            Image.Source = _myBitmapImage;
        }
    }
}
