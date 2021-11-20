using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Validation;
using Core.Utilities.Business;
using Core.Utilities.Result;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BookManager : IBookService
    {
        IBookDal _bookDal;

        public BookManager(IBookDal bookDal)
        {
            _bookDal = bookDal;
        }

        [ValidationAspect(typeof(BookValidator))]
        public IResult Add(Book book)
        {
            IResult result = BusinessRules.Run(CheckIfBookNameExist(book.BookName), CheckIfCategoryId(book.CategoryId));
                if (result != null)
                {
                    return result;
                }
  

            _bookDal.Add(book);
            return new SuccessResult(Messages.BookAdded);
        }

        public IResult Delete(Book book)
        {
            _bookDal.Delete(book);
            return new SuccessResult(Messages.BookDeleted);
        }

        public IDataResult<List<Book>> GetAll()
        {
            return new SuccessDataResult<List<Book>>(_bookDal.GetAll());
        }

        public IDataResult<List<Book>> GetByCategory(int categoryid)
        {
            return new SuccessDataResult<List<Book>>(_bookDal.GetAll(x=>x.CategoryId==categoryid));
        }

        public IDataResult<List<BookDetailsDto>> GetByDto()
        {
            return new SuccessDataResult<List<BookDetailsDto>>(_bookDal.GetByDto());
     
        }


        private IResult CheckIfBookNameExist(string bookname)
        {
            var result = _bookDal.GetAll(x => x.BookName == bookname).Any();
            if (result)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }
        private IResult CheckIfCategoryId(int categoryid)
        {
            var result = _bookDal.GetAll(x => x.CategoryId == categoryid).Count;
            if (result > 10)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }
    }
}
