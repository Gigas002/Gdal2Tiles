﻿using System;
using System.IO;
using System.Linq;
using GTiff2Tiles.Core.Localization;

namespace GTiff2Tiles.Core.Helpers
{
    /// <summary>
    /// Class with static methods for check the errors.
    /// </summary>
    public static class CheckHelper
    {
        #region Methods

        #region Private

        /// <summary>
        /// Check GdalInfo's string.
        /// Block - if image is tiled;
        /// Byte - type;
        /// </summary>
        /// <param name="gdalInfoString">String from <see cref="Image.Gdal.Info"/> method.</param>
        /// <param name="proj4String">Proj4 string.</param>
        /// <returns><see langword="true"/>, if file is OK, <see langword="false"/> otherwise.</returns>
        private static bool CheckTifInfo(string gdalInfoString, string proj4String)
        {
            if (string.IsNullOrWhiteSpace(gdalInfoString))
                throw new Exception(string.Format(Strings.StringIsEmpty, nameof(gdalInfoString)));

            //Check projection.
            if (!proj4String.Contains(Enums.Image.Gdal.LongLat) || !proj4String.Contains(Enums.Image.Gdal.Wgs84))
                return false;

            //Other checks.
            return gdalInfoString.Contains(Enums.Image.Gdal.Block) && gdalInfoString.Contains(Enums.Image.Gdal.Byte);
        }

        #endregion

        #region Internal

        /// <summary>
        /// Checks, if file's path is not empty string and file exists, if it should.
        /// </summary>
        /// <param name="fileInfo">File to check.</param>
        /// <param name="shouldExist">Should it exist?</param>
        /// <param name="fileExtension">Checks file extension.</param>
        internal static void CheckFile(FileInfo fileInfo, bool shouldExist, string fileExtension = null)
        {
            //Update file state.
            fileInfo.Refresh();

            //Check file's path.
            if (string.IsNullOrWhiteSpace(fileInfo.FullName))
            {
                throw new Exception(string.Format(Strings.StringIsEmpty,
                                                  nameof(fileInfo.FullName)));
            }

            //Check file's extension.
            if (!string.IsNullOrWhiteSpace(fileExtension))
            {
                if (fileInfo.Extension != fileExtension)
                    throw new Exception(string.Format(Strings.WrongExtension, nameof(fileInfo),
                                                      fileExtension, fileInfo.FullName));
            }

            //Check file's existance.
            if (shouldExist)
            {
                if (!fileInfo.Exists)
                    throw new Exception(string.Format(Strings.DoesntExist,
                                                      nameof(fileInfo), fileInfo.FullName));
            }
            else if (fileInfo.Exists)
                throw new Exception(string.Format(Strings.AlreadyExists,
                                                  nameof(fileInfo), fileInfo.FullName));
        }

        #endregion

        #region Public

        /// <summary>
        /// Checks, if directory's path is not empty, creates directory if it doesn't exist
        /// and checks if it's empty or not.
        /// </summary>
        /// <param name="directoryInfo">Directory to check.</param>
        /// <param name="shouldBeEmpty">Should it be empty?
        /// <para/>If set <see keyword="null"/>, emptyness doesn't check.</param>
        public static void CheckDirectory(DirectoryInfo directoryInfo, bool? shouldBeEmpty = null)
        {
            //Check directory's path.
            if (string.IsNullOrWhiteSpace(directoryInfo.FullName))
                throw new Exception(string.Format(Strings.StringIsEmpty,
                                                  nameof(directoryInfo.FullName)));

            //Try to create directory.
            directoryInfo.Create();
            directoryInfo.Refresh();

            //Check directory's emptyness.
            if (shouldBeEmpty == true)
            {
                if (directoryInfo.EnumerateFileSystemInfos().Any())
                    throw new Exception(string.Format(Strings.DirectoryIsntEmpty,
                                                      directoryInfo.FullName));
            }
            else if (shouldBeEmpty == false)
            {
                if (!directoryInfo.EnumerateFileSystemInfos().Any())
                    throw new Exception(string.Format(Strings.DirectoryIsEmpty,
                                                      directoryInfo.FullName));
            }
        }

        /// <summary>
        /// Checks the existance, projection, block and byte.
        /// </summary>
        /// <param name="inputFileInfo">Input file.</param>
        /// <returns><see langword="true"/> if no errors in input file, <see langword="false"/> otherwise.</returns>
        public static bool CheckInputFile(FileInfo inputFileInfo)
        {
            CheckFile(inputFileInfo, true, Enums.Extensions.Tif);

            //Get proj4 string.
            string proj4String = Image.Gdal.GetProj4String(inputFileInfo);

            //Check if input image is ready for cropping.
            return CheckTifInfo(Image.Gdal.Info(inputFileInfo), proj4String);
        }

        #endregion

        #endregion
    }
}
