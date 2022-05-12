using System;
using System.Collections.Generic;

#nullable disable

namespace HH.Models.DataBase
{
    public partial class Post : ICloneable, IEquate<Post>
    {
        public Post()
        {
            Employees = new HashSet<Employee>();
        }

        public Post(Post other)
        {
            Id=other.Id;
            Name=other.Name;
            Salary=other.Salary;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Salary { get; set; }

        public virtual ICollection<Service> Services { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }

        public object Clone()
        {
            return new Post(this);
        }

        public void Equate(Post other)
        {
            Name = other.Name;
            Salary = other.Salary;
        }
    }
}
