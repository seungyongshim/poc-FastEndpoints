using FastEndpoints;
using WebApplication1.Dto;

namespace WebApplication1.Endpoint;


public class Endpoint : Endpoint<Request, Response>
{
    public override void Configure()
    {
        Verbs(Http.POST);
        Routes("/author/signup");
        AllowAnonymous();
    }

    public override async Task HandleAsync(Request r, CancellationToken c)
    {
        await SendAsync(new Response()
        {
            //blank for now
        });
    }
}
