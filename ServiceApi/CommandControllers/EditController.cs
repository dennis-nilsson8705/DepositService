using Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Service.CommandControllers;

[ApiController]
[Route("[controller]")]
public class DepositController : ControllerBase
{
    private readonly ILogger<DepositController> _logger;

    public DepositController(ILogger<DepositController> logger)
    {
        _logger = logger;
    }

    [HttpPut(Name = "PutDeposit")]
    public IEnumerable<Deposit> Put()
    {
        var deposit = new Deposit
        {
            Amount = 0,
            Currency = "NZD"
        };

        return new List<Deposit>() { deposit };
    }
}