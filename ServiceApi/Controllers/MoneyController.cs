using ApiProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiProject.Controllers;

[ApiController]
[Route("[controller]")]
public class MoneyController : ControllerBase
{
    private readonly ILogger<MoneyController> _logger;

    public MoneyController(ILogger<MoneyController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetMoney")]
    public IEnumerable<Money> Get()
    {
        var money = new Money
        {
            Amount = 0,
            Currency = "NZD"
        };

        return new List<Money>() { money };
    }
}