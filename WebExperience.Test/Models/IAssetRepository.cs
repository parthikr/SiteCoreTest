using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebExperience.Test.Models
{
    public interface IAssetRepository
    {
        IList<asset> GetAll();
        asset Get(string id);
        asset Add(asset item);
        asset Remove(string id);
        asset Update(asset item);
    }
}