using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using seoWebApplication.st.SharkTankDAL.dataObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace seoWebApplication.Models
{
    public class Orders : OrdersEO
    {
        [BsonId(IdGenerator = typeof(CombGuidGenerator))]
        public Guid Id { get; set; }
 
    }
}