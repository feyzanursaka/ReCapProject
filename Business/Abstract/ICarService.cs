using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        IResult Add(Car car);
        IResult Delete(Car car);
        IResult Update(Car car);
        IDataResult<List<Car>> GetAll();
        IDataResult<Car> GetById(int carId);

        IDataResult<List<Car>> GetByBrandId(int brandIdd);
        IDataResult<List<Car>> GetByColorId(int colorId);
        IDataResult<List<Car>> GetByDailyPrice(decimal min, decimal max);

  

        IDataResult<List<CarDetailDto>> GetCarDetailsByBrandId(int brandId);
        IDataResult<List<CarDetailDto>> GetCarDetailsByColorId(int colorId);

        IDataResult<List<CarDetailDto>> GetCarDetailsByCarId(int carId);
        IDataResult<List<CarDetailDto>> GetCarsBySelect(int brandId, int colorId);
        IDataResult<List<CarDetailDto>> GetCarDetails(Expression<Func<Car, bool>> filter = null);
    }
}