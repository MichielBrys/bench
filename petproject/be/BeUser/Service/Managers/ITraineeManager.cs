using Domain;
using Domain.User;

namespace Service.Managers;

public interface ITraineeManager
{
    public Task<Trainee?> GetTrainee(Guid traineeId);
    public Task<Trainee> AddTrainee(Trainee trainee);
    
    public Task Update();
}