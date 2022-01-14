using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public IResult Add(Product product)
        {
            // Business Codes.
            
            if(product.ProductName.Length < 2)
            {
                // Magic Strings bunlardan kurtulmalıyız. Büyüyen projelerde sorun ve karmaşa haline gelir
                // O yüzden Bussines katmanında standart hale getirir ve temiz bir kod yazarız. Constants klasörü oluşturulur.
                // Constants : Sabitler anlamına gelir ve projenin sabitleri bu klasöre tanımlanır.
                return new ErrorResult(Messages.ProductNameInvalid);
            }

            _productDal.Add(product);

            return new SuccessResult(Messages.ProductAdded);
        }

        public IDataResult<List<Product>> GetAll() 
        {
            // İş Kodları Buraya Yazılır.
            // Yetkisi var mı? İzinlerin sorgulaması burada yapılır!
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorResult();
            }

            return new SuccessDataResult<List<Product>>(_productDal.GetAll(),true,"Ürünler Listelendi");

        }

        public List<Product> GetAllByCategoryId(int id)
        {
            return _productDal.GetAll( p => p.CategoryId == id);
        }

        public Product GetById(int productId)
        {
            return _productDal.Get(p => p.ProductId == productId);
        }

        public List<Product> GetByUnitPrice(decimal min, decimal max)
        {
            return _productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max);
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            return _productDal.GetProductDetails();
        }
    }
}
