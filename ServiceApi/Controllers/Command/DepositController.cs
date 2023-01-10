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
 

    public DepositController(ILogger<DepositController> logger, ApplicationDbContext dbContext)
    {
        _logger = logger;
        _dbContext = dbContext;
    }

 
    
    [HttpPost(Name = "CreateDeposit")]
    public async Task<bool> Post([FromBody] CreateDepositDto dto)
    {
 
            var result = await _mediator.Send(new CreateDepositCommand(_dbContext, dto));

            return result;
 
    }
}