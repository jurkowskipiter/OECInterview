using JobInterviewOEC.Configuration;
using System;

namespace JobInterviewOEC
{
    class FileReader : IFileReader
    {
        private readonly IAtlasFileConfiguration _atlasFileConfiguration;

        public FileReader(IAtlasFileConfiguration atlasFileConfiguration)
        {
            _atlasFileConfiguration = atlasFileConfiguration;
        }

        public string[] ReadLinesFromFile()
        {
            try
            {
                return System.IO.File.ReadAllLines(_atlasFileConfiguration.FilePath);

            }
            catch (Exception e)
            {
                return new string[] { "Error - file not found" };
            }
        }
    }
}
