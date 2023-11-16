using _01_Exercise.Interfaces;
using _01_Exercise.Services;

namespace TestProject.Tests.UnitTests;

// Test för att se om fil kan skapas eller ej. 
public class FileManager_UnitTests
{
    [Fact]
    public void SaveToFile_Should_ReturnFalse_WhenFileNotCreated()
    {
        IFileManager fileManager = new FileManager();
        string filePath = @"c:\fakepath\fakefile.txt";
        string content = "testing";

        var result = fileManager.SaveToFile(filePath, content);

        Assert.False(result);

    }
}
