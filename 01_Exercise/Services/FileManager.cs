using _01_Exercise.Interfaces;

namespace _01_Exercise.Services;

// interface för filhantering till testet 
public class FileManager : IFileManager
{
    public IEnumerable<string> Messages()
    {
        throw new NotImplementedException();
    }

    public bool SaveToFile(string filePath, string content)
    {
        try
        {
            using StreamWriter sw = new StreamWriter(filePath);
            sw.WriteLine(content);
            return true;
        }
        catch 
        {
            return false;
        }
    }

    bool IFileManager.SaveToFile(string filePath, string content)
    {
        throw new NotImplementedException();
    }
}
