using HH.Infastructure.Commands;
using HH.Models.Logic;
using HH.ViewModels.Base;
using HH.ViewModels.UserControlVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace HH.ViewModels
{
    internal class SuperAdminWindowViewModel : ViewModel
    {

        #region ViewObjects

        //UserContol objects
        public SettingsViewModel SettingsVM { get; set; }
        public DataBaseViewModel DataBaseVM { get; set; }
        public SpecialViewModel SpecialVM { get; set; }

        #endregion

        #region CurrentView

        /// <summary>Текущий вид</summary>
        private object _currentView = new SettingsViewModel();
        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        #endregion


        #region ChangeViewCommand

        public ICommand ChangeViewCommand { get; }

        private bool CanChangeViewCommandExecute(object p) => true;

        private void OnChangeViewCommandExecuted(object p)
        {
            CurrentView = p;
        }

        #endregion

        #region LogoutCommand

        public ICommand LogoutCommand { get; }

        private bool CanLogoutCommandExecute(object p) => true;

        private void OnLogoutCommandExecuted(object p)
        {
            AuthorizationModel.OpenWindow(new MainWindow());
        }

        #endregion


        public SuperAdminWindowViewModel()
        {
            #region ViewObjects


            SettingsVM = new();
            DataBaseVM = new();
            SpecialVM = new();

            #endregion

            #region Commands

            ChangeViewCommand = new LambdaCommand(OnChangeViewCommandExecuted, CanChangeViewCommandExecute);
            LogoutCommand = new LambdaCommand(OnLogoutCommandExecuted, CanLogoutCommandExecute);

            #endregion
        }

    }
}
