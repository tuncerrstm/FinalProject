using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    // SOLID 
    // Bu yaptığımız hareket solidin O harfi : Yaptığımız yazılıma yeni bir özellik eliyorsak mevcuttaki hiç bir koda dokunamayız.
    // Open Closed Principle bu anlama gelir.
    class Program
    {
        static void Main(string[] args)
        {
            // IoC Diye bir kavramla new ' lememize gerek olmayacak. Şuan hala code refactor edilmeli.
            // DTO : Data Tranformation Object (Yani taşıyacağımız objeler anlamına gelir.)
            ProductTest();
            //CategoryTest();

        }

        private static void CategoryTest()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
            foreach (var category in categoryManager.GetAll())
            {
                Console.WriteLine(category.CategoryName);
            }
        }

        private static void ProductTest()
        {
            ProductManager productManager = new ProductManager(new EfProductDal());

            var result = productManager.GetProductDetails();

            if (result.Success)
            {
                foreach (var product in productManager.GetProductDetails().Data)
                {
                    Console.WriteLine(product.ProductName + "/" + product.CategoryName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
            
        }
    }
}
