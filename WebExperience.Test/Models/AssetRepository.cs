using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GeneralKnowledge.Test.App.Tests;
using System.Collections;

namespace WebExperience.Test.Models
{
    public class AssetRepository : IAssetRepository
    {
       static  CsvProcessingTest obj = new CsvProcessingTest();
        static IList<Asset> assets = obj.ReadFile();
        private int _nextId = assets.Count() + 1;
        public Asset Add(Asset asset)
        {
            var assetsList = new List<Asset>();
            if (asset == null)
            {
                throw new ArgumentNullException("asset");
            }
            asset.AssetId = _nextId++.ToString();
            asset.description = "test";
            assetsList.Add(asset);
            obj.WriteFile(assetsList);
            return asset;
        }

        public Asset Get(string id)
        {
            return assets.Where(p => p.AssetId == id).FirstOrDefault();
        }

        public IList<Asset> GetAll()
        {
            return assets;
        }

        public void Remove(string id)
        {
            assets.RemoveAt(Convert.ToInt32(id));
        }

        public bool Update(Asset asset)
        {
            if (asset == null)
            {
                throw new ArgumentNullException("item");
            }
            string index = assets.Where(p => p.AssetId == asset.AssetId).FirstOrDefault().AssetId;
            if (index == null)
            {
                return false;
            }
            assets.RemoveAt(Convert.ToInt32(index));
            assets.Add(asset);
            return true;
        }
    }
}