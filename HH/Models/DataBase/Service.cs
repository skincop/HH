using System;
using System.Collections.Generic;

#nullable disable

namespace HH.Models.DataBase
{
    public partial class Service : ICloneable,IEquate<Service>
    {
        public Service()
        {
            ServiceLists = new HashSet<ServiceList>();
        }
        public Service(Service other)
        {
            Id=other.Id;
            Name=other.Name;
            Price=other.Price;
            Post=other.Post;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Post { get; set; }

        public virtual Post PostNavigation { get; set; }

        public virtual ICollection<ServiceList> ServiceLists { get; set; }

        public object Clone()
        {
            return new Service(this);
        }

        public void Equate(Service other)
        {
            Name = other.Name;
            Price = other.Price;
            Post = other.Post;
        }
    }
}
