using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class MovieRepository(ApplicationDbContext context) : IMovieRepository
{
    public async Task<IEnumerable<Movie>> GetAllAsync()
    {
        return await context.Movies.ToListAsync();
    }

    public async Task<Movie?> GetByIdAsync(int id)
    {
        return await context.Movies.FindAsync(id);
    }

    public async Task AddAsync(Movie movie)
    {
        await context.Movies.AddAsync(movie);
    }

    public Task UpdateAsync(Movie movie)
    {
        context.Movies.Update(movie);
        return Task.CompletedTask;
    }

    public Task DeleteAsync(Movie movie)
    {
        context.Movies.Remove(movie);
        return Task.CompletedTask;
    }
}