using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]  // C# ' ta ATTRIBUTE diyoruz java da karşılığı ANNOTATION ' u karşılar.
    public class ProductsController : ControllerBase
    {
        // Loosely Coupled (Gevşek Bağlılık) : Bir bağımlılığı var ama soyuta bağlıdır. 
        // Yani Servis değişir ve Manager' i değiştirirsek bir problemle karşılaşmayız.
        // IoC Container -- Inversion of Control (Değişimin Kontrolü)

        IProductService _productService;   // Naming convention.

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public List<Product> Get()
        {
            // Burada bir :  Dependency Chain var. --> Yani bağımlılık zinciri.
            
            var result = _productService.GetAll();
            return result.Data;
        }
    }
}
