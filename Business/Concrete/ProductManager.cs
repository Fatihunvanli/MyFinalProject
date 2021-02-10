using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

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
            //business codes eğer öyleyse şöyleyse ekleme işlemini yap
            //try cath de kullanılabilir(exception yönetimi olmalı)
            if (product.ProductName.Length<2)
            {
                //magic strings
                return new ErrorResult(Messages.ProductNameInValid);
            }
            _productDal.Add(product);
            
            return new Result(true,Messages.ProductAdded);
        }

        public IDataResult<List<Product>> GetAll()
        {    //iş kodları
            //yetkisi var mı 

            if (DateTime.Now.Hour == 22)
            {
                return new ErrorResult();
            }

            return new SuccessDataResult<List<Product>>(_productDal.GetAll(),true,"Ürünler listelendi");
        }

        public List<Product> GetAllByCategoryId(int id)
        {
            return _productDal.GetAll(p => p.CategoryId == id);
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
