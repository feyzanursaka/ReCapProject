using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, MyDataBaseContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails(Expression<Func<Car, bool>> filter = null)
        {
            using (MyDataBaseContext context = new MyDataBaseContext())
            {
                var result = from c in filter is null ? context.Cars : context.Cars.Where(filter)
                             join b in context.Brands on c.BrandId equals b.Id
                             join co in context.Colors on c.ColorId equals co.Id
                             select new CarDetailDto
                             {
                                 Id = c.Id,
                                 BrandId=b.Id,
                                 BrandName = b.BrandName,
                                 ColorId=c.Id,
                                 ColorName = co.ColorName,
                                 DailyPrice = c.DailyPrice,
                                 ModelYear = c.ModelYear,
                                 Description = c.Description,
                                 ImagePath = context.CarImages.Where(x => x.CarId == c.Id).FirstOrDefault().ImagePath,
                                 Status = !(context.Rentals.Any(r => r.CarId == c.Id && (r.ReturnDate == null || r.ReturnDate > DateTime.Now))),
                             };

                return result.ToList();
            }
        }
    }
}