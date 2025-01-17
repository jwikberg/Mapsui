﻿using System.IO;
using System.Threading.Tasks;
using BruTile.MbTiles;
using Mapsui.Samples.Common.Utilities;
using Mapsui.Tiling.Layers;
using Mapsui.UI;
using SQLite;

namespace Mapsui.Samples.Common.Maps
{
    public class MbTilesSample : ISample
    {
        static MbTilesSample()
        {
            MbTilesDeployer.CopyEmbeddedResourceToFile("world.mbtiles");
        }

        public string Name => "1 MbTiles";
        public string Category => "Data";

        public static Map CreateMap()
        {
            var map = new Map();
            map.Layers.Add(CreateMbTilesLayer(Path.GetFullPath(Path.Combine(MbTilesDeployer.MbTilesLocation, "world.mbtiles")), "regular"));
            return map;
        }
    
        public Task<Map> CreateMapAsync()
        {
            return Task.FromResult(CreateMap());
        }

        public static TileLayer CreateMbTilesLayer(string path, string name)
        {
            var mbTilesTileSource = new MbTilesTileSource(new SQLiteConnectionString(path, true));
            var mbTilesLayer = new TileLayer(mbTilesTileSource) { Name = name };
            return mbTilesLayer;
        }
    }
}