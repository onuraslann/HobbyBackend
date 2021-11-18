﻿using Core.Utilities.Result;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
   public interface IBookService
    {
        IResult Add(Book book);
        IResult Delete(Book book);

        IDataResult<List<Book>> GetAll();

        IDataResult<List<Book>> GetByCategory(int categoryid);
        IDataResult<List<BookDetailsDto>> GetByDto();
    }
}
