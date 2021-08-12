using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using WebExperience.Test.Models;
using System.Web.Http.Cors;

namespace WebExperience.Test.Controllers
{
    [RoutePrefix("api/asset")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
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
        [Route("AllAsset")]
        public IList<asset> GetAllAsset()
        {
            var allData = repository.GetAll();
            return allData;
        }
        [HttpGet]
        [Route("FindAsset")]
        public asset GetAsset(string id)
        {
            asset asset = repository.Get(id);
            if (asset == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return asset;
        }
        [HttpPost]
        [Route("SaveAsset")]
        public asset PostAsset(asset asset)
        {
            asset = repository.Add(asset);
            return asset;
        }
        [HttpPut]
        [Route("UpdateAsset")]
        public asset PutAsset( asset asset)
        {
           // asset.AssetId = id;
            if (repository.Update(asset)==null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return asset;
        }
        [HttpDelete]
        [Route("Delete")]
        public asset DeleteAsset(string id)
        {
            return  repository.Remove(id);
        }
    }
}
