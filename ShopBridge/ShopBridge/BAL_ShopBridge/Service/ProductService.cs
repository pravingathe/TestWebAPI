using DAL_ShopBridge.Interface;
using DAL_ShopBridge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL_ShopBridge.Service
{
    public class ProductService
    {
        private readonly IRepository<Product> _Product;

        public ProductService(IRepository<Product> product)
        {
            _Product = product;
        }
        //Get Product Details By Product Id
        public IEnumerable<Product> GetProductByUserId(string Name)
        {
            return _Product.GetAll().Where(x => x.Name == Name).ToList();
        }
        //GET All Perso Details 
        public IEnumerable<Product> GetAllProducts()
        {
            try
            {
                return _Product.GetAll().ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
        //Get Product by Product Name
        public Product GetProductByName(string Name)
        {
            return _Product.GetAll().Where(x => x.Name == Name).FirstOrDefault();
        }
        //Add Product
        public async Task<Product> AddProduct(Product Product)
        {
            return await _Product.Create(Product);
        }
        //Delete Product 
        public bool DeleteProduct(string Name)
        {

            try
            {
                var DataList = _Product.GetAll().Where(x => x.Name == Name).ToList();
                foreach (var item in DataList)
                {
                    _Product.Delete(item);
                }
                return true;
            }
            catch (Exception)
            {
                return true;
            }

        }
        //Update Product Details
        public bool UpdateProduct(Product Product)
        {
            try
            {
                var DataList = _Product.GetAll().Where(x => x.IsDeleted != true).ToList();
                foreach (var item in DataList)
                {
                    _Product.Update(item);
                }
                return true;
            }
            catch (Exception)
            {
                return true;
            }
        }
    }
}