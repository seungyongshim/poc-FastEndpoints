using FastEndpoints;
using FluentValidation;

namespace WebApplication2.Endpoints;

public record MyRequest
{
    public required string FirstName { get; init; }
    public required string LastName { get; init; }
    public int Age { get; init; }
}

public record MyResponse
{
    public required string FullName { get; init; }
    public bool IsOver18 { get; init; }
}

public class MyValidator : Validator<MyRequest>
{
    public MyValidator()
    {
        RuleFor(x => x.FirstName).NotEmpty();
        RuleFor(x => x.LastName).NotEmpty();
        RuleFor(x => x.Age).GreaterThan(0);
    }
}

public class MyEndpoint : Endpoint<MyRequest, MyResponse>
{
    public override void Configure()
    {
        Post("/api/user/create");
        AllowAnonymous();
    }

    public override async Task HandleAsync(MyRequest req, CancellationToken ct)
    {
        await SendAsync(new()
        {
            FullName = req.FirstName + " " + req.LastName,
            IsOver18 = req.Age > 18
        });
    }
}
