using Domain;
using Domain.User;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Service.Managers;

public class TraineeManager : ITraineeManager
{
    private readonly BenchDbContext _context;

    public TraineeManager(BenchDbContext context)
    {
        _context = context;
    }

    public async Task<Trainee?> GetTrainee(Guid traineeId)
    {
        return await _context.Trainees.Include(t => t.Events).FirstOrDefaultAsync(t => t.TraineeId == traineeId);
    }

    public async Task<Trainee> AddTrainee(Trainee trainee)
    {
        await _context.Trainees.AddAsync(trainee);
        await _context.SaveChangesAsync();
        return trainee;
    }

    public async Task Update()
    {
        await _context.SaveChangesAsync();
    }
}