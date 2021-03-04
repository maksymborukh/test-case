using MediatR;
using testcase.API.Models;

namespace testcase.API.Commands
{
    public class CreateTransactionCommand : IRequest<Transaction>
    {
        public string Status { get; set; }
        public string Type { get; set; }
        public string ClientName { get; set; }
        public string Amount { get; set; }
    }
}
