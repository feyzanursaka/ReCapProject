using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarTest();
            //BrandTest();
            //AddCustomer();
            //AddCar();
            //AddColor();
            //AddBrand();
            AddRental();

        }
        private static void AddRental()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var result = rentalManager.Add(new Rental {  RentDate = DateTime.Now, ReturnDate = DateTime.Now, CarId = 1, CustomerId = 8 });

            if (result.Success == true)
            {
                Console.WriteLine(result.Message);
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }
        private static void AddCar()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            carManager.Add(new Car { BrandId = 1, ColorId = 1, CarName = "Audi", ModelYear = "2010", DailyPrice = 222, Description = "Hasarsız" });
            
        }
        private static void AddColor()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());

            colorManager.Add(new Color {  ColorName = "Sarı" });
            colorManager.Add(new Color {  ColorName = "Siyah" });
            colorManager.Add(new Color {  ColorName = "Beyaz" });
        }

        private static void AddBrand()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            brandManager.Add(new Brand {  BrandName = "Ford" });
            brandManager.Add(new Brand {  BrandName = "BMW" });
            brandManager.Add(new Brand {  BrandName = "Mercedes" });
        }
        private static void AddCustomer()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());

            customerManager.Add(new Customer { CompanyName = "sdfsdf", UserId = 1 });
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());

             var result = brandManager.GetAll();

            if (result.Success == true)
            {
                foreach (var brand in result.Data)
                {
                    Console.WriteLine(brand.BrandName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }
        private static void CarTest()
        {
            CarManager productManager = new CarManager(new EfCarDal());

            var result = productManager.GetCarDetail();

            if (result.Success == true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.CarName + "/" + car.BrandName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }
        
    }
}
