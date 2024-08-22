using Microsoft.AspNetCore.Mvc;
using Wpm.Management.Api.Application;

namespace Wpm.Management.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ManagementController(ManagementApplicationService applicationService,
                                  ICommandHandler<SetWeightCommand> commandHandler) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult> Post(CreatePetCommand command)
    {
        await applicationService.Handle(command);
        return Ok();
    }

    [HttpPut]
    public async Task<ActionResult> Put(SetWeightCommand command)
    {
        await commandHandler.Handle(command);
        return Ok();
    }
}