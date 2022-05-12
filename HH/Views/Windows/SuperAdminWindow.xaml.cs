using HH.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HH.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для SuperAdminWindow.xaml
    /// </summary>
    public partial class SuperAdminWindow : Window
    {
        public SuperAdminWindow()
        {
            InitializeComponent();
            ((App)Application.Current).WindowPlace.Register(this);


            

        }
    }
}
