using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.Models.DataBase
{
    public interface IEquate<T> where T : class
    {
        public void Equate(T other);
    }
}
