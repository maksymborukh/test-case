using MediatR;
using testcase.API.Models;

namespace testcase.API.Queries
{
    public class GetTransactionByIdQuery : IRequest<Transaction>
    {
        public int Id { get; set; }

        public GetTransactionByIdQuery(int id)
        {
            Id = id;
        }
    }
}
