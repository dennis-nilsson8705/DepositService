using Command.Query;
using Data.Entities;
using Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
 
namespace DepositService.QueryControllers;

[ApiController]
[Route("[controller]")]
public class DepositController : ControllerBase
{
    private readonly ILogger<DepositController> _logger;
    private readonly IMediator _mediator;
    private readonly DbContext _dbContext;

    public DepositController(ILogger<DepositController> logger, IMediator mediator, ApplicationDbContext dbContext)
    {
        _logger = logger;
        _mediator = mediator;
        _dbContext = dbContext;
    }

    [HttpGet(Name = "GetAllDeposits")]
    public async Task<IEnumerable<Deposit>> Get()
    {
        var deposits = new Deposit
        {
            Amount = 0,
            Currency = "NZD"
        };
        
        var movie = await _mediator.Send(new GetAllDepositCommand( ));

        return new List<Deposit>() { deposits };
    }
}