namespace Resources
{
    public interface INamingStorage
    {
        string PreffixToParameter { get; set; }

        string ParameterName { get; set; }

        string SuffixToParameter { get; set; }

        string TypeOfDataParameter { get; set; }
        
    }
}