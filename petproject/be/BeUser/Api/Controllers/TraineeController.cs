using Domain;
using Domain.Events;
using Domain.Events.Trainee;
using Domain.User;
using Microsoft.AspNetCore.Mvc;
using Service.Managers;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TraineeController : ControllerBase
{
    private readonly ITraineeManager _traineeManager;

    public TraineeController(ITraineeManager traineeManager)
    {
        _traineeManager = traineeManager;
    }

    [HttpGet("trainees/{traineeId:Guid}")]
    public async Task<ActionResult> GetTraineeById(Guid traineeId)
    {
        var trainee = await _traineeManager.GetTrainee(traineeId);
        return trainee != null ? Ok(trainee) : BadRequest();
    }

    [HttpPost("trainees/{traineeName}")]
    public async Task<ActionResult> AddTrainee(string traineeName, string authorizer)
    {
        var trainee = new Trainee
        {
            Name = traineeName,
            Events = []
        };

        trainee.Append(new TraineeCreated
        {
            NameTrainee = traineeName,
            NameAuthorizer = authorizer
        });

        var addedTrainee = await _traineeManager.AddTrainee(trainee);
        return Ok(addedTrainee);
    }

    [HttpPut("update-trainee/{traineeId:Guid}")]
    public async Task<ActionResult> UpdateTrainee(Guid traineeId, string name)
    {
        var trainee = await _traineeManager.GetTrainee(traineeId);
        if (trainee == null) return NotFound();
        var traineeEvent = new TraineeUpdated
        {
            TraineeId = traineeId,
            Name = name,
        };
        trainee.Append(traineeEvent);
        trainee.Apply(traineeEvent);
        await _traineeManager.Update();
        return Ok(trainee);
    }
}