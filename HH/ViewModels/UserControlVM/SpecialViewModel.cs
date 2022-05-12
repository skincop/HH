using HH.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using HH.Models.Logic;
using System.Windows;
using HH.Infastructure.Commands;
using HH.Infastructure.Commands.Base;

namespace HH.ViewModels.UserControlVM
{
    internal class SpecialViewModel : ViewModel
    {
        #region Inpit

        private string _input;

        /// <summary>Заголовок окна</summary>
        public string Input
        {
            get => _input;
            set => Set(ref _input, value);
        }

        #endregion

        #region Result

        private string _result;

        public string Result
        {
            get { return _result; }
            set
            {
                _result = value;
                OnPropertyChanged();
            }
        }



        #endregion

        #region SqlString

        private string _sqlString;

        public string SqlString
        {
            get { return _sqlString; }
            set
            {
                _sqlString = value;
                OnPropertyChanged();
            }
        }

        #endregion


        #region SqlResult

        private string _sqlResult;

        public string SqlResult
        {
            get { return _sqlResult; }
            set
            {
                _sqlResult = value;
                OnPropertyChanged();
            }
        }

        #endregion


        #region HashPasswordCommand

        public ICommand HashPasswordCommand { get; }

        private bool CanHashPasswordCommandExecute(object p) => Input != null;

        private void OnHashPasswordCommandExecuted(object p)
        {
            try
            {
                Result=AuthorizationModel.HashPassword(Input);
            }
            catch (Exception)
            {
                MessageBox.Show("Eror");
            }
        }

        #endregion

        
        public SpecialViewModel()
        {
            HashPasswordCommand = new LambdaCommand(OnHashPasswordCommandExecuted, CanHashPasswordCommandExecute);
        }
    }
}
