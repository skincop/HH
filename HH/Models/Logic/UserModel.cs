using HH.Models.DataBase;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HH.Models.Logic
{
    internal  class UserModel : INotifyPropertyChanged
    {
        public static Apartment? apartment { get; set; }
        public static Allocation? allocation { get; set; }
        public static Client? client { get; set; }



        private Apartment _apartment;

        /// <summary>Заголовок окна</summary>
        public Apartment Apartment
        {
            get => _apartment;
            set
            {
                _apartment = value;
                OnPropertyChanged();
            }
        }


        private static readonly HotelContext context = new();

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string PropertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }

        public  void ClientInfo()
        {
            try
            {
                Apartment = context.Apartments.Where(p => p.ApartamentsLogin == UserSetting.Default.Login).FirstOrDefault();
                allocation = context.Allocations.Where(p => p.ApartmentsNumber == Apartment.Number).FirstOrDefault();
                client = context.Clients.Find(allocation.ClientId);
                MessageBox.Show($"{Apartment.ApartamentsLogin} {allocation.ApartmentsNumber} {client.Name} ");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error");
            }
        }
    }
}
