namespace _01_Exercise.Interfaces;

// interface till testet
public interface IFileManager
{
    bool SaveToFile(string filePath, string content);

    IEnumerable<string> Messages();
}
