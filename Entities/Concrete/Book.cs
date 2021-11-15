using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Book:IEntity
    {
        public int Id { get; set; }
        public string BookName { get; set; }
        public int WriterId { get; set; }
        public int Point { get; set; }
        public int CategoryId { get; set; }
        public Nullable<double> Price { get; set; }
    }
}
