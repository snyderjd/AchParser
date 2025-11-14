namespace AchParser;

public class AchFile
{
    public FileHeaderRecord FileHeader { get; set; }
    public List<Batch> Batches { get; set; } = new List<Batch>();
    public FileControlRecord FileControl { get; set; }
}

public class FileHeaderRecord
{
    public string ImmediateDestination { get; set; }
    public string ImmediateOrigin { get; set; }
    public string FileCreationDate { get; set; }
    public string FileCreationTime { get; set; }
}

public class Batch
{
    public BatchHeaderRecord BatchHeader { get; set; }
    public List<EntryDetailRecord> EntryDetails { get; set; } = new List<EntryDetailRecord>();
    public BatchControlRecord BatchControl { get; set; }
}

public class BatchHeaderRecord
{
    public string ServiceClassCode { get; set; }
    public string CompanyName { get; set; }
    public string CompanyIdentification { get; set; }
}

public class EntryDetailRecord
{
    public string RoutingNumber { get; set; }
    public string AccountNumber { get; set; }
    public decimal Amount { get; set; }
    public string IndividualName { get; set; }
    public List<AddendaRecord> AddendaRecords { get; set; } = new List<AddendaRecord>();
}

public class AddendaRecord
{
    public string Information { get; set; }
}

public class BatchControlRecord
{
    public int EntryAddendaCount { get; set; }
    public decimal TotalDebit { get; set; }
    public decimal TotalCredit { get; set; }
}

public class FileControlRecord
{
    public int BatchCount { get; set; }
    public int BlockCount { get; set; }
    public int EntryAddendaCount { get; set; }
    public decimal TotalDebit { get; set; }
    public decimal TotalCredit { get; set; }
}
