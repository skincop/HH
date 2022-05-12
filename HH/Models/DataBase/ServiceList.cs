using System;
using System.Collections.Generic;

#nullable disable

namespace HH.Models.DataBase
{
    public partial class ServiceList : ICloneable,IEquate<ServiceList>
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int ServiceId { get; set; }
        public int? Amount { get; set; }
        public string ServiceStatus { get; set; }
        public int? EmployeeId { get; set; }

        public virtual Client Client { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Service Service { get; set; }
        public ServiceList()
        {

        }

        public ServiceList(ServiceList other)
        {
            Id = other.Id;
            ClientId = other.ClientId;
            ServiceId = other.ServiceId;
            Amount = other.Amount;
            ServiceStatus = other.ServiceStatus;
            EmployeeId = other.EmployeeId;
        }

        public object Clone()
        {
            return new ServiceList(this);
        }

        public void Equate(ServiceList other)
        {
            ClientId = other.ClientId;
            ServiceId = other.ServiceId;
            Amount = other.Amount;
            ServiceStatus = other.ServiceStatus;
            EmployeeId = other.EmployeeId;
        }
    }
}
