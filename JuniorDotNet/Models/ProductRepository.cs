using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace JuniorDotNet.Models
{
    public class ProductRepository : IProductRepository
    {
        public IQueryable<Product> Products => DataFile.Products.AsQueryable<Product>();
        public Guid AddProduct(Product product)
        {
            Product newProduct = new Product();
            newProduct.Id = Guid.NewGuid();
            newProduct.Name = product.Name;
            newProduct.Price = product.Price;
            DataFile.Products.Add(newProduct);
            DataFile.UpdateFile();
            return newProduct.Id;
        }

        public ValidationResult UpdateProduct(Guid id, Product newData)
        {
            DataFile.UpdateApp();

            if (newData.Id == null) return new ValidationResult("Id is required");

            DataFile.Products.Where(e => e.Id.Equals(id)).FirstOrDefault().Id = newData.Id;
            DataFile.Products.Where(e => e.Id.Equals(id)).FirstOrDefault().Name = newData.Name;
            DataFile.Products.Where(e => e.Id.Equals(id)).FirstOrDefault().Price = newData.Price;
            DataFile.UpdateFile();
            return ValidationResult.Success;
        }

        public void DeleteProduct(Guid id)
        {
            DataFile.UpdateApp();
            DataFile.Products.Remove(DataFile.Products.Where(e => e.Id.Equals(id)).FirstOrDefault());
            DataFile.UpdateFile();
        }
    }
}
