using Core.Utilities.Result;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
   public  interface IMovieService
    {
        IDataResult<List<Movie>> GetAll();
        IResult Add(Movie movie);
        IDataResult<List<Movie>> GetByCategory(int categoryid);
        IResult TransactionalOperation(Movie movie);
    }
}
