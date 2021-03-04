using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using testcase.API.Commands;
using testcase.API.Models;
using testcase.API.Queries;

namespace testcase.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TransactionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Creates a New Transaction.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        /// <response code="201">Returns the newly created entity</response>
        [HttpPost]
        [Authorize(Policy = Policies.User)]
        public async Task<IActionResult> Create(CreateTransactionCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        /// <summary>
        /// Gets Transaction Entity by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A newly created Transaction</returns>
        /// [Authorize(Policy = Policies.User)]
        [HttpGet("{id}")]
        [Authorize(Policy = Policies.User)]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetTransactionByIdQuery(id);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        /// <summary>
        /// Gets all Transactions.
        /// </summary>
        /// <returns>All transactions</returns>       
        [HttpGet]
        [Authorize(Policy = Policies.User)]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllTransactionsQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        /// <summary>
        /// Search Client by Name
        /// </summary>
        /// <param name="name"></param>
        /// <returns>List of client's names which match filter</returns>
        [HttpGet("client/{name}")]
        [Authorize(Policy = Policies.User)]
        public async Task<IActionResult> GetClient(string name)
        {
            var query = new GetClientQuery(name);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        /// <summary>
        /// Get Transactions by filter (Status and Type)
        /// </summary>
        /// <param name="status"></param>
        /// <param name="type"></param>
        /// <returns>List of transactions which match filter</returns>
        [HttpGet("filter/{status}/{type}")]
        [Authorize(Policy = Policies.User)]
        public async Task<IActionResult> GetByFilter(string status, string type)
        {
            var query = new GetTransactionsByFilterQuery(status, type);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        /// <summary>
        /// Updates the Transaction Status based on Id.
        /// </summary>
        /// <param name="command"></param>
        /// <returns>Updated transaction</returns>
        [HttpPut]
        [Authorize(Policy = Policies.User)]
        public async Task<IActionResult> Update(UpdateTransactionByIdCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        /// <summary>
        /// Deletes Transaction Entity based on Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Deleted transaction</returns>
        [HttpDelete("{id}")]
        [Authorize(Policy = Policies.User)]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteTransactionByIdCommand(id);
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        /// <summary>
        /// Import .csv data file
        /// </summary>
        /// <param name="path"></param>
        /// <returns>Updated or/and inserted transactions</returns>
        [HttpPost("import/{path}")]
        [Authorize(Policy = Policies.User)]
        public async Task<IActionResult> ImportExcel(string path)
        {
            var command = new ImportExcelCommand(path);
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        /// <summary>
        /// Export filtered transactions to .csv
        /// </summary>
        /// <param name="status"></param>
        /// <param name="type"></param>
        /// <param name="path"></param>
        /// <returns>Exported transactions</returns>
        [HttpGet("export/filter/{status}/{type}/{path}")]
        [Authorize(Policy = Policies.User)]
        public async Task<IActionResult> ExportExcel(string status, string type, string path)
        {
            var filterQuery = new GetTransactionsByFilterQuery(status, type);
            var filteredResult = await _mediator.Send(filterQuery);

            var query = new ExportExcelQuery(filteredResult, path);
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
