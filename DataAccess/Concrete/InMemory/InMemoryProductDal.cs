using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;

        public InMemoryProductDal()
        {  
            // Databaseden Geliyormuş gibi simule ediyoruz.

            _products = new List<Product>
            {
                new Product{ProductId = 1, CategoryId = 1, ProductName = "Laptop", UnitPrice = 500, UnitsInStock = 50 },
                new Product{ProductId = 2, CategoryId = 3, ProductName = "Phone", UnitPrice = 800, UnitsInStock = 40 },
                new Product{ProductId = 3, CategoryId = 2, ProductName = "Keyboard", UnitPrice = 50, UnitsInStock = 200 },
                new Product{ProductId = 4, CategoryId = 2, ProductName = "Mouse", UnitPrice = 20, UnitsInStock = 300 },
                new Product{ProductId = 5, CategoryId = 2, ProductName = "Monitor", UnitPrice = 200, UnitsInStock = 100 }
            };
        }

        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            Product productToDelete = null;

            // Alternatif (Çok Kötü) Kullanım

            //  foreach (var p in _products)
            //  {
            //      if (product.ProductId == p.ProductId)
            //      {
            //          productToDelete = p;
            //      }
            //  }
            //  _products.Remove(productToDelete);

            // Bu Problemi LİNQ - Language Integrated Query İle Çok Daha Rahat Çözeriz.

            // Lambda -- C# dilinde lambda ifadeleri, kısa ve öz bir şekilde işlevsellik eklemek için kullanılan bir özelliktir.
            // Lambda ifadeleri, genellikle anonim (isimsiz) fonksiyonlar oluşturmak ve bu fonksiyonları bir değişkene atamak veya başka bir fonksiyonun içinde kullanmak için kullanılır.

            productToDelete = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
                                        // Bu kısım yukardaki foreachın işlevini yapıyor.

            _products.Remove(productToDelete);
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(p => p.CategoryId == categoryId).ToList();
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public void Update(Product product)
        {
            // Gönderdiğim ürün idsine sahip, listedeki ürünü bul.
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            return _products;
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<ProductDetailDto> getProductDetails()
        {
            throw new NotImplementedException();
        }
    }
}
