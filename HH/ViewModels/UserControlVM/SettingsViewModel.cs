using HH.ViewModels.Base;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Windows.Media;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Text.RegularExpressions;

namespace HH.ViewModels.UserControlVM
{
    internal class SettingsViewModel : ViewModel
    {
        public SettingsViewModel() { }

        #region SelectedLanguage

        private static string _SelectedLanguage;

        /// <summary>Заголовок окна</summary>
        public static string SelectedLanguage
        {
            get => _SelectedLanguage;
            set
            {
                _SelectedLanguage = value;
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

        #region SelectedTheme

        private static string _SelectedTheme;

        /// <summary>Заголовок окна</summary>
        public static string SelectedTheme
        {
            get => _SelectedTheme;
            set
            {
                _SelectedTheme = value;
                switch (value)
                {
                    case "0":
                        Application.Current.MainWindow.Resources.Source = new Uri(String.Format("../../Resources/Styles/SuperAdminDarkStyle.xaml"), UriKind.Relative);
                        UserSetting.Default.Theme = _SelectedTheme;
                        UserSetting.Default.Save();
                        break;
                    case "1":
                        Application.Current.MainWindow.Resources.Source = new Uri(String.Format("../../Resources/Styles/SuperAdminLightStyle.xaml"), UriKind.Relative);
                        UserSetting.Default.Theme = _SelectedTheme;
                        UserSetting.Default.Save();
                        break;
                }
            }
        }

        #endregion

    }
}
