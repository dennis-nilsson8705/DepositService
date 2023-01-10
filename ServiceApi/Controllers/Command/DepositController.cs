using AutoMapper;
using Command.Command;
using Data.CommandDtos;
using Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Service.CommandControllers;

[ApiController]
[Route("[controller]")]
public class DepositController : ControllerBase
{
    private readonly ILogger<DepositController> _logger;
    private readonly IMediator _mediator;
    private readonly ApplicationDbContext _dbContext;
 

    public DepositController(ILogger<DepositController> logger, ApplicationDbContext dbContext, IMediator mediator)
    {
        _logger = logger;
        _dbContext = dbContext;
        _mediator = mediator;
    }

 
    
    [HttpPost(Name = "CreateDeposit")]
    public async Task<bool> Post([FromBody] CreateDepositDto dto)
    {

        var cmd = new CreateDepositCommand(_dbContext, dto);
            var result = await _mediator.Send(cmd);

            return result;
 
    }
}