using System;
using System.Windows.Input;
using HH.ViewModels.Base;
using HH.Infastructure.Commands;
using HH.Models.Logic;
using System.Windows;
using System.ComponentModel;
using HH.Infastructure.Commands.Base;
using System.Threading.Tasks;
using HH.ViewModels.UserWindowVM;

namespace HH.ViewModels
{
    internal class UserWindowViewModel : ViewModel
    {

        #region ViewObjects

        //UserContol objects
        public MainViewModel MainVM { get; set; }
        public ServiceViewModel ServiceVM { get; set; }
        public SupportViewModel SupportVM { get; set; }

        #endregion

        #region CurrentView

        /// <summary>Текущий вид</summary>
        private object _currentView = new MainViewModel();
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

        #region Login

        private string _Login = UserSetting.Default.Login;

        /// <summary>Заголовок окна</summary>
        public string Login
        {
            get => _Login;
            set => Set(ref _Login, value);
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



        #region CloseApplicationCommand

        public ICommand CloseApplicationCommand { get; }

        private bool CanCloseApplicationCommandExecute(object p) => true;

        private void OnCloseApplicationCommandExecuted(object p)
        {
            Application.Current.Shutdown();
        }

        #endregion

        #region MinimizeWindowCommand

        public ICommand MinimizeWindowCommand { get; }

        private bool CanMinimizeWindowCommandExecute(object p) => true;

        private void OnMinimizeWindowCommandExecuted(object p)
        {
            Application.Current.Windows[0].WindowState = WindowState.Minimized;
            //            UserModel.ClientInfo(UserSetting.Default.Login);
        }

        #endregion

        #region MaximizeWindowCommand

        public ICommand MaximizeWindowCommand { get; }

        private bool CanMaximizeWindowCommandExecute(object p) => true;

        private void OnMaximizeWindowCommandExecuted(object p)
        {
            if (Application.Current.Windows[0].WindowState != WindowState.Maximized)
            {
                Application.Current.Windows[0].WindowState = WindowState.Maximized;
            }
            else Application.Current.Windows[0].WindowState = WindowState.Normal;
        }

        #endregion


        public UserWindowViewModel()
        {

            #region VmObjects

            MainVM = new();
            ServiceVM = new();
            SupportVM = new();

            #endregion

            CloseApplicationCommand = new LambdaCommand(OnCloseApplicationCommandExecuted, CanCloseApplicationCommandExecute);
            MinimizeWindowCommand = new LambdaCommand(OnMinimizeWindowCommandExecuted, CanMinimizeWindowCommandExecute);
            MaximizeWindowCommand = new LambdaCommand(OnMaximizeWindowCommandExecuted, CanMaximizeWindowCommandExecute);
            ChangeViewCommand=new LambdaCommand(OnChangeViewCommandExecuted, CanChangeViewCommandExecute);
        }
    }
}
