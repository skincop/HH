using System;
using System.Collections.Generic;

#nullable disable

namespace HH.Models.DataBase
{
    public partial class Client : ICloneable,IEquate<Client>
    {
        public Client()
        {
            Allocations = new HashSet<Allocation>();
            ServiceLists = new HashSet<ServiceList>();
        }
        public Client(Client other)
        {
            Id = other.Id;
            Surname = other.Surname;
            Name = other.Name;
            Patronymic = other.Patronymic;
            Gender = other.Gender;
            Birthday=other.Birthday;
            Passport = other.Passport;
            Telephone = other.Telephone;
        }

        public int Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public string Gender { get; set; }
        public DateTime Birthday { get; set; }
        public string Passport { get; set; }
        public string Telephone { get; set; }

        public virtual ICollection<Allocation> Allocations { get; set; }
        public virtual ICollection<ServiceList> ServiceLists { get; set; }

        public object Clone()
        {
            return new Client(this);
        }

        public void Equate(Client other)
        {
            Surname = other.Surname;
            Name = other.Name;
            Patronymic = other.Patronymic;
            Gender = other.Gender;
            Birthday = other.Birthday;
            Passport = other.Passport;
            Telephone = other.Telephone;
        }
    }
}
