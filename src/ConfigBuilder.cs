using System.Collections.Generic;

internal class CommandArgsBuilder
{
    internal CommandArgsBuilder()
    {
        _argsList = new List<string>();
    }

    private List<string> _argsList { get; }

    internal void AddCommandLine(string arg)
    {
        _argsList.Add(arg);
    }

    internal string Build()
    {
        return string.Join(" ", _argsList.ToArray());
    }
}