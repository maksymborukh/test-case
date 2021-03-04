using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using testcase.API.Models;

namespace testcase.API.ExcelHelper
{
    public class ImportExcel
    {
        public IEnumerable<Transaction> Import(string path)
        {
            List<Transaction> transactions = File.ReadAllLines(path).Skip(1).Select(v => new Transaction
            {
                TransactionId = Convert.ToInt32(v.Split(',')[0]),
                Status = v.Split(',')[1],
                Type = v.Split(',')[2],
                ClientName = v.Split(',')[3],
                Amount = v.Split(',')[4],
            }).ToList();
            return transactions;
        }
    }
}
