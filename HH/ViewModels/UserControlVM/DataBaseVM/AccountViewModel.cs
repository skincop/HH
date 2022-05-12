using HH.Infastructure.Commands;
using HH.Infastructure.Commands.Base;
using HH.Models.DataBase;
using HH.ViewModels.Base;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using HH.Models.Logic;
using Microsoft.EntityFrameworkCore;

namespace HH.ViewModels.UserControlVM.DataBaseVM
{
    internal class AccountViewModel : DataViewModel<Account>
    {
        public AccountViewModel() : base()
        {

        }
        
        
    }
}