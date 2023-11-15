using System.Text.RegularExpressions;

namespace Chat_AspnetCore;

public class DotEnv
{
   private static Dictionary<string, string> _envvars;

   public void Load()
   {
        _envvars = new();

        string filename = ".env";

        if(!File.Exists(filename))
            throw new FileNotFoundException(filename);

        string content = File.ReadAllText(filename);

        foreach(string line in content.Split("\n"))
        {
            if(IsNotAComment(line))
                AddVar(line);
        }
   }

   private void AddVar(string line)
   {
        string pattern = @".*(=).*";

        var regex = new Regex(pattern);

        var match = regex.Match(line);

        if(match.Success)
        {
            string[] keyvalue = line.Split("=");

            _envvars[keyvalue[0]] = keyvalue[1];

            Environment.SetEnvironmentVariable(keyvalue[0], keyvalue[1]);
        }
   }

   private bool IsNotAComment(string line)
   {
        string pattern = @"^[#]";

        var regex = new Regex(pattern);

        var match = regex.Match(line);

        return !match.Success;
   }

   public string Get(string key)
   {
        if(_envvars.Keys.Contains(key))
            return _envvars[key];

        return Environment.GetEnvironmentVariable(key)
            ?? "";
   }
}