using HH.Infastructure.Commands;
using HH.Infastructure.Commands.Base;
using HH.Models.DataBase;
using HH.Models.Logic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace HH.ViewModels.Base
{
    public class DataViewModel<T> : ViewModel where T : class, IEquate<T>, ICloneable,new()
    {
        public HotelContext HotelContext;

        #region List

        private ObservableCollection<T> _list;

        public ObservableCollection<T> List
        {
            get { return _list; }
            set { 
                _list = value;
                OnPropertyChanged(nameof(List));
            }
        }

        #endregion


        #region Updated

        private T _updated; 

        public T Updated
        {
            get { return _updated; }
            set {
                _updated = value;
                OnPropertyChanged();
            }
        }



        #endregion

        #region Selected

        public T _selected;

        public T Selected
        {
            get { return _selected; }
            set { 
                _selected = value;
                Updated = (T)_selected.Clone();
                OnPropertyChanged();

            }
        }

        #endregion

        #region New

        public T _new;

        public T New
        {
            get { return _new; }
            set
            {
                _new = value;
                OnPropertyChanged();
            }
        }

        #endregion


        #region Refresh
        public IAsyncCommand Refresh { get; private set; }

        private async Task ExecuteRefreshAsync()
        {
            await Task.Run(() => {
                List = new ObservableCollection<T>(HotelContext.Set<T>());
            });
        }

        private bool CanExecuteRefresh() => true;

        #endregion


        #region Update
        public IAsyncCommand Update { get; private set; }

        private async Task ExecuteUpdateAsync()
        {
            await Task.Run(() =>
            {
                try
                {
                    Selected.Equate(Updated);
                    OnPropertyChanged(nameof(Selected));
                    HotelContext.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
            });
        }

        private bool CanExecuteUpdate() => Selected != null;

        #endregion


        #region Delete
        public ICommand Delete { get; private set; }

        private async Task ExecuteDeleteAsync(T obj)
        {
            await Task.Run(() =>
            {
                try
                {
                    HotelContext.Set<T>().Remove(obj);
                    HotelContext.SaveChanges();
                    List.DispatcherRemove<T>(obj);

                }
                catch (Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException)
                {
                    MessageBox.Show(Application.Current.MainWindow.TryFindResource("SqlException").ToString());
                }
            });
        }

        private bool CanExecuteDelete(T obj) => true;

        #endregion


        #region Add
        public IAsyncCommand Add { get; private set; }

        private async Task ExecuteAddAsync()
        {

            await Task.Run(() =>
            {
                try
                {
                    HotelContext.Set<T>().AddAsync(New);
                    HotelContext.SaveChanges();
                    List.DispatcherAdd<T>(New);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            });
        }
        private bool CanExecuteAdd() => true;
        #endregion


        public DataViewModel()
        {
            HotelContext = new HotelContext();

            New = new T();
            Selected = new T();

            Refresh = new AsyncCommand(ExecuteRefreshAsync, CanExecuteRefresh);
            Delete = new AsyncGenericCommand<T>(ExecuteDeleteAsync, CanExecuteDelete);
            Add = new AsyncCommand(ExecuteAddAsync, CanExecuteAdd);
            Update = new AsyncCommand(ExecuteUpdateAsync, CanExecuteUpdate);
        }


    }
}
