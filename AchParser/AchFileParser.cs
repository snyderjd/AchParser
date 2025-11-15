using System;
using System.Collections.Generic;
using System.IO;
using AchParser;

public class AchFileParser
{

}

// public class AchFileParser
// {
//     public AchFile ParseFile(string filePath)
//     {
//         var achFile = new AchFile();
//         Batch currentBatch = null;
//         EntryDetailRecord currentEntry = null;

//         foreach (var line in File.ReadLines(filePath))
//         {
//             var recordType = line.Substring(0, 1);
//             switch (recordType)
//             {
//                 case "1":
//                     achFile.FileHeader = ParseFileHeader(line);
//                     break;
//                 case "5":
//                     currentBatch = new Batch();
//                     currentBatch.BatchHeader = ParseBatchHeader(line);
//                     achFile.Batches.Add(currentBatch);
//                     break;
//                 case "6":
//                     currentEntry = ParseEntryDetail(line);
//                     currentBatch?.EntryDetails.Add(currentEntry);
//                     break;
//                 case "7":
//                     var addenda = ParseAddenda(line);
//                     currentEntry?.AddendaRecords.Add(addenda);
//                     break;
//                 case "8":
//                     if (currentBatch != null)
//                         currentBatch.BatchControl = ParseBatchControl(line);
//                     break;
//                 case "9":
//                     achFile.FileControl = ParseFileControl(line);
//                     break;
//             }
//         }
//         return achFile;
//     }

//     private FileHeaderRecord ParseFileHeader(string line)
//     {
//         return new FileHeaderRecord
//         {
//             ImmediateDestination = line.Substring(3, 10).Trim(),
//             ImmediateOrigin = line.Substring(13, 10).Trim(),
//             FileCreationDate = line.Substring(23, 6),
//             FileCreationTime = line.Substring(29, 4)
//         };
//     }

//     private BatchHeaderRecord ParseBatchHeader(string line)
//     {
//         return new BatchHeaderRecord
//         {
//             ServiceClassCode = line.Substring(1, 3),
//             CompanyName = line.Substring(4, 16).Trim(),
//             CompanyIdentification = line.Substring(40, 10).Trim()
//         };
//     }

//     private EntryDetailRecord ParseEntryDetail(string line)
//     {
//         return new EntryDetailRecord
//         {
//             RoutingNumber = line.Substring(3, 9),
//             AccountNumber = line.Substring(12, 17).Trim(),
//             Amount = decimal.Parse(line.Substring(29, 10)) / 100,
//             IndividualName = line.Substring(54, 22).Trim()
//         };
//     }

//     private AddendaRecord ParseAddenda(string line)
//     {
//         return new AddendaRecord
//         {
//             Information = line.Substring(3).Trim()
//         };
//     }

//     private BatchControlRecord ParseBatchControl(string line)
//     {
//         return new BatchControlRecord
//         {
//             EntryAddendaCount = int.Parse(line.Substring(4, 6)),
//             TotalDebit = decimal.Parse(line.Substring(20, 12)) / 100,
//             TotalCredit = decimal.Parse(line.Substring(32, 12)) / 100
//         };
//     }

//     private FileControlRecord ParseFileControl(string line)
//     {
//         return new FileControlRecord
//         {
//             BatchCount = int.Parse(line.Substring(1, 6)),
//             BlockCount = int.Parse(line.Substring(7, 6)),
//             EntryAddendaCount = int.Parse(line.Substring(13, 8)),
//             TotalDebit = decimal.Parse(line.Substring(21, 12)) / 100,
//             TotalCredit = decimal.Parse(line.Substring(33, 12)) / 100
//         };
//     }

// }