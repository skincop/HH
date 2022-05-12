using HH.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using HH.Infastructure.Commands;
using System.Windows;
using HH.Models.DataBase;
using System.Collections.ObjectModel;
using HH.ViewModels.UserControlVM.DataBaseVM;

namespace HH.ViewModels.UserControlVM
{
    internal class DataBaseViewModel : ViewModel
    {

        #region ViewObjects

        //UserContol objects

        public AccountViewModel AccountVM { get; set; }
        public AllocationViewModel AllocationVM { get; set; }
        public ApartmentsViewModel ApartamentsVM { get; set; }
        public ClientViewModel ClientVM { get; set; }
        public EmployeeViewModel EmployeeVM { get; set; }
        public PostViewModel PostVM { get; set; }
        public ServiceListViewModel ServiceListVM { get; set; }
        public ServiceViewModel ServiceVM { get; set; }

        #endregion

        #region CurrentView

        /// <summary>Текущий вид</summary>
        private object _currentView;
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


        public DataBaseViewModel()
        {
            #region vm objects

            AccountVM = new();
            AllocationVM = new();
            ApartamentsVM = new();
            ClientVM=new();
            EmployeeVM = new();
            PostVM=new();
            ServiceListVM = new();
            ServiceVM = new();

            

            #endregion

            #region  commands

            ChangeViewCommand = new LambdaCommand(OnChangeViewCommandExecuted, CanChangeViewCommandExecute);

            #endregion
        }
    }
}
