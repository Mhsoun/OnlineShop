using MyShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.DataInMemory
{
    public class ProductCategoryRepository
    {
        ObjectCache cache = MemoryCache.Default;
        List<ProductCategory> productCategories = new List<ProductCategory>();

        public ProductCategoryRepository()
        {
            productCategories = cache["ProductCategories"] as List<ProductCategory>;
            if (productCategories == null)
            {
                productCategories = new List<ProductCategory>();
            }
        }
        public void Commit()
        {
            cache["ProductCategories"] = productCategories;
        }

        public void Insert(ProductCategory p)
        {
            productCategories.Add(p);
        }

        public void Update(ProductCategory ProductCategory)
        {
            ProductCategory productCategoryyToUpdate = productCategories.Find(p => p.Id == ProductCategory.Id);

            if (productCategoryyToUpdate != null)
            {
                productCategoryyToUpdate = ProductCategory;
            }
            else
            {
                throw new Exception("Product not found");
            }
        }
        public ProductCategory Find(string Id)
        {
            ProductCategory ProductCategory = productCategories.Find(p => p.Id == Id);
            if (ProductCategory != null)
            {
                return ProductCategory;
            }
            else
            {
                throw new Exception("Product not found");
            }

        }

        public IQueryable<ProductCategory> Collection()
        {
            return productCategories.AsQueryable();
        }
        public void Delete(String Id)
        {
            ProductCategory productToDelete = productCategories.Find(p => p.Id == Id);

            if (productToDelete != null)
            {
                productCategories.Remove(productToDelete);
            }
            else
            {
                throw new Exception("Product Not Found");
            }
        }
    }
}