﻿using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IFakeCardService
    {
        IDataResult<List<FakeCard>> GetByCardNumber(string cardNumber);
        IDataResult<List<FakeCard>> GetAll();
        IDataResult<FakeCard> GetById(int cardId);
        IResult IsCardExist(FakeCard fakeCard);
        IResult Add(FakeCard fakeCard);
        IResult Delete(FakeCard fakeCard);
        IResult Update(FakeCard fakeCard);
        IDataResult<List<FakeCard>> GetByUserId(int userId);
    }
}