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

    [HttpGet(Name = "GetAllDepositsByUserId")]
    [HttpGet("{userKey}")]
    public async Task<IEnumerable<Deposit>> Get([FromRoute]int userKey)
    {
        var deposits = await _mediator.Send(new GetAllDepositCommand(_dbContext, userKey));

        return deposits;
    }
    
    [HttpGet(Name = "GetDepositSumByUserId")]
    [HttpGet("/Deposit/total/{userKey}")]
    public async Task<int> GetDepositSumByUserId([FromRoute]int userKey)
    {
        var deposits = await _mediator.Send(new GetAllDepositCommand(_dbContext, userKey));

        return deposits?.Sum(deposit => deposit.Amount) ?? 0;
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
        if (string.IsNullOrEmpty(dto.Currency))
        {
            return new List<Deposit>();
        }

        var deposits = await _mediator.Send(new GetDepositByCurrencyCommand(_dbContext, dto.Currency ));

        return deposits;
    }
}