namespace AchParser;

public class AchFile
{
    public required FileHeaderRecord FileHeader { get; set; }
    public required List<Batch> Batches { get; set; } = new List<Batch>();
    public required FileControlRecord FileControl { get; set; }
}

public class FileHeaderRecord
{
    public required string ImmediateDestination { get; set; }
    public required string ImmediateOrigin { get; set; }
    public required string FileCreationDate { get; set; }
    public required string FileCreationTime { get; set; }
    public string? ImmediateDestinationName { get; set; }
    public string? ImmediateOriginName { get; set; }
}

public class Batch
{
    public required BatchHeaderRecord BatchHeader { get; set; }
    public required List<EntryDetailRecord> EntryDetails { get; set; } = new List<EntryDetailRecord>();
    public BatchControlRecord? BatchControl { get; set; }
}

public class BatchHeaderRecord
{
    public required string ServiceClassCode { get; set; }
    public string? CompanyName { get; set; }
    public string? CompanyIdentification { get; set; }
}

public class EntryDetailRecord
{
    public required string RoutingNumber { get; set; }
    public required string AccountNumber { get; set; }
    public required decimal Amount { get; set; }
    public string? IndividualName { get; set; }
    public List<AddendaRecord> AddendaRecords { get; set; } = new List<AddendaRecord>();
}

public class AddendaRecord
{
    public required string Information { get; set; }
}

public class BatchControlRecord
{
    public required int EntryAddendaCount { get; set; }
    public required decimal TotalDebit { get; set; }
    public required decimal TotalCredit { get; set; }
}

public class FileControlRecord
{
    public required int BatchCount { get; set; }
    public required int BlockCount { get; set; }
    public required int EntryAddendaCount { get; set; }
    public required decimal TotalDebit { get; set; }
    public required decimal TotalCredit { get; set; }
}
