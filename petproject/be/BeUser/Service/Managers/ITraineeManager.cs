using Domain;

namespace Service.Managers;

public interface ITraineeManager
{
    public Task<Trainee?> GetTrainee(int traineeId);
    public Task<Trainee> AddTrainee(Trainee trainee);
    
    public Task Update();
}