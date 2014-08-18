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
    public class DepartmentService
    {
         private readonly MongoHelper<Departments> _departments;
         public DepartmentService()
        {
            _departments = new MongoHelper<Departments>();
        }

         public void Create(Departments departments)
        {
            _departments.Collection.Insert(departments);
        }
        

         public IList<Departments> GetDepartments()
        {
            try
            {
                return _departments.Collection.FindAll().ToList<Departments>();
            }
            catch (MongoConnectionException)
            {
                return new List<Departments>();
            }
        }

         public IList<Departments> GetDepartmentsById(int Id)
         {
             try
             {
                 return _departments.Collection.Find(Query.EQ("webstore_id", Id)).ToList<Departments>();
                  
             }
             catch (MongoConnectionException)
             {
                 return new List<Departments>();
             }
         }

         public Departments GetDepartmentst(string name)
        {
            var post = _departments.Collection.Find(Query.EQ("Name", name)).Single();
            //post.Comments = post.Comments.OrderByDescending(c => c.Date).ToList();
            return post;
        }
    }
}