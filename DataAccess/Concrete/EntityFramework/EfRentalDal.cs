using Core.DataAccess.EntityFramework;
using Core.Entities;
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
    public class EfRentalDal : EfEntityRepositoryBase<Rental, MyDataBaseContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (MyDataBaseContext contex = new MyDataBaseContext())
            {
                var result = from r in contex.Rentals
                             join c in contex.Cars
                             on r.CarId equals c.Id
                             join cus in contex.Customers
                             on r.CustomerId equals cus.Id
                             join us in contex.Users
                             on cus.UserId equals us.Id
                             select new RentalDetailDto
                             {
                                 RentalId = r.Id,
                             
                                 FirstName = us.FirstName,
                                 LastName = us.LastName,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate

                             };

                return result.ToList();
            }

        }


    }
}