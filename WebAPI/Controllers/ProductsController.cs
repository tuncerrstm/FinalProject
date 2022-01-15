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

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            // Swagger : Hazır dökümantasyon imkanı sunar.
            // Burada bir :  Dependency Chain var. --> Yani bağımlılık zinciri.
            
            var result = _productService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _productService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Product product)
        {
            var result = _productService.Add(product);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
