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

            //AddCar();
            //AddColor();
            //AddBrand();

            //ColorGetById();
            //BrandGetById();

            //UpdateCar();

        }

        private static void UpdateCar()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetAll())
            {
                if (car.Id == 1)
                {
                    carManager.Update(car);
                    Console.WriteLine("Güncelleme başarılı");
                }
            }
        }

        private static void BrandGetById()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            foreach (var brand in brandManager.GetById(1))
            {
                Console.WriteLine("Brand Name : " + brand.BrandName);
            }
        }

        private static void ColorGetById()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            foreach (var color in colorManager.GetById(1))
            {
                Console.WriteLine("Color Name : " + color.ColorName);
            }
        }

        private static void AddBrand()
        {
            BrandManager ColorManager = new BrandManager(new EfBrandDal());

            Brand brand1 = new Brand { BrandId = 8, BrandName = "Cadillac" };
            Brand brand2 = new Brand { BrandId = 9, BrandName = "Caterham" };
            Brand brand3 = new Brand { BrandId = 10, BrandName = "Chery" };

            ColorManager.Add(brand1);
            ColorManager.Add(brand2);
            ColorManager.Add(brand3);
        }

        private static void AddColor()
        {
            ColorManager ColorManager = new ColorManager(new EfColorDal());

            Color color1 = new Color { ColorID = 6, ColorName = "Pink" };
            Color color2 = new Color { ColorID = 7, ColorName = "Aqua" };
            Color color3 = new Color { ColorID = 8, ColorName = "Grey" };

            ColorManager.Add(color1);
            ColorManager.Add(color2);
            ColorManager.Add(color3);
        }

        private static void AddCar()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            Car car1 = new Car { Id = 4, BrandId = 1, ColorId = 1, ModelYear = "2015", DailyPrice = 60, Description = "Car 4" };
            Car car2 = new Car { Id = 5, BrandId = 1, ColorId = 1, ModelYear = "2016", DailyPrice = 70, Description = "Car 5" };
            Car car3 = new Car { Id = 6, BrandId = 1, ColorId = 1, ModelYear = "2015", DailyPrice = 80, Description = "Car 6" };
            
            carManager.Add(car1);
            carManager.Add(car2);
            carManager.Add(car3);
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetCarDetail())
            {
                Console.WriteLine("Car Name : " + car.CarName + ", Brand Name : " + car.BrandName + ", Color Name : " + car.ColorName + ", Daily Price : " + car.DailyPrice);
            }
        }
    }
}
