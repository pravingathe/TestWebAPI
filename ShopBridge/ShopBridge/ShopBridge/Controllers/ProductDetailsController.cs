using BAL_ShopBridge.Service;
using DAL_ShopBridge.Interface;
using DAL_ShopBridge.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDAspNetCore5WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDetailsController : ControllerBase
    {
        private readonly ProductService _ProductService;

        private readonly IRepository<Product> _Product;

        public ProductDetailsController(IRepository<Product> Product, ProductService ProductService)
        {
            _ProductService = ProductService;
            _Product = Product;

        }
        //Add Product
        [HttpPost("AddProduct")]
        public async Task<Object> AddProduct([FromBody] Product Product)
        {
            try
            {
                await _ProductService.AddProduct(Product);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        //Delete Product
        [HttpDelete("DeleteProduct")]
        public bool DeleteProduct(string UserEmail)
        {
            try
            {
                _ProductService.DeleteProduct(UserEmail);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        //Delete Product
        [HttpPut("UpdateProduct")]
        public bool UpdateProduct(Product Object)
        {
            try
            {
                _ProductService.UpdateProduct(Object);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        //GET All Product by Name
        [HttpGet("GetAllProductByName")]
        public Object GetAllProductByName(string UserEmail)
        {
            var data = _ProductService.GetProductByName(UserEmail);
            var json = JsonConvert.SerializeObject(data, Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                }
            );
            return json;
        }

        //GET All Product
        [HttpGet("GetAllProducts")]
        public Object GetAllProducts()
        {
            var data = _ProductService.GetAllProducts();
            var json = JsonConvert.SerializeObject(data, Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                }
            );
            return json;
        }
    }
}