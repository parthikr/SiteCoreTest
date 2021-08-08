using GeneralKnowledge.Test.App.Tests;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using WebExperience.Test.Models;

namespace WebExperience.Test.Controllers
{
    public class AssetController : ApiController
    {
        // TODO
        // Create an API controller via REST to perform all CRUD operations on the asset objects created as part of the CSV processing test
        // Visualize the assets in a paged overview showing the title and created on field
        // Clicking an asset should navigate the user to a detail page showing all properties
        // Any data repository is permitted
        // Use a client MVVM framework
        IAssetRepository repository;
        public AssetController()
        {
            repository = new AssetRepository();
        }
        [HttpGet]
        public IList<Asset> GetAllAsset()
        {
            return repository.GetAll();
        }
        [HttpGet]
        public Asset GetAsset(string id)
        {
            Asset asset = repository.Get(id);
            if (asset == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return asset;
        }
        [HttpPost]
        public Asset PostAsset(Asset asset)
        {
            asset = repository.Add(asset);
            return asset;
        }
        [HttpPut]
        public void PutAsset(string id, Asset asset)
        {
            asset.AssetId = id;
            if (!repository.Update(asset))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }
    }
}
