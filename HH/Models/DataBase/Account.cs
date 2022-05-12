using System;
using System.Collections.Generic;

#nullable disable

namespace HH.Models.DataBase
{
    public partial class Account : IEquate<Account>, ICloneable
    {
        public Account()
        {
            Apartments = new HashSet<Apartment>();
            Employees = new HashSet<Employee>();
        }
        public Account(Account other)
        {
            UserLogin = other.UserLogin;
            UserPassword = other.UserPassword;
            UserRightsType = other.UserRightsType;
        }

        public string UserLogin { get; set; }
        public string UserPassword { get; set; }
        public string UserRightsType { get; set; }

        public virtual ICollection<Apartment> Apartments { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }

        public object Clone()
        {
            return new Account(this);
        }

        public void Equate(Account other)
        {
            this.UserPassword = other.UserPassword;
            this.UserRightsType = other.UserRightsType;
        }
        

    }
}
