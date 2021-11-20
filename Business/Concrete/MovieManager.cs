using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Caching;
using Core.Aspects.Transaction;
using Core.Aspects.Validation;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class MovieManager : IMovieService
    {
        IMovieDal _movieDal;

        public MovieManager(IMovieDal movieDal)
        {
            _movieDal = movieDal;
        }
        [CacheRemoveAspect("IMovieService.Get")]
        [ValidationAspect(typeof(MovieValidator))]
        public IResult Add(Movie movie)
        {
            _movieDal.Add(movie);
            return new SuccessResult(Messages.MovieAdded);
        }

        [CacheAspect]
        public IDataResult<List<Movie>> GetAll()
        {
            return new SuccessDataResult<List<Movie>>(_movieDal.GetAll());
        }

        public IDataResult<List<Movie>> GetByCategory(int categoryid)
        {
            return new SuccessDataResult<List<Movie>>(_movieDal.GetAll(x=>x.CategoryId==categoryid));
        }

        [TransactionScopeAspect]
        public IResult TransactionalOperation(Movie movie)
        {
            _movieDal.Update(movie);
            _movieDal.Add(movie);
            return new SuccessResult();
        }
    }
}
