using MediatR;
using System.Collections.Generic;
using testcase.API.Models;

namespace testcase.API.Queries
{
    public class GetTransactionsByFilterQuery : IRequest<IEnumerable<Transaction>>
    {
        public string StatusFilter { get; set; }
        public string TypeFilter { get; set; }

        public GetTransactionsByFilterQuery(string status, string type)
        {
            StatusFilter = status;
            TypeFilter = type;
        }
    }
}
