using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace JuniorDotNet.Models
{
    public interface IProductRepository
    {
        IQueryable<Product> Products { get; }
        Guid AddProduct(Product product);
        ValidationResult UpdateProduct(Guid id, Product newData);
        void DeleteProduct(Guid id);
    }
}
