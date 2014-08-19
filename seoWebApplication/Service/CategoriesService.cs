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
    public class CategoriesService
    {
         private readonly MongoHelper<Categories> _categories;
         public CategoriesService()
        {
            _categories = new MongoHelper<Categories>();
        }

         public void Create(Categories categories)
        {
            _categories.Collection.Insert(categories);
        }


         public IList<Categories> GetCategories()
        {
            try
            {
                return _categories.Collection.FindAll().ToList<Categories>();
            }
            catch (MongoConnectionException)
            {
                return new List<Categories>();
            }
        }

         public IList<Categories> GetCategoriesById(int Id)
         {
             try
             {
                 return _categories.Collection.Find(Query.EQ("department_id", Id)).ToList<Categories>();
                  
             }
             catch (MongoConnectionException)
             {
                 return new List<Categories>();
             }
         }

         public Categories GetCategories(string name)
        {
            var post = _categories.Collection.Find(Query.EQ("Name", name)).Single();  
            return post;
        }
    }
}