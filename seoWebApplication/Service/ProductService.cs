using MongoDB.Driver;
using MongoDB.Driver.Builders; 
using MongoDB.Driver.Linq;
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
             int _Id = Convert.ToInt32(Id);
             seoWebApplication.Models.Products query = (from e in _product.Collection.AsQueryable<Products>()
                                                        where e.product_id == _Id
                                                        select e).First();

             return query;
         }
    }
}