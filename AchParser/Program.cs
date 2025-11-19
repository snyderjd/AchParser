Console.WriteLine("=============================");
Console.WriteLine("====== ACH File Parser ======");
Console.WriteLine("=============================");
Console.WriteLine();

// Parse consumer_billing.txt ACH file and output information for each record
string filePath = "./SampleAchFiles/consumer_billing.txt";

AchFileParser parser = new AchFileParser();
var achFile = parser.ParseFile(filePath);

// Output file header information
Console.WriteLine("----- File Header -----");
Console.WriteLine($"File Creation Date: {achFile.FileHeader.FileCreationDate}");
Console.WriteLine($"File Creation Time: {achFile.FileHeader.FileCreationTime}");
Console.WriteLine($"Immediate Destination: {achFile.FileHeader.ImmediateDestination}");
Console.WriteLine($"Immediate Destination Name: {achFile.FileHeader.ImmediateDestinationName}");
Console.WriteLine($"Immediate Origin: {achFile.FileHeader.ImmediateOrigin}");
Console.WriteLine($"Immediate Origin Name: {achFile.FileHeader.ImmediateOriginName}");
Console.WriteLine();

// Output information for each batch record
foreach (var batch in achFile.Batches)
{
    Console.WriteLine("----- Batch: -----");
    Console.WriteLine();
    Console.WriteLine("----- Batch Header Record -----");
    Console.WriteLine($"Service Class Code: {batch.BatchHeader.ServiceClassCode}");
    Console.WriteLine($"Company Name: {batch.BatchHeader.CompanyName}");
    Console.WriteLine($"Company Identification: {batch.BatchHeader.CompanyIdentification}");
    Console.WriteLine();

    foreach (var entryDetail in batch.EntryDetails)
    {
        Console.WriteLine("----- Entry Detail -----");
        Console.WriteLine($"Routing Number: {entryDetail.RoutingNumber}");
        Console.WriteLine($"Account Number: {entryDetail.AccountNumber}");
        Console.WriteLine($"Amount: {entryDetail.Amount}");
        Console.WriteLine($"Individual Name: {entryDetail.IndividualName}");
        Console.WriteLine();
        
        foreach (var addenda in entryDetail.AddendaRecords)
        {
            Console.WriteLine("----- Addenda Record -----");
            Console.WriteLine($"Information: {addenda.Information}");
        }
    }

    Console.WriteLine("----- Batch Control Record -----");
    Console.WriteLine($"Entry Addenda Count: {batch.BatchControl.EntryAddendaCount}");
    Console.WriteLine($"Total Debit: {batch.BatchControl.TotalDebit}");
    Console.WriteLine($"Total Credit: {batch.BatchControl.TotalCredit}");
    Console.WriteLine();
}

// Output information from file control record
Console.WriteLine("----- File Control Record -----");
Console.WriteLine($"Batch Count: {achFile.FileControl.BatchCount}");
Console.WriteLine($"Block Count: {achFile.FileControl.BlockCount}");
Console.WriteLine($"Entry Addenda Count: {achFile.FileControl.EntryAddendaCount}");
Console.WriteLine($"Total Debit: {achFile.FileControl.TotalDebit}");
Console.WriteLine($"Total Credit: {achFile.FileControl.TotalCredit}");

