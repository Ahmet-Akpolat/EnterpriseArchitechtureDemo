using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //ProductManager productManager = new ProductManager(new InMemoryProductDal());

            //foreach (var product in productManager.GetAll())
            //{
            //    Console.WriteLine(product.ProductName);
            //}

            ProductManager productManager = new ProductManager(new EfProductDal());

            foreach (var product in productManager.GetAll())
            {
                Console.WriteLine(product.ProductName);
            }

            Console.WriteLine("#############################");

            foreach (var product in productManager.GetByUnitPrice(50,300).OrderBy(product => product.UnitPrice))
            {
                Console.WriteLine("Product Name : " + product.ProductName + " Price : " + product.UnitPrice);
            }
        }
    }
}