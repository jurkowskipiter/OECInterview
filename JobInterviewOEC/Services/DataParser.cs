using JobInterviewOEC.Configuration;
using System.Linq;

namespace JobInterviewOEC
{
    class DataParser : IDataParser
    {
        private readonly IAtlasFileConfiguration _atlasFileConfiguration;
        
        public DataParser(IAtlasFileConfiguration atlasDataLength)
        {
            _atlasFileConfiguration = atlasDataLength;
        }

        public string GetParsedParameter(string parameterName, string lineToRead)
        {
            var skipValue = GetParameterPosition(parameterName);
            var takeValue = GetParameterLength(parameterName);
            var parameterToReturn = string.Join("", lineToRead
                .Skip(skipValue)
                .Take(takeValue));

            return parameterToReturn;
        }

        private int GetParameterPosition(string parameterName)
        {
            var parameterIndex = _atlasFileConfiguration.ParametersLength.Keys.ToList().IndexOf(parameterName);
            var parameterPosition = 0;
            for (int i = 0; i < parameterIndex; i++)
            {
                parameterPosition += _atlasFileConfiguration.ParametersLength.ElementAt(i).Value;
            }

            return parameterPosition;
        }

        private int GetParameterLength(string parameterName)
        {
            return _atlasFileConfiguration.ParametersLength[parameterName];
        }
    }
}
