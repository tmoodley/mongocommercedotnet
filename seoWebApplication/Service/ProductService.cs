using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.Linq;
using seoWebApplication.DAL;
using seoWebApplication.Models;
using seoWebApplication.st.SharkTankDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace seoWebApplication.Service
{
    public class ProductService
    {

        private readonly MongoHelper<mProducts> _product;
        public ProductService()
        {
            _product = new MongoHelper<mProducts>();
        }

        public void Create(mProducts product)
        {
            product.product_id = GetLastId();
            product.webstore_id = dBHelper.GetWebstoreId();
            _product.Collection.Insert(product);
        }


        public IList<mProducts> GetProducts()
        {
            try
            {
                int Id = dBHelper.GetWebstoreId();
                return _product.Collection.Find(Query.EQ("webstore_id", Id)).ToList<mProducts>();
            }
            catch (MongoConnectionException)
            {
                return new List<mProducts>();
            }
        }

        public IList<mProducts> GetProductsByDepartment(int Id)
        {
            try
            {
                return _product.Collection.Find(Query.EQ("department_id", Id)).ToList<mProducts>();

            }
            catch (MongoConnectionException)
            {
                return new List<mProducts>();//
            }
        }



        public IList<mProducts> GetProductsOnFrontPromo()
        {
            try
            {
                var query = Query.And(
                                      Query<mProducts>.EQ(e => e.promofront, true),
                                      Query<mProducts>.EQ(e => e.webstore_id, dBHelper.GetWebstoreId())
                                  );
                return _product.Collection.Find(query).ToList<mProducts>();

            }
            catch (MongoConnectionException)
            {
                return new List<mProducts>();
            }
        }

        public IList<mProducts> GetProductsByCategory(int Id)
        {
            try
            { 
                return _product.Collection.Find(Query.EQ("category_id", Id)).ToList<mProducts>();

            }
            catch (MongoConnectionException)
            {
                return new List<mProducts>();
            }
        }

        public mProducts GetProducts(string name)
        {
            var post = _product.Collection.Find(Query.EQ("Name", name)).Single();
            return post;
        }

        public mProducts GetProduct(int Id)
        {
            int _Id = Convert.ToInt32(Id);
            seoWebApplication.Models.mProducts query = (from e in _product.Collection.AsQueryable<mProducts>()
                                                       where e.product_id == _Id
                                                       select e).First();

            return query;
        }

        public int GetLastId()
        {
            try
            {
                var query = (from d in GetProducts() orderby d.product_id ascending select d).First();

                return query.product_id + 1;
            }
            catch
            {
                return 1;
            }


        }


        internal void ProductThumbnailUpdate(int productid, int webstoreid, string fileName)
        {
            try
            {
                var query = Query.And(
                                        Query<mProducts>.EQ(e => e.product_id, productid),
                                        Query<mProducts>.EQ(e => e.webstore_id, webstoreid) 
                                    );

                var update = Update<mProducts>.Set(e => e.thumbnail, fileName);

                _product.Collection.Update(query, update); 
            }
            catch
            { 
            } 
        }

        internal void ProductImageUpdate(int productid, int webstoreid, string fileName)
        {
            try
            {
                var query = Query.And(
                                        Query<mProducts>.EQ(e => e.product_id, productid),
                                        Query<mProducts>.EQ(e => e.webstore_id, webstoreid)
                                    );

                var update = Update<mProducts>.Set(e => e.image, fileName);

                _product.Collection.Update(query, update);
            }
            catch
            {
            }
        }

        internal IList<mAttribute> GetProductAttributes(int Id)
        {
            if (Id > 0)
            {
                mProducts query = (from e in _product.Collection.AsQueryable<mProducts>()
                                   where e.product_id == Id
                                   select e).Single();

                return query.Attributes;
            }
            else {
                return null;
            }
           
        }

        internal IList<Categories> ProductCategorySelect(int Id)
        {
            if (Id > 0)
            {
                mProducts query = (from e in _product.Collection.AsQueryable<mProducts>()
                                   where e.product_id == Id
                                   select e).Single();

                return query.Categories;
            }
            else {
                return null;
            }
            
        }

        internal void AddProductToCategory(int productid, int categoryid)
        {
            try
            {
                var query =  Query<mProducts>.EQ(e => e.product_id, productid);

                IList<Categories> cat = GetProduct(productid).Categories;
                Categories category = new Categories();
                category.category_id = categoryid;
                cat.Add(category);
                var update = Update<mProducts>.Set(e => e.Categories, cat);

                _product.Collection.Update(query, update);
            }
            catch
            {
            }
        }
        
    }
}