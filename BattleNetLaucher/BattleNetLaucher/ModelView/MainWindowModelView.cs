using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using BattleNetLaucher.Models;
using BattleNetLaucher.MVVM;

namespace BattleNetLaucher.ModelView
{
    public class MainWindowModelView : ModelViewBase
    {
        public List<Option> AllOptions { get; set; } = new List<Option>();
        public List<Game> AllSlideGames { get; set; } = new List<Game>();

        // Base Bar Commands
        #region Base Bar
        public RelayCommand HomeCommand => new RelayCommand(OptionsCallbacks.HomeButtonCallback);
        public RelayCommand GamesCommand => new RelayCommand(OptionsCallbacks.GamesButtonCallback);
        public RelayCommand ShopCommand => new RelayCommand(OptionsCallbacks.ShopButtonCallback);
        #endregion

        //Social Commands And Options
        #region Social

        #region Options

            public OpenWindowOption ProfilePictureOption = new OpenWindowOption("Profile Picture");

            public OpenWindowOption AddContactOption = new OpenWindowOption("Add Contact");

            public Option ShowContactInfosOption = new Option("Show Contact");
        #endregion Options

        #region Commands
        public RelayCommand ProfilePictureCommand => new RelayCommand((o) => OptionsCallbacks.WindowOpeningCallBack(ProfilePictureOption));
        public RelayCommand AddContactCommand => new RelayCommand((o) => OptionsCallbacks.WindowOpeningCallBack(AddContactOption));
        public RelayCommand ShowContactInfosCommand => new RelayCommand((o) => OptionsCallbacks.ShowContactInfosCallback(ShowContactInfosOption));
        #endregion Commands

        #endregion Social

        #region Games
        public Game SelectedGame { get; set; } = null;
        public RelayCommand PreviousCommand => new RelayCommand(PreviousGame);
        public RelayCommand NextCommand => new RelayCommand(NextGame);
        #endregion Games


        public MainWindowModelView()
        {
            InitOptions();
            InitGames();
        }

        void InitOptions()
        {
            // Premiere Categorie & Troisieme Categorie
            InitOpenWindowOptions();

            // Deuxieme Categorie 
            InitURLOptions();

            // Troisieme Categorie
            Option _guidedTour = new Option("Guided Tour"); // can add an Icon as Third parameter (default as null)
            _guidedTour.OptionCommand = new RelayCommand((o) => OptionsCallbacks.GuidedTourCallBack(_guidedTour));
            AllOptions.Add(_guidedTour);

            // Quatrieme Categorie
            Option _disconnect = new Option("Disconnection"); // can add an Icon as Third parameter (default as null)
            _disconnect.OptionCommand = new RelayCommand((o) => OptionsCallbacks.LeaveOrDisconnectCallBack(_disconnect));
            AllOptions.Add(_disconnect);
            Option _leave = new Option("Leave"); // can add an Icon as Third parameter (default as null)
            _leave.OptionCommand = new RelayCommand((o) => OptionsCallbacks.LeaveOrDisconnectCallBack(_leave));
            AllOptions.Add(_leave);

        }

        void InitOpenWindowOptions()
        {
            //TO DO CREATE WINDOWS TO SHOW AND REPLACE "null" BY THE WANTED WINDOW
            //Premiere Categorie
            OpenWindowOption _parameters = new OpenWindowOption("parameters"); // can add an Icon as Fourth parameter (default as null)
            _parameters.OptionCommand = new RelayCommand((o) => OptionsCallbacks.WindowOpeningCallBack(_parameters));
            AllOptions.Add(_parameters);


            OpenWindowOption _bNetUpdates = new OpenWindowOption("Battle.net Updates"); // can add an Icon as Fourth parameter (default as null)
            _bNetUpdates.OptionCommand = new RelayCommand((o) => OptionsCallbacks.WindowOpeningCallBack(_bNetUpdates));
            AllOptions.Add(_bNetUpdates);
            //Troisieme Categorie
            OpenWindowOption _commentary = new OpenWindowOption("Send Commentary"); // can add an Icon as Third parameter (default as null)
            _commentary.OptionCommand = new RelayCommand((o) => OptionsCallbacks.WindowOpeningCallBack(_commentary));
            AllOptions.Add(_commentary);
            OpenWindowOption _bugReport = new OpenWindowOption("Report a Bug"); // can add an Icon as Third parameter (default as null)
            _bugReport.OptionCommand = new RelayCommand((o) => OptionsCallbacks.WindowOpeningCallBack(_bugReport));
            AllOptions.Add(_bugReport);
        }

        void InitURLOptions()
        {
            URLOption _account = new URLOption("Account", null, AllURLs.GET_ACCOUNT_URL); // can add an Icon as Fourth parameter (default as null)
            _account.OptionCommand = new RelayCommand((o)=>OptionsCallbacks.URLCallBack(_account));
            AllOptions.Add(_account);

            URLOption _help = new URLOption("Help", null, AllURLs.GET_HELP_URL); // can add an Icon as Fourth parameter (default as null)
            _help.OptionCommand = new RelayCommand((o) => OptionsCallbacks.URLCallBack(_help));
            AllOptions.Add(_help);

            URLOption _forums = new URLOption("Forums", null, AllURLs.GET_FORUMS_URL); // can add an Icon as Fourth parameter (default as null)
            _forums.OptionCommand = new RelayCommand(o => OptionsCallbacks.URLCallBack(_forums));
            AllOptions.Add(_forums);

            URLOption _mobileApp = new URLOption("Mobile App", null, AllURLs.GET_MOBILE_APP_URL); // can add an Icon as Fourth parameter (default as null)
            _mobileApp.OptionCommand = new RelayCommand((o) => OptionsCallbacks.URLCallBack(_mobileApp));
            AllOptions.Add(_mobileApp);
        }

        void InitGames()
        {
            Game _callOf = new Game("CALL OF DUTY: BLACK OPS 6", null, AllURLs.GET_CALLOF_URL,
                "Découvrez un jeu d'action et d'espionnage au scénario saisissant,\n" +
                "une experience Multijoueur incomparable avec 16 nouvelles\n" +
                "cartes et le grand retour de Zombies par manches.",
                @"Ressources\Games\CallOfImage.png");

            Game _overwatch = new Game("OVERWATCH 2",null,AllURLs.GET_OVERWATCH_URL,
                "La nouvelle collaboration Overwatch 2 propose des modèles\n" +
                "exclusifs inspirés des personnages emblématiques de My Hero\n" +
                "Academia",
                @"Ressources\Games\OverwatchImage.png");

            Game _diablo = new Game("DIABLO IV",null,AllURLs.GET_DIABLOIV_URL,
                "Repoussez les forces du mal avec l'Ultimate Edition et débloquez\n" +
                "instantanément 2 familiers, la monture jaguar, 3 000 pièces de\n" +
                "platine et plus encore.",
                @"Ressources\Games\DiabloImage.png");

            Game _hearthstone = new Game("HEARTHSTONE", null, AllURLs.GET_HEARTHSTONE_URL,
                "145 cartes inédites, le nouveau système de jeu des vaisseaux et le\n" +
                "nouveau type de serviteur, les Draeneï",
                @"Ressources\Games\HearthstoneImage.png");

            AllSlideGames.Add(_callOf);
            AllSlideGames.Add(_overwatch);
            AllSlideGames.Add(_diablo);
            AllSlideGames.Add(_hearthstone);
            SelectedGame = AllSlideGames[0];
        }

        void PreviousGame(object _obj)
        {
            if (AllSlideGames.Count <= 0) return;
            if (SelectedGame == null)
            {
                SelectedGame = AllSlideGames[0];
                MessageBox.Show("Index = 0");
                return;
            }

            int _index = GetIndexByGame();
            if(_index==0)
            {
                SelectedGame = AllSlideGames[AllSlideGames.Count];
                MessageBox.Show("Index ="+ AllSlideGames.Count.ToString());
                return;
            }
            SelectedGame = AllSlideGames[_index-1];
            MessageBox.Show("Index =" + (_index - 1).ToString());
        }

        void NextGame(object _obj)
        {
            if (AllSlideGames.Count <= 0) return;
            if (SelectedGame == null)
            {
                SelectedGame = AllSlideGames[0];
                MessageBox.Show("Index = 0");
                return;
            }

            int _index = GetIndexByGame();
            if (_index == AllSlideGames.Count)
            {
                SelectedGame = AllSlideGames[0];
                MessageBox.Show("Index = 0");
                return;
            }
            SelectedGame = AllSlideGames[_index + 1];
            MessageBox.Show("Index =" + (_index + 1).ToString());

        }
        int GetIndexByGame()
        {
            if (AllSlideGames.Count <= 0) return -1;
            if (SelectedGame == null)
            {
                SelectedGame = AllSlideGames[0];
                return 0;
            }
            int _size = AllSlideGames.Count;
            for (int _i = 0; _i < _size; _i++)
            {
                if (AllSlideGames[_i]==SelectedGame)
                    return _i;
            }
            return -1;
        }
    }
}
