using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfBookDal : EfEntityRepositoryBase<Book, HobbyContext>, IBookDal
    {
        public List<BookDetailsDto> GetByDto()
        {
            using (HobbyContext context = new HobbyContext())
            {
                var result = from writer in context.Writers
                             join book in context.Books
                               on writer.Id equals book.WriterId
                             join category in context.Categories
                             on book.CategoryId equals category.Id
                             select new BookDetailsDto
                             {
                                 BookName = book.BookName,
                                 Price = book.Price,
                                 CategoryName = category.CategoryName,
                                 FirstName = writer.FirstName,
                                 LastName = writer.LastName


                             };
                return result.ToList();
            }
        }
    }
}
