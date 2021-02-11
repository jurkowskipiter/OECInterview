using System.Collections.Generic;

namespace JobInterviewOEC.Configuration
{
    public interface IAtlasFileConfiguration
    {
        IReadOnlyDictionary<string, int> ParametersLength { get; }
        string FilePath { get; }
    }
}
