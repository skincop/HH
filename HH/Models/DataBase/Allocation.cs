using System;
using System.Collections.Generic;

#nullable disable

namespace HH.Models.DataBase
{
    public partial class Allocation : IEquate<Allocation>,ICloneable
    {
        public int AllocationId { get; set; }
        public int ClientId { get; set; }
        public int ApartmentsNumber { get; set; }
        public DateTime? FirstDate { get; set; }
        public DateTime? LastDate { get; set; }

        public virtual Apartment ApartmentsNumberNavigation { get; set; }
        public virtual Client Client { get; set; }

        public Allocation(Allocation other)
        {
            AllocationId=other.AllocationId;
            ClientId=other.ClientId;
            ApartmentsNumber=other.ApartmentsNumber;
            FirstDate=other.FirstDate;
            LastDate=other.LastDate;
        }
        public Allocation()
        {


        }

        public object Clone()
        {
            return new Allocation(this);
        }

        public void Equate(Allocation other)
        {
            ClientId = other.ClientId;
            ApartmentsNumber = other.ApartmentsNumber;
            FirstDate = other.FirstDate;
            LastDate = other.LastDate;
        }
    }
}
