using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using AutoMapper;
using WebExperience.Test;

namespace WebExperience.Test.Models
{
    public class AssetRepository : IAssetRepository
    {
       static  AssetDBEntities dbContext = new AssetDBEntities();
     //  static  CsvProcessingTest obj = new CsvProcessingTest();
       // static IList<Asset> assets = obj.ReadFile();
       // private static int _nextId = dbContext.assets.Count() + 1;
        public asset Add(asset assetDTO)
        {
            // var config = new MapperConfiguration(cfg => cfg.CreateMap<Asset, asset>()
            //.ForMember(dest => dest.AssetId, act => act.MapFrom(src => src.AssetId)));
            // var mapper = new Mapper(config);
            // var assetEntity = mapper.Map<asset>(assetDTO);
            assetDTO.AssetId = Guid.NewGuid().ToString();
            dbContext.assets.Add(assetDTO);
            dbContext.SaveChanges();
            return assetDTO;
        }

        public asset Get(string id)
        {
            return dbContext.assets.Where(p => p.AssetId == id).FirstOrDefault();
        }

        public IList<asset> GetAll()
        {
            //limited to 100 records for demo performance
            return dbContext.assets.ToList().Take(50).ToList();
        }

        public asset Remove(string id)
        {
            var assetRem = dbContext.assets.Where(p => p.AssetId == id).FirstOrDefault();
            dbContext.assets.Remove(assetRem);
            dbContext.SaveChanges();
            return assetRem;
        }

        public asset Update(asset asset)
        {
            if (asset == null)
            {
                throw new ArgumentNullException("asset");
            }
            var assetUpdate = dbContext.assets.Where(p => p.AssetId == asset.AssetId).FirstOrDefault();
            if (assetUpdate == null)
            {
                throw new ArgumentNullException("asset");
            }
            // assets.RemoveAt(Convert.ToInt32(index));
            dbContext.assets.Remove(assetUpdate);
            dbContext.assets.Add(asset);
            dbContext.SaveChanges();
            return asset;
        }
    }
}