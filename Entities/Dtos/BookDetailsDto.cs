using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class BookDetailsDto:IDto
    {
        public string BookName { get; set; }
        public Nullable<double> Price { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CategoryName { get; set; }
    }
}
