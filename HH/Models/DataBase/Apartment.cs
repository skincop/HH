using System;
using System.Collections.Generic;

#nullable disable

namespace HH.Models.DataBase
{
    public partial class Apartment : IEquate<Apartment>,ICloneable
    {
        public Apartment()
        {
            Allocations = new HashSet<Allocation>();
        }
        public Apartment(Apartment other)
        {
            Number=other.Number;
            Floor=other.Floor;
            Capacity=other.Capacity;
            Price=other.Price;
            ApartamentsLogin=other.ApartamentsLogin;
        }

        public int Number { get; set; }
        public int Floor { get; set; }
        public int Capacity { get; set; }
        public decimal Price { get; set; }
        public string ApartamentsLogin { get; set; }

        public virtual Account ApartamentsLoginNavigation { get; set; }
        public virtual ICollection<Allocation> Allocations { get; set; }

    public object Clone()
    {
        return new Apartment(this);
    }

        public void Equate(Apartment other)
        {
            Floor = other.Floor;
            Capacity = other.Capacity;
            Price = other.Price;
            ApartamentsLogin = other.ApartamentsLogin;
        }
}

}
