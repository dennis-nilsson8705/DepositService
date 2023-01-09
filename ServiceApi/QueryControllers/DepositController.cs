using Command.Query;
using Data.Entities;
using Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DepositService.QueryControllers;

[ApiController]
[Route("[controller]")]
public class DepositController : ControllerBase
{
    private readonly ILogger<DepositController> _logger;
    private readonly IMediator _mediator;
    private readonly ApplicationDbContext _dbContext;

    public DepositController(ILogger<DepositController> logger, IMediator mediator, ApplicationDbContext dbContext)
    {
        _logger = logger;
        _mediator = mediator;
        _dbContext = dbContext;
    }

    [HttpGet(Name = "GetAllDeposits")]
    public async Task<IEnumerable<Deposit>> Get()
    {
        var deposits = await _mediator.Send(new GetAllDepositCommand(_dbContext));

        return deposits;
    }
}