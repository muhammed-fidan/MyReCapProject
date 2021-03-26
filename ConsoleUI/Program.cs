﻿using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;
namespace ConsoleUI
{
    class Program
    {
        

        static void Main(string[] args)
        {
            //CarTest();

            //BrandTest();

            //ColorTest();

            //GetByIdTests();

            GetProductDetailsTest();

        }

        private static void GetProductDetailsTest()
        {
            foreach (var car in new CarManager(new EfCarDal()).GetCarDetails())
            {
                Console.WriteLine(car.CarName + " " + car.BrandName + " " + car.ColorName + " " + car.DailyPrice);
            }
        }

        private static void GetByIdTests()
        {
            Console.WriteLine(new ColorManager(new EfColorDal()).GetById(3).ColorName);
            Console.WriteLine(new CarManager(new EfCarDal()).GetById(1007).DailyPrice);
            Console.WriteLine(new BrandManager(new EfBrandDal()).GetById(1005).BrandName);
        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            colorManager.Insert(new Color {ColorName = "Dark Black" });
            Console.WriteLine("Yeni renk eklendi." + Environment.NewLine);
            colorManager.Delete(new Color { ColorId = 2 });
            Console.WriteLine("2 Id numarali renk kayitlardan silindi." + Environment.NewLine);
            colorManager.Update(new Color { ColorId = 1, ColorName = "Light Blue" });
            Console.WriteLine("1 ID numarali renk bilgileri guncellendi");
            list();
            void list()
            {
                Console.WriteLine("Renkler listeleniyor.." + Environment.NewLine);
                foreach (var color in colorManager.GetAll())
                {
                    Console.WriteLine(color.ColorId + " " + color.ColorName);
                }
            }
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            brandManager.Insert(new Brand { BrandName = "Dodge" });
            Console.WriteLine("Yeni marka eklendi." + Environment.NewLine);
            brandManager.Delete(new Brand { BrandId = 1005 });
            Console.WriteLine("2 Id numarali marka kayitlardan silindi." + Environment.NewLine);
            brandManager.Update(new Brand { BrandId = 1006, BrandName = "Jaguar" });
            Console.WriteLine("3 ID numarali marka bilgileri guncellendi");
            list();
            void list()
            {
                Console.WriteLine("Markalar listeleniyor.." + Environment.NewLine);
                foreach (var brand in brandManager.GetAll())
                {
                    Console.WriteLine(brand.BrandId + " " + brand.BrandName);
                }
            }
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Insert(new Car { BrandId = 7, ColorId = 3, DailyPrice = 100, Description = "Benzinli", ModelYear = "2015" });
            Console.WriteLine("Yeni araba eklendi." + Environment.NewLine);
            carManager.Delete(new Car { Id = 2009});
            Console.WriteLine("1 ID Numarali Araba bilgileri kayitlardan silindi." + Environment.NewLine);
            carManager.Update(new Car { Id = 1007, BrandId = 3, ColorId = 2, DailyPrice = 180, Description = "Dizel", ModelYear = "2018" });
            Console.WriteLine("1007 ID numarali araba bilgileri guncellendi." + Environment.NewLine);
            list();

            void list()
            {
                Console.WriteLine("Arabalar listeleniyor.." + Environment.NewLine);
                foreach (var car in carManager.GetAll())
                {
                    Console.WriteLine(car.Id + " "+ car.DailyPrice + " " + car.Description);
                }
            }
        }

    }

    

}
