using Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace DepositService.QueryControllers;

[ApiController]
[Route("[controller]")]
public class DepositController : ControllerBase
{
    private readonly ILogger<DepositController> _logger;

    public DepositController(ILogger<DepositController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetAllDeposits")]
    public IEnumerable<Deposit> Get()
    {
        var deposits = new Deposit
        {
            Amount = 0,
            Currency = "NZD"
        };

        return new List<Deposit>() { deposits };
    }
}