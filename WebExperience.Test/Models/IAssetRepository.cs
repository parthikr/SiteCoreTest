using GeneralKnowledge.Test.App.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebExperience.Test.Models
{
    public interface IAssetRepository
    {
        IList<Asset> GetAll();
        Asset Get(string id);
        Asset Add(Asset item);
        void Remove(string id);
        bool Update(Asset item);
    }
}