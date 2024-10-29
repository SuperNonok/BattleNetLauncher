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

        void InitPermanentCommands()
        {
           // HomeCommand = 
        }
    }
}
