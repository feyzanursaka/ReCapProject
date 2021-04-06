using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        private readonly ICarService _carService;
        private readonly IFindeksService _findeksService;
        private readonly IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal, ICarService carService, IFindeksService findeksService)
        {
            _carService = carService;
            _findeksService = findeksService;
            _rentalDal = rentalDal;
        }


        public IResult Add(Rental rental)
        {
            _rentalDal.Add(rental);
            return new Result(true, Messages.RentalAdded);
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

        public IDataResult<List<RentalDetailDto>> GetRentalDetail()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails());
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
        public IResult CheckFindeksScoreSufficiency(Rental rental)
        {
            var car = _carService.GetById(rental.CarId).Data;
            var findeks = _findeksService.GetByCustomerId(rental.CustomerId).Data;

            if (findeks == null)
            {
                return new ErrorResult("Findeks bulunamadı");
            }
            if (findeks.Score < car.FindexPoint)
            {
                return new ErrorResult("Findeks yeterli Değil");
            }

            return new SuccessResult("Findeks yeterli");
        }
    }
}