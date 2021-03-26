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
        public List<CarDetailDto> GetCarDetail()
        {
            using (MyDataBaseContext context = new MyDataBaseContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.Id
                             join col in context.Colors
                             on c.ColorId equals col.Id
                             select new CarDetailDto
                             {
                                 CarId = c.Id,
                                 CarName = c.CarName,
                                 BrandName = b.BrandName,
                                 ColorName = col.ColorName,
                                 ModelYear = c.ModelYear,
                                 DailyPrice = c.DailyPrice,
                                 Description = c.Description
                             };
                return result.ToList();
            }
        }
		public List<CarDetailDto> GetByBrandDetails(int brandId)
		{
			using (MyDataBaseContext context = new MyDataBaseContext())
			{
				var result = from c in context.Cars
							 where c.BrandId == brandId
							 join b in context.Brands
							 on c.BrandId equals b.Id
							 join co in context.Colors
							 on c.ColorId equals co.Id
							 select new CarDetailDto
							 {
								 CarId = c.Id,
								 BrandName = b.BrandName,
								 ColorName = co.ColorName,
								 DailyPrice = c.DailyPrice
							 };
				return result.ToList();
			}
		}

		public List<CarDetailDto> GetByColorDetails(int colorId)
		{
			using (MyDataBaseContext context = new MyDataBaseContext())
			{
				var result = from c in context.Cars
							 where c.ColorId == colorId
							 join b in context.Brands
							 on c.BrandId equals b.Id
							 join co in context.Colors
							 on c.ColorId equals co.Id
							 select new CarDetailDto
							 {
								 CarId = c.Id,
								 BrandName = b.BrandName,
								 ColorName = co.ColorName,
								 DailyPrice = c.DailyPrice
							 };
				return result.ToList();
			}
		}
	}
}
