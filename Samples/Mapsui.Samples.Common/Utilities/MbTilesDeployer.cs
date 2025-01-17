﻿using System;
using System.IO;
using System.Reflection;
using Mapsui.Samples.Common.Extensions;
using Mapsui.Samples.Common.Maps;

namespace Mapsui.Samples.Common.Utilities
{
    public static class MbTilesDeployer
    {
        public static string MbTilesLocation { get; set; } =  Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Mapsui.Samples");

        public static void CopyEmbeddedResourceToFile(string fileName)
        {
            var assembly = typeof(PointsSample).GetTypeInfo().Assembly;
            assembly.CopyEmbeddedResourceToFile(@"Mapsui.Samples.Common.EmbeddedResources.", MbTilesLocation, fileName);
        }
    }
}
