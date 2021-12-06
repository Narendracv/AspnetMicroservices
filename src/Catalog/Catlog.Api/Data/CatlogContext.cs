using Catlog.Api.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catlog.Api.Data
{
    public class CatlogContext : ICatlogContext
    {
        public CatlogContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            //Create/Get Existing DB
            var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            var Products = database.GetCollection<Product>(configuration.GetValue<string>("DatabaseSettings:CollectionName"));
            //CatlogContextSeed.SeedData(Products);
        }
        public IMongoCollection<Product> Products { get; }
    }
    
    
}
