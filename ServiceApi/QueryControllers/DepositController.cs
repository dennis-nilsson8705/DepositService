using Command.Query;
using Data.Entities;
using Data.QueryDtos;
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

    [HttpPost("/crypto")]
    public async Task<IEnumerable<Deposit>> Get([FromBody] Boolean isCrypto)
    {
        var deposits = await _mediator.Send(new GetCryptoDepositCommand(_dbContext, isCrypto));

        return deposits;
    }

    [HttpPost("/currency")]
    public async Task<IEnumerable<Deposit>> Get([FromBody] GetDepositsByCurrencyDto dto)
    {
        var deposits = await _mediator.Send(new GetDepositByCurrencyCommand(_dbContext, dto.Currency));

        return deposits;
    }
}