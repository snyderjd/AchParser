using System;
using System.Collections.Generic;
using System.IO;

namespace AchParser;

public class Transaction
{
    public string RoutingNumber { get; set; }
    public string AccountNumber { get; set; }
    public decimal Amount { get; set; }
    public string IndividualName { get; set; }
    // Add more fields as needed
}

public class AchFileParser
{
    public List<Transaction> ParseFile(string filePath)
    {
        var transactions = new List<Transaction>();

        foreach (var line in File.ReadLines(filePath))
        {
            var recordType = line.Substring(0, 1);

            switch (recordType)
            {
                case "1":
                    ParseFileHeader(line);
                    break;
                case "5":
                    ParseBatchHeader(line);
                    break;
                case "6":
                    var transaction = ParseEntryDetail(line);
                    if (transaction != null)
                        transactions.Add(transaction);
                    break;
                case "7":
                    ParseAddenda(line);
                    break;
                case "8":
                    ParseBatchControl(line);
                    break;
                case "9":
                    ParseFileControl(line);
                    break;
            }
        }

        return transaction;
    }

    private void ParseFileHeader(string line)
    {
        // Implement parsing logic for file header record (type 1)
    }

    private void ParseBatchHeader(string line)
    {
        // Implement parsing logic for batch header record (type 5)
    }

    private Transaction ParseEntryDetail(string line)
    {
        // Implement parsing logic for entry detail record (type 6)
        try
        {
            var transaction = new Transaction
            {
                RoutingNumber = line.Substring(3, 9),
                AccountNumber = line.Substring(12, 17).Trim(),
                Amount = decimal.Parse(line.Substring(29, 10)) / 100,
                IndividualName = line.Substring(54, 22).Trim()
            };

            return transaction;
        }
        catch
        {
            return null;
        }
    }

    private void ParseAddenda(string line)
    {
        // Implement parsing logic for addenda record (type 7)
    }

    private void ParseBatchControl(string line)
    {
        // Implement parsing logic for batch control record (type 8)
    }

    private void ParseFileControl(string line)
    {
        // Implement parsing logic for file control record (type 9)
    }

}