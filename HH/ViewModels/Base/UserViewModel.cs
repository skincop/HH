using HH.Models.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HH.ViewModels.Base
{
    internal class UserViewModel : ViewModel
    {

        HotelContext context = new HotelContext();


        #region Appartmnet

        private Apartment _apartment;

        public Apartment Apartments
        {
            get { return _apartment; }
            set
            {
                _apartment = value;
                OnPropertyChanged();
            }
        }

        #region Allocation

        private Allocation _allocation;

        public Allocation Allocation
        {
            get { return _allocation; }
            set
            {
                _allocation = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Client

        private Client _client;

        public Client Client
        {
            get { return _client; }
            set
            {
                _client = value;
                OnPropertyChanged();
            }
        }

        #endregion 
        public UserViewModel()
        {
            Apartments=context.Apartments.Where(p => p.ApartamentsLogin == UserSetting.Default.Login).FirstOrDefault();
            Allocation = context.Allocations.Where(p => p.ApartmentsNumber == Apartments.Number).FirstOrDefault();
            Client = context.Clients.Find(Allocation.ClientId);
        }
        #endregion

    }
}
