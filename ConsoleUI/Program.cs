using System.ComponentModel.Design;
using Business.Abstract;
using System.Runtime.InteropServices;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

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

            ProductTest2();
            //Console.WriteLine("#############################");
            //ProductTest();
            //Console.WriteLine("#############################");
            //CategoryTest();



            void ProductTest()
            {
                ProductManager productManager = new ProductManager(new EfProductDal());

                foreach (var product in productManager.GetByUnitPrice(50, 300).Data.OrderBy(product => product.UnitPrice))
                {
                    Console.WriteLine("Product Name : " + product.ProductName + " Price : " + product.UnitPrice);
                }
            }

            void ProductTest2()
            {
                ProductManager productManager = new ProductManager(new EfProductDal());

                var result = productManager.GetProductDetail();

                if (result.IsSuccess)
                {
                    foreach (var product in result.Data)
                    {
                        Console.WriteLine(product.ProductName + " / " + product.CategoryName);
                    }
                }
                else
                {
                    Console.WriteLine(result.Message);
                }

                
            }

            void CategoryTest()
            {
                CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());

                foreach (var category in categoryManager.GetAll())
                {
                    Console.WriteLine(category.CategoryName);
                }


                Console.WriteLine(categoryManager.GetById(4).CategoryName);
            }
        }
    }
}