namespace JobInterviewOEC
{
    internal interface IDataParser
    {
        string GetParsedParameter(string parameterName, string lineToRead);
    }
}