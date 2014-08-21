using MongoDB.Driver;
using MongoDB.Driver.Builders;
using seoWebApplication.DAL;
using seoWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace seoWebApplication.Service
{
    public class ProductService
    {
        private readonly MongoHelper<Products> _product;
         public ProductService()
        {
            _product = new MongoHelper<Products>();
        }

         public void Create(Products product)
        {
            _product.Collection.Insert(product);
        }


         public IList<Products> GetProducts()
        {
            try
            {
                return _product.Collection.FindAll().ToList<Products>();
            }
            catch (MongoConnectionException)
            {
                return new List<Products>();
            }
        }

         public IList<Products> GetProductsByDepartment(int Id)
         {
             try
             {
                 return _product.Collection.Find(Query.EQ("department_id", Id)).ToList<Products>();
                  
             }
             catch (MongoConnectionException)
             {
                 return new List<Products>();//
             }
         }

         public IList<Products> GetProductsByCategory(int Id)
         {
             try
             {
                 return _product.Collection.Find(Query.EQ("category_id", Id)).ToList<Products>();

             }
             catch (MongoConnectionException)
             {
                 return new List<Products>();
             }
         }

         public Products GetProducts(string name)
        {
            var post = _product.Collection.Find(Query.EQ("Name", name)).Single(); 
            return post;
        }

         public Products GetProduct(string Id)
         {
             var post = _product.Collection.Find(Query.EQ("product_id", Id)).Single();
             return post;
         }
    }
}