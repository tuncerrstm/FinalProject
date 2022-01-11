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
            ProductManager productManager = new ProductManager(new EfProductDal());

            foreach (var product in productManager.GetAll())
            {
                Console.WriteLine(product.ProductName);
            }

        }
    }
}
