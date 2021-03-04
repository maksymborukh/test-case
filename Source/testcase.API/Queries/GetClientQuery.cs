using MediatR;
using System.Collections.Generic;

namespace testcase.API.Queries
{
    public class GetClientQuery : IRequest<IEnumerable<string>>
    {
        public string Name { get; set; }
        public GetClientQuery(string name)
        {
            Name = name;
        }
    }
}
