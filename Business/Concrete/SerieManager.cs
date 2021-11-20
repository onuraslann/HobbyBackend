using Business.Abstract;
using Business.Constants;
using Core.Aspects.Caching;
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
    public class SerieManager : ISerieService
    {
        ISerieDal _serieDal;

        public SerieManager(ISerieDal serieDal)
        {
            _serieDal = serieDal;
        }

        public IResult Add(Serie serie)
        {
            _serieDal.Add(serie);
            return new SuccessResult(Messages.SerieAdded);
        }

        [CacheAspect]
        public IDataResult<List<Serie>> GetAll()
        {
            return new SuccessDataResult<List<Serie>>(_serieDal.GetAll());
        }
    }
}
