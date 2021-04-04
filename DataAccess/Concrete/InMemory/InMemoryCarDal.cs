using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal      
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car> {
            new Car{Id=1,BrandId=1,ColorId=1,ModelYear=2015,DailyPrice=60,Description="Car 1" },
            new Car{Id=1,BrandId=1,ColorId=1,ModelYear=2016,DailyPrice=70,Description="Car 2" },
            new Car{Id=1,BrandId=2,ColorId=1,ModelYear=2017,DailyPrice=100,Description="Car 3" },
            new Car{Id=1,BrandId=3,ColorId=1,ModelYear=2017,DailyPrice=200,Description="Car 4" },
            new Car{Id=1,BrandId=4,ColorId=1,ModelYear=2019,DailyPrice=10,Description="Car 5" },
            new Car{Id=1,BrandId=5,ColorId=1,ModelYear=2020,DailyPrice=30,Description="Car 6" }
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete= _cars.SingleOrDefault(p => p.Id == car.Id);
        }

        public Car Get(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int id)
        {
            return _cars.Where(p => p.Id == id).ToList();
        }

        public List<CarDetailDto> GetCarDetail()
        {
            throw new NotImplementedException();
        }
        public List<CarDetailDto> GetByBrandDetails(int brandId)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetByColorDetails(int colorId)
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(p => p.Id == car.Id);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }

        public List<CarDetailDto> GetCarDetailsByCarId(int carId)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetails(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }
    }
}
