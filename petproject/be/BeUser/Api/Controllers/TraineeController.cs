using Domain;
using Domain.Events;
using Domain.Users;
using Microsoft.AspNetCore.Mvc;
using Service.Managers;
using Service.Managers.User;

namespace Api.Controllers;

[ApiController]
[Route("api/trainee")]
public class TraineeController : ControllerBase
{
    private readonly ITraineeManager _traineeManager;

    public TraineeController(ITraineeManager traineeManager)
    {
        _traineeManager = traineeManager;
    }

    [HttpGet("{traineeId:Guid}")]
    public async Task<ActionResult> GetTraineeById(Guid traineeId)
    {
        var trainee = await _traineeManager.GetTrainee(traineeId);
        return trainee != null ? Ok(trainee) : BadRequest();
    }

    [HttpPost("{traineeName}")]
    public async Task<ActionResult> AddTrainee(string traineeName, string email)
    {
        var trainee = new Trainee(traineeName,email);
        var addedTrainee = await _traineeManager.AddTrainee(trainee);
        return Ok(addedTrainee);
    }

    [HttpPut("update-trainee/{traineeId:Guid}")]
    public async Task<ActionResult> UpdateTrainee(Guid traineeId, string name)
    {
        var trainee = await _traineeManager.GetTrainee(traineeId);
        if (trainee == null) return NotFound();
        trainee.UpdateName(name);
        await _traineeManager.Update();
        return Ok(trainee);
    }
}