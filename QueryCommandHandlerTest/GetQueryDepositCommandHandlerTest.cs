using Command.Query;
using Data.Entities;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace QueryCommandHandlerTest;

public class When_Handling_Get_All_Deposit_Command
{
    private readonly ApplicationDbContext _dbContext;

    public When_Handling_Get_All_Deposit_Command()
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;
        _dbContext = new ApplicationDbContext(options);
    }

    [Fact]
    public async void Then_It_Should_Handle_Correctly()
    {
        var userId = Guid.NewGuid();

        var getAllDepositCommandHandler = new GetAllDepositCommandHandler();
        var getAllDepositCommandMoq = new Mock<GetAllDepositCommand>(_dbContext,1);
        _dbContext.Deposit!.Add(new Deposit(Guid.NewGuid(), 3, "NZD", 1, false));
        await _dbContext.SaveChangesAsync();
        var result =
            await getAllDepositCommandHandler.Handle(getAllDepositCommandMoq.Object, new CancellationToken());

        Assert.Single(result);

        getAllDepositCommandMoq.Verify();
    }
}

public class When_Handling_Get_Crypto_Deposit_Command
{
    private readonly ApplicationDbContext _dbContext;

    public When_Handling_Get_Crypto_Deposit_Command()
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;
        _dbContext = new ApplicationDbContext(options);
    }

    [Fact]
    public async void Then_It_Should_Handle_Correctly()
    {
        var getCryptoDepositCommandHandler = new GetCryptoDepositCommandHandler();
        var getCryptoDepositCommandMoq = new Mock<GetCryptoDepositCommand>(_dbContext, true);
        _dbContext.Deposit!.Add(new Deposit(Guid.NewGuid(), 3, "BTC", 1, true));
        _dbContext.Deposit!.Add(new Deposit(Guid.NewGuid(), 3, "NZD", 1, false));

        await _dbContext.SaveChangesAsync();
        var result =
            await getCryptoDepositCommandHandler.Handle(getCryptoDepositCommandMoq.Object, new CancellationToken());

        Assert.Single(result);

        getCryptoDepositCommandMoq.Verify();
    }
}