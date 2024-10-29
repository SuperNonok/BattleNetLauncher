using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using BattleNetLaucher.Models;
using BattleNetLaucher.MVVM;

namespace BattleNetLaucher.ModelView
{
    public class MainWindowModelView : ModelViewBase
    {
        public List<Option> AllOptions { get; set; } = new List<Option>();
        public RelayCommand HomeCommand => new RelayCommand(OptionsCallbacks.HomeButtonCallback);
        public RelayCommand GamesCommand => new RelayCommand(OptionsCallbacks.GamesButtonCallback);
        public RelayCommand ShopCommand => new RelayCommand(OptionsCallbacks.ShopButtonCallback);

        public MainWindowModelView()
        {
            InitPermanentCommands();
            InitOptions();
        }

        void InitOptions()
        {
            // Premiere Categorie & Troisieme Categorie
            InitOpenWindowOptions();

            // Deuxieme Categorie 
            InitURLOptions();

            // Troisieme Categorie
            Option _guidedTour = new Option("Guided Tour",new RelayCommand(OptionsCallbacks.GuidedTourCallBack)); // can add an Icon as Third parameter (default as null)
            AllOptions.Add(_guidedTour);

            // Quatrieme Categorie
            Option _disconnect = new Option("Disconnection", new RelayCommand(OptionsCallbacks.LeaveOrDisconnectCallBack)); // can add an Icon as Third parameter (default as null)
            AllOptions.Add(_disconnect);
            Option _leave = new Option("Leave", new RelayCommand(OptionsCallbacks.LeaveOrDisconnectCallBack)); // can add an Icon as Third parameter (default as null)
            AllOptions.Add(_leave);

        }

        void InitOpenWindowOptions()
        {
            //TO DO CREATE WINDOWS TO SHOW AND REPLACE "null" BY THE WANTED WINDOW
            //Premiere Categorie
            OpenWindowOption _parameters = new OpenWindowOption("parameters", new RelayCommand(OptionsCallbacks.WindowOpeningCallBack),null); // can add an Icon as Fourth parameter (default as null)
            AllOptions.Add(_parameters);

            OpenWindowOption _bNetUpdates = new OpenWindowOption("Battle.net Updates", new RelayCommand(OptionsCallbacks.WindowOpeningCallBack),null); // can add an Icon as Fourth parameter (default as null)
            AllOptions.Add(_bNetUpdates);
            //Troisieme Categorie
            OpenWindowOption _commentary = new OpenWindowOption("Send Commentary", new RelayCommand(OptionsCallbacks.WindowOpeningCallBack), null); // can add an Icon as Third parameter (default as null)
            AllOptions.Add(_commentary);
            OpenWindowOption _bugReport = new OpenWindowOption("Report a Bug", new RelayCommand(OptionsCallbacks.WindowOpeningCallBack), null); // can add an Icon as Third parameter (default as null)
            AllOptions.Add(_bugReport);
        }

        void InitURLOptions()
        {
            URLOption _account = new URLOption("Account", null, AllURLs.GET_ACCOUNT_URL); // can add an Icon as Fourth parameter (default as null)
            _account.OptionCommand = new RelayCommand(OptionsCallbacks.URLCallBack);
            AllOptions.Add(_account);

            URLOption _help = new URLOption("Help", null, AllURLs.GET_HELP_URL); // can add an Icon as Fourth parameter (default as null)
            _help.OptionCommand = new RelayCommand(OptionsCallbacks.URLCallBack);
            AllOptions.Add(_help);

            URLOption _forums = new URLOption("Forums", null, AllURLs.GET_FORUMS_URL); // can add an Icon as Fourth parameter (default as null)
            _forums.OptionCommand = new RelayCommand(OptionsCallbacks.URLCallBack);
            AllOptions.Add(_forums);

            URLOption _mobileApp = new URLOption("Mobile App", null, AllURLs.GET_MOBILE_APP_URL); // can add an Icon as Fourth parameter (default as null)
            _mobileApp.OptionCommand = new RelayCommand(OptionsCallbacks.URLCallBack);
            AllOptions.Add(_mobileApp);
        }

        void InitPermanentCommands()
        {
           // HomeCommand = 
        }
    }
}
