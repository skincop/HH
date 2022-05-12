using HH.Models.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using HH.Views.Windows;
using HH.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using Microsoft.Data.SqlClient;
using System.Configuration;

namespace HH.Models.Logic
{
    internal class AuthorizationModel
    {

        public static  int Enter(string login, string password)
        {
            HotelContext hotelContext = new HotelContext();

            var user = hotelContext.Accounts.FindAsync(login).Result;
            if (user != null && user.UserPassword == HashPassword(password))
            {
                UserSetting.Default.Login = login;
                switch (user.UserRightsType.ToLower())
                {

                    case "superadmin":
                        //Используется для работы с контролами из фонового потока
                        Application.Current.Dispatcher.Invoke(() =>
                        {
                            var superWindow = new SuperAdminWindow();
                            OpenWindow(superWindow);
                        });
                        UserSetting.Default.SuperVisible = "Visible";
                        UserSetting.Default.Save();
                        return 4;
                    case "admin":
                        Application.Current.Dispatcher.Invoke(() =>
                        {
                            var superWindow = new SuperAdminWindow();
                            OpenWindow(superWindow);
                        });
                        UserSetting.Default.SuperVisible = "Collapsed";
                        UserSetting.Default.Save();
                        return 3;
                    case "user":
                        Application.Current.Dispatcher.Invoke(() =>
                        {
                            var userWindow = new UserWindow();
                            OpenWindow(userWindow);
                        });
                        UserSetting.Default.SuperVisible = "Collapsed";
                        UserSetting.Default.Save();
                        return 2;
                    case "hostes":
                        return 1;
                    case "housemaid":
                        return 0;
                    default:
                        return -1;
                }
            }
            else
            {
                MessageBox.Show("noo");
                return -1;
            }
        }




        public static string HashPassword(string password)
        {
            MD5 md5 = MD5.Create();

            byte[] b = Encoding.ASCII.GetBytes(password);
            byte[] hash = md5.ComputeHash(b);


            StringBuilder sb = new StringBuilder();
            foreach (var a in hash)
            {
                sb.Append(a.ToString("X2"));
            }
            return Convert.ToString(sb);
        }
        public static void OpenWindow(Window window)
        {
            App.Current.MainWindow.Close();
            App.Current.MainWindow = window;
            switch (MainWindowViewModel.SelectedLanguage)
            {

                case "0":
                    Application.Current.MainWindow.Resources.Source = new Uri(String.Format("../Resources/Languages/LanguagesRu.xaml"), UriKind.Relative);
                    break;
                case "1":
                    Application.Current.MainWindow.Resources.Source = new Uri(String.Format("../Resources/Languages/LanguagesEn.xaml"), UriKind.Relative);
                    break;
            }
            App.Current.MainWindow.Show();
        }

    }
    public static class CollectionExtension
    {
        public static bool DispatcherAdd<T>(this ObservableCollection<T> collection, T item) where T : class
        {
            try
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    collection.Add(item);
                });
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public static bool DispatcherRemove<T>(this ObservableCollection<T> collection, T item) where T : class
        {
            try
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    collection.Remove(item);
                });
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
    }
}
