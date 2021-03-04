using MediatR;
using System.Collections.Generic;
using testcase.API.Models;

namespace testcase.API.Commands
{
    public class ImportExcelCommand : IRequest<IEnumerable<Transaction>>
    {
        public string Path { get; set; }
        
        public ImportExcelCommand(string path)
        {
            Path = path;
        }
    }
}
