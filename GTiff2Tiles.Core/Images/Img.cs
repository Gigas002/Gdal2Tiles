﻿using System;
using System.IO;
using System.Threading.Tasks;
using GTiff2Tiles.Core.Constants;
using GTiff2Tiles.Core.Enums.Image;

namespace GTiff2Tiles.Core.Images
{
    /// <summary>
    /// Example of class to use <see cref="IImage"/> interface.
    /// </summary>
    public static class Img
    {
        /// <summary>
        /// Example of method to use <see cref="IImage"/> interface for cropping the tiles.
        /// </summary>
        /// <param name="inputFileInfo">Input GeoTIFF.</param>
        /// <param name="outputDirectoryInfo">Directory for cropped tiles.</param>
        /// <param name="minZ">Minimum cropped zoom.</param>
        /// <param name="maxZ">Maximum cropped zoom.</param>
        /// <param name="tileType">Type of tiles to create.</param>
        /// <param name="tmsCompatible">Are tiles compatible with tms?</param>
        /// <param name="tileExtension">Extension of ready tiles.</param>
        /// <param name="progress">Progress.</param>
        /// <param name="threadsCount">Threads count.</param>
        /// <returns></returns>
        public static async ValueTask GenerateTilesAsync(FileInfo inputFileInfo, DirectoryInfo outputDirectoryInfo,
                                                         int minZ, int maxZ, TileType tileType,
                                                         bool tmsCompatible = true,
                                                         TileExtension tileExtension = TileExtension.Png,
                                                         IProgress<double> progress = null,
                                                         int threadsCount = 5)
        {
            //This is example.
            //TODO: Better exception-handling
            await using IImage image = tileType switch
            {
                TileType.Raster => new Raster(inputFileInfo),
                //TileType.Terrain => new Image(inputFileInfo),
                _ => throw new Exception()
            };

            string tileExtensionString = tileExtension switch
            {
                TileExtension.Png => Extensions.Png,
                TileExtension.Jpg => Extensions.Jpg,
                TileExtension.Webp => Extensions.Webp,
                _ => throw new ArgumentOutOfRangeException(nameof(tileExtension), tileExtension, null)
            };

            //TODO: args
            //Generate tiles.
            Size size = new Size(Constants.Image.Raster.TileSize, Constants.Image.Raster.TileSize);
            await image.WriteTilesToDirectoryAsync(outputDirectoryInfo, minZ, maxZ, size, tmsCompatible, tileExtensionString, 4, progress,
                                           threadsCount, false).ConfigureAwait(false);
        }
    }
}