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
                             on c.Id equals b.BrandId
                             select new CarDetailDto
                             {
                                 CarId = c.Id,
                                 CarDescription = c.Description,
                                 BrandName = b.BrandName,
                                 ModelYear = c.ModelYear
                             };
                return result.ToList();
            }
        }
    }
}
