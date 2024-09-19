using Domain;
using Domain.Users;

namespace Service.Managers.User;

public interface ITraineeManager
{
    public Task<Trainee?> GetTrainee(Guid traineeId);
    public Task<Trainee> AddTrainee(Trainee trainee);
    
    public Task Update();
}