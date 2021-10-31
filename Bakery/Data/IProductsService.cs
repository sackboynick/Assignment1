using System.Collections.Generic;
using Bakery.Models;

namespace Bakery.Data
{
    public interface IProductsService
    {
        public IList<Product> Products { get; } 
    }
}