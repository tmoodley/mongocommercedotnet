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
    public class OrderService
    {
        
        private readonly MongoHelper<Orders> _order;
        public OrderService()
        {
            _order = new MongoHelper<Orders>();
        }

         public void Create(Orders order)
        { 
            _order.Collection.Insert(order);
        }


         public IList<Orders> GetOrders()
        {
            try
            {
                return _order.Collection.FindAll().ToList<Orders>();
            }
            catch (MongoConnectionException)
            {
                return new List<Orders>();
            }
        }

         public IList<Orders> GetOrdersByWebstoreId(int Id)
         {
             try
             {
                 return _order.Collection.Find(Query.EQ("webstore_id", Id)).ToList<Orders>();
                  
             }
             catch (MongoConnectionException)
             {
                 return new List<Orders>();//
             }
         }

         public IList<Orders> GetOrdersByCustomerId(int Id)
         {
             try
             {
                 return _order.Collection.Find(Query.EQ("CustomerID", Id)).ToList<Orders>();

             }
             catch (MongoConnectionException)
             {
                 return new List<Orders>();
             }
         }

         public Orders GetOrders(string name)
        {
            var post = _order.Collection.Find(Query.EQ("Name", name)).Single(); 
            return post;
        }

         public Orders GetOrder(Guid Id)
         { 
             seoWebApplication.Models.Orders query = (from e in _order.Collection.AsQueryable<Orders>()
                                                        where e.Id == Id
                                                        select e).First();

             return query;
         }
    }
}