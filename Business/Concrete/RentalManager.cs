using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }
        private bool isRentable(Rental rental)
        {
            Rental notReturned = _rentalDal.GetAll(r => r.ReturnDate == null).SingleOrDefault(r => r.CarId == rental.CarId);
            return notReturned == null ? true : false;

        }
        public IResult Add(Rental rental)
        {
            if (isRentable(rental))
            {
                _rentalDal.Add(rental);
                return new SuccessResult("Aracınız Kiralandı");
            }
            else
            {
                return new ErrorResult("Araç Şuan Kiralık. Kiralama Başarısız");
            }
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new Result(true, Messages.RentalDeleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.RentalListed);
        }

        public IDataResult<Rental> GetById(int rentalId)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(p => p.Id == rentalId));
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new Result(true, Messages.RentalUpdated);
        }
    }
}
