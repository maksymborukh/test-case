using MediatR;
using testcase.API.Models;

namespace testcase.API.Commands
{
    public class UpdateTransactionByIdCommand : IRequest<Transaction>
    {
        public int Id { get; set; }
        public string Status { get; set; }
    }
}
