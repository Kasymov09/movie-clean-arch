using Application.Movies.Commands;
using Application.Movies.DTOs;
using Domain.Entities;

namespace Application.Movies.Mappers;

public static class MovieMappers
{
    public static Movie ToEntity(this CreateMovieCommand command)
    {
        return new Movie()
        {
            Title = command.Title,
            Actors = command.Actors,
            Director = command.Director,
            Genre = command.Genre,
            ReleaseDate = command.ReleaseDate,
            Description = command.Description,
            Duration = command.Duration
        };
    }
    
    public static Movie ToEntity(this UpdateMovieCommand command)
    {
        return new Movie()
        {
            Title = command.Title,
            Actors = command.Actors,
            Director = command.Director,
            Genre = command.Genre,
            ReleaseDate = command.ReleaseDate,
            Description = command.Description,
            Duration = command.Duration
        };
    }

    public static List<MovieGetDto> ToDto(this IEnumerable<Movie> movies)
    {
        return movies.Select(movie => new MovieGetDto()
        {
            Id = movie.Id,
            Title = movie.Title,
            Actors = movie.Actors,
            Director = movie.Director,
            Genre = movie.Genre,
            ReleaseDate = movie.ReleaseDate,
            Description = movie.Description,
            Duration = movie.Duration
        }).ToList();
    }

    public static MovieGetDto ToDto(this Movie movie)
    {
        return new MovieGetDto()
        {
            Id = movie.Id,
            Title = movie.Title,
            Actors = movie.Actors,
            Director = movie.Director,
            Genre = movie.Genre,
            ReleaseDate = movie.ReleaseDate,
            Description = movie.Description,
            Duration = movie.Duration
        };
    }
}