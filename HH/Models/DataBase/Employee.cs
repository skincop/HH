using System;
using System.Collections.Generic;

#nullable disable

namespace HH.Models.DataBase
{
    public partial class Employee : ICloneable,IEquate<Employee>
    {
        public Employee()
        {
            ServiceLists = new HashSet<ServiceList>();
        }
        public Employee(Employee other)
        {
            this.Id=other.Id;
            this.Name=other.Name;
            this.Surname=other.Surname;
            this.Patronymic=other.Patronymic;
            this.Adress=other.Adress;
            this.Telephone=other.Telephone;
            this.Post=other.Post;
            this.EmployeeLogin=other.EmployeeLogin;
        }

        public int Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public string Adress { get; set; }
        public string Telephone { get; set; }
        public int Post { get; set; }
        public string EmployeeLogin { get; set; }

        public virtual Account EmployeeLoginNavigation { get; set; }
        public virtual Post PostNavigation { get; set; }
        public virtual ICollection<ServiceList> ServiceLists { get; set; }

        public void Equate(Employee other)
        {
            this.Name = other.Name;
            this.Surname = other.Surname;
            this.Patronymic = other.Patronymic;
            this.Adress = other.Adress;
            this.Telephone = other.Telephone;
            this.Post = other.Post;
            this.EmployeeLogin = other.EmployeeLogin;
        }

        public object Clone()
        {
            return new Employee(this);
        }
        


    }
}
