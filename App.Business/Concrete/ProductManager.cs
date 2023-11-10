﻿using App.Business.Abstract;
using App.Business.BusinessAspects.Autofac;
using App.Business.CCS;
using App.Business.Constants;
using App.Business.ValidationRules.FluentValidation;
using App.Core.Aspects.Autofac.Caching;
using App.Core.Aspects.Autofac.Performance;
using App.Core.Aspects.Autofac.Transaction;
using App.Core.Aspects.Autofac.Validation;
using App.Core.CrossCuttingConcerns.Validation;
using App.Core.Utilities.Business;
using App.Core.Utilities.Results;
using App.DataAccess.Abstract;
using App.DataAccess.Concrete.InMemory;
using App.Entities.Concrete;
using App.Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Business.Concrete
{
  public class ProductManager : IProductService
  {
    private readonly IProductDal _productDal;
    private readonly ICategoryService _categoryService;
    //private readonly IValidator<Product> _validator;
    ILogger _logger;
    public ProductManager(IProductDal productDal, ICategoryService categoryService) //IValidator<Product> validator
    {

     
      _productDal = productDal;
      _categoryService = categoryService;
      //_validator = validator;
    }
    [SecuredOperation("product.add,admin")]
    [ValidationAspect(typeof(ProductValidator))]
    [CacheRemoveAspect("IProductService.Get")]
    public IResult Add(Product product)
    {

      IResult  result = BusinessRules.Run(CheckIfProductNameExist(product.ProductName),
      CheckIfProductCountOfCategoryCorrect(product.CategoryId),
      CheckIfCategoryLimitExceded());

      if(result != null)
      {
        return result;
      }

      _productDal.Add(product);

      return new SuccessResult(Messages.ProductAdded);



    }
    [CacheAspect]
    public IDataResult<List<Product>> GetAll()
    {

      if (DateTime.Now.Hour == 22)
      {
        return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
      }
      return new SuccessDataResult<List<Product>>(_productDal.GetAll(), Messages.ProductsListed);
    }
    [CacheAspect]
    public IDataResult<List<Product>> GetAllByCategoryId(int id)
    {
      return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == id));
    }
    [CacheAspect]
    [PerformanceAspect(5)]
    public IDataResult<Product> GetById(int productId)
    {
      return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == productId));
    }

    public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
    {
      return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.UnitPrice <= min && p.UnitPrice >= max));
    }

    public IDataResult<List<ProductDetailDto>> GetProductDetails()
    {
      return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
    }

    [ValidationAspect(typeof(ValidationAspect))]
    [CacheRemoveAspect("IProductService.Get")]
    public IResult Update(Product product)
    {

      throw new NotImplementedException();
    }
    private IResult CheckIfProductCountOfCategoryCorrect(int categoryId)
    {
      var result = _productDal.GetAll(p => p.CategoryId == categoryId).Count;
      if (result >= 10)
      {
        return new ErrorResult(Messages.ProductCountOfCategoryError);
      }

      return new SuccessResult();
    }

    private IResult CheckIfProductNameExist(string productName)
    {
      var result = _productDal.GetAll(p => p.ProductName == productName).Any();
      if (result)
      {
        return new ErrorResult(Messages.ProductNameAlreadyExists);
      }

      return new SuccessResult();
    }


    private IResult CheckIfCategoryLimitExceded()
    {
      var result = _categoryService.GetAll();
      if (result.Data.Count > 15)
      {
        return new ErrorResult(Messages.CategoryLimitExceded);
      }

      return new SuccessResult();
    }
    [TransactionScopeAspect]
    public IResult AddTransactionalTest(Product product)
    {
      throw new NotImplementedException();
    }
  }


}
