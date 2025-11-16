using Xunit;

namespace AchParser.Tests;

public class AchFileParserTests
{
    // Tests for ParseFile

    // Tests for ParseFileHeader
    [Fact]
    public void ParseFileHeader_ValidHeader_ReturnsExpectedResult()
    {
        // Arrange
        var parser = new AchFileParser();
        string headerLine = "101 123456789 9876543212001010000A094101Bank Name         Bank Name         ";
        
        // Act
        var result = parser.ParseFileHeader(headerLine);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("123456789", result.ImmediateDestination);
        Assert.Equal("987654321", result.ImmediateOrigin);
        Assert.Equal("200101", result.FileCreationDate);
        Assert.Equal("0000", result.FileCreationTime);
        Assert.Equal("Bank Name", result.ImmediateDestinationName.Trim());
        Assert.Equal("Bank Name", result.ImmediateOriginName.Trim());
    }

    [Fact]
    public void ParseFileHeader_InvalidHeader_ThrowsFormatException()
    {
        // Arrange
        var parser = new AchFileParser();
        string invalidHeaderLine = "INVALID_HEADER";

        // Act and Assert
        Assert.Throws<FormatException>(() => parser.ParseFileHeader(invalidHeaderLine))
    }

    [Fact]
    public void ParseFileHeader_NullHeader_ThrowsArgumentNullException()
    {
        // Arrange
        var parser = new AchFileParser();

        // Act and Assert
        Assert.Throws<ArgumentNullException>(() => parser.ParseFileHeader(null));
    }

    // Tests for ParseBatchHeader

    // Tests for ParseEntryDetail

    // Tests for ParseAddenda

    // Tests for ParseBatchContrl

    // Tests for ParseFileControl
}