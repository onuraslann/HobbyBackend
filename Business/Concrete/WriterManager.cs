using Business.Abstract;
using Business.BusinessAspects;
using Core.Aspects.Performance;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class WriterManager : IWriterService
    {
        IWriterDal _writerDal;

        public WriterManager(IWriterDal writerDal)
        {
            _writerDal = writerDal;
        }
        [SecuredOperation("editor")]
        public IResult Add(Writer writer)
        {
            _writerDal.Add(writer);
            return new SuccessResult();
        }
        [PerformanceAspect(interval:0)]
        public IDataResult<List<Writer>> GetAll()
        {
            Thread.Sleep(5);
            return new SuccessDataResult<List<Writer>>(_writerDal.GetAll());
        }
    }
}
