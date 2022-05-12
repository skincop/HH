using System;
using System.Windows.Input;
using HH.ViewModels.Base;
using HH.Infastructure.Commands;
using HH.Models.Logic;
using System.Windows;
using System.ComponentModel;
using HH.Infastructure.Commands.Base;
using System.Threading.Tasks;

namespace HH.ViewModels
{
    internal class MainWindowViewModel : ViewModel, IDataErrorInfo
    {


        #region Login

        private string _Login = "AdminAdmin";//"Login"

        /// <summary>Заголовок окна</summary>
        public string Login
        {
            get => _Login;
            set => Set(ref _Login, value);
        }

        #endregion

        #region Password

        private string _Password = "AdminAdmin";

        /// <summary>Заголовок окна</summary>
        public string Password
        {
            get => _Password;
            set => Set(ref _Password, value);
        }


        #endregion

        #region SelectedLanguage

        private static string _SelectedLanguage;

        /// <summary>Заголовок окна</summary>
        public static string SelectedLanguage
        {
            get => _SelectedLanguage;
            set
            {
                _SelectedLanguage=value;
                switch (value)
                {
                    case "0":
                        Application.Current.MainWindow.Resources.Source = new Uri(String.Format("../Resources/Languages/LanguagesRu.xaml"), UriKind.Relative);
                        UserSetting.Default.Language = _SelectedLanguage;
                        UserSetting.Default.Save();
                        break;
                    case "1":
                        Application.Current.MainWindow.Resources.Source = new Uri(String.Format("../Resources/Languages/LanguagesEn.xaml"), UriKind.Relative);
                        UserSetting.Default.Language = _SelectedLanguage;
                        UserSetting.Default.Save();
                        break;
                }
            }
        }


        #endregion

        #region IDataErrorInfo

        public string this[string columnName]
        {
            get
            {
                string error = String.Empty;
                switch (columnName)
                {
                    case "Password":
                        if (Password.Length <= 7 || Password.Length > 20)
                        {
                            error = (string)Application.Current.MainWindow.TryFindResource("PasswordException");
                        }
                        break;
                    case "Login":
                        if (Login.Length <= 4 ||  Login.Length>25)
                        {
                            error = (string)Application.Current.MainWindow.TryFindResource("LoginException");
                        }

                        break;
                }
                return error;
            }
        }
        public string Error
        {
            get { throw new NotImplementedException(); }
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
        }


        #endregion

        #region SendButtonCommand


        public IAsyncCommand Send { get; private set; }

        private async Task ExecuteSendAsync()
        {
            await Task.Run(() => AuthorizationModel.Enter(Login,Password));
        }

        private bool CanExecuteSend()
        {
            if (Login.Length >= 4 && Password.Length >= 8 )
                return true;
            else return false;
        }

        #endregion




        public MainWindowViewModel()
        {
            CloseApplicationCommand = new LambdaCommand(OnCloseApplicationCommandExecuted, CanCloseApplicationCommandExecute);
            MinimizeWindowCommand = new LambdaCommand(OnMinimizeWindowCommandExecuted, CanMinimizeWindowCommandExecute);
            Send = new AsyncCommand(ExecuteSendAsync, CanExecuteSend);
        }
    }
}
