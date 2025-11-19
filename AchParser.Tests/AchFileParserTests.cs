using Xunit;
using System.Collections.Generic;
using System.IO;

namespace AchParser.Tests;

public class AchFileParserTests
{
    [Fact]
    public void ParseFile_ValidAchFile_ReturnsExpectedAchFile()
    {
        var parser = new AchFileParser();
        var testFilePath =  "/home/snyderjd/Workspace/FinancialSoftware/AchParser/AchParser/SampleAchFiles/consumer_billing.txt";
        
        var result = parser.ParseFile(testFilePath);

        Assert.NotNull(result);
        Assert.NotNull(result.FileHeader);
        Assert.Equal("026009593", result.FileHeader.ImmediateDestination);
        Assert.Equal("026009593", result.FileHeader.ImmediateOrigin);
        Assert.Equal("230113", result.FileHeader.FileCreationDate);
        Assert.Equal("0000", result.FileHeader.FileCreationTime);
        Assert.Equal("Bank Of America", result.FileHeader.ImmediateDestinationName);
        Assert.Equal("Bank Of America", result.FileHeader.ImmediateOriginName);
        Assert.NotNull(result.Batches);
        Assert.Single(result.Batches);
        
        var batch = result.Batches[0];
        
        Assert.NotNull(batch.BatchHeader);
        Assert.Equal("200", batch.BatchHeader.ServiceClassCode);
        
        Assert.Equal("Bob's Manufactur", batch.BatchHeader.CompanyName);
        Assert.Equal("881234567", batch.BatchHeader.CompanyIdentification);
        
        Assert.NotNull(batch.EntryDetails);
        Assert.Equal(5, batch.EntryDetails.Count);
        Assert.Equal("026009593", batch.EntryDetails[0].RoutingNumber);
        Assert.Equal("026009593", batch.EntryDetails[1].RoutingNumber);
        
        Assert.NotNull(batch.BatchControl);
        
        Assert.NotNull(result.FileControl);
        
        Assert.True(result.FileControl.BatchCount >= 0);
        Assert.True(result.FileControl.BlockCount >= 0);
        Assert.True(result.FileControl.EntryAddendaCount >= 0);
        Assert.True(result.FileControl.TotalDebit >= 0);
        Assert.True(result.FileControl.TotalCredit >= 0);
    }
}