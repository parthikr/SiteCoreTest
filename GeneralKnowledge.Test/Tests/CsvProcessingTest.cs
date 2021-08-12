using CsvHelper;
using Newtonsoft.Json;
using System;
using System.Globalization;
using System.Linq;
using System.IO;
using CsvHelper.Configuration;
using System.Collections.Generic;
using AutoMapper;
using System.Data.Entity.Validation;

namespace GeneralKnowledge.Test.App.Tests
{
    /// <summary>
    /// CSV processing test
    /// </summary>
    public class CsvProcessingTest : ITest
    {
        static string filePath = @"../../Resources/AssetImport.csv";
        static IList<Asset> _assets;
        static AssetDBEntities dbContext = new AssetDBEntities();

        public void Run()
        {
            // TODO
            // Create a domain model via POCO classes to store the data available in the CSV file below
            // Objects to be present in the domain model: Asset, Country and Mime type
            // Process the file in the most robust way possible
            // The use of 3rd party plugins is permitted
            // var csvFile = Resources.AssetStream;

            // var csvReader = new CsvReader(streamReader, CultureInfo.CurrentCulture);
            // var assets = csvReader.GetRecords<Asset>();
            //foreach (var user in assets)
            //{
            //    Console.WriteLine(user);
            //}

            //var test = assets.Select(x => x.AssetId).ToList();
            var TestAssets = ReadFile();
        }
        public IList<Asset> ReadFile()
        {
            var streamReader = File.OpenText(filePath);
            FileInfo inputFile = new FileInfo(filePath);
            using (var reader = new StreamReader(inputFile.FullName))
            using (var csvReader = new CsvReader(reader, CultureInfo.CurrentCulture))
            {
                csvReader.Configuration.RegisterClassMap<AssetMap>();
                var assetList = csvReader.GetRecords<Asset>().ToList();
                _assets = assetList;
                var config = new MapperConfiguration(cfg => cfg.CreateMap<Asset, asset>()
                            .ForMember(dest => dest.AssetId, act => act.MapFrom(src => src.AssetId)));
                var mapper = new Mapper(config);
                var assetEntity = mapper.Map<List<asset>>(assetList);
                try
                {
                    //uncomment below for db save demo
                    //commented due to lack of duplicate validation 
                   // dbContext.assets.RemoveRange(assetEntity);
                    //dbContext.assets.AddRange(assetEntity);
                    //dbContext.SaveChanges();
                }
                catch (Exception e)
                {
                   
                    throw e;
                }
            }
            return _assets;
        }

        public void WriteFile(List<Asset> data)
        {
            FileInfo toFile = new FileInfo(filePath);
            using (var writer = new StreamWriter(toFile.FullName))
            using (var csvWriter = new CsvWriter(writer, CultureInfo.CurrentCulture))
            {
                csvWriter.Configuration.RegisterClassMap<ClassMap>();
                csvWriter.WriteRecords(data);
            }
        }

    }
    public class Asset
    {
        [JsonProperty("asset id")]
        public string AssetId { get; set; }
        public string file_name { get; set; }
        public string mime_type { get; set; }
        public string created_by { get; set; }
        public string email { get; set; }
        public string country { get; set; }
        public string description { get; set; }
    }
    public class AssetMap : ClassMap<Asset>
    {
        public AssetMap()
        {
            Map(l => l.AssetId).Name("asset id");
            Map(l => l.file_name).Name("file_name");
            Map(l => l.mime_type).Name("mime_type");
            Map(l => l.created_by).Name("created_by");
            Map(l => l.email).Name("email");
            Map(l => l.country).Name("country");
            Map(l => l.description).Name("description");
        }
    }
}
