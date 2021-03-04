using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using testcase.API.Models;

namespace testcase.API.ExcelHelper
{
    public class ExportExcel
    {
        public IEnumerable<Transaction> Export(IEnumerable<Transaction> transactions, string path)
        {
            using (var file = File.CreateText(path))
            {
                file.WriteLine("TransactionId,Status,Type,ClientName,Amount");
                foreach (var el in transactions)
                {
                    file.WriteLine($"{el.TransactionId},{el.Status},{el.Type},{el.ClientName},{el.Amount}");
                }
            }
            return transactions;
        }
    }
}
