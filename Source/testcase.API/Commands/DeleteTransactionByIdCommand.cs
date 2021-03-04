using MediatR;
using testcase.API.Models;

namespace testcase.API.Commands
{
    public class DeleteTransactionByIdCommand : IRequest<Transaction>
    {
        public int Id { get; set; }

        public DeleteTransactionByIdCommand(int id)
        {
            Id = id;
        }
    }
}
