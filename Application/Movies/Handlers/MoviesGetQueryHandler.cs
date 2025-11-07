using Application.Common.Results;
using Application.Interfaces;
using Application.Movies.DTOs;
using Application.Movies.Mappers;
using Application.Movies.Queries;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Movies.Handlers;

public class MoviesGetQueryHandler(IMovieRepository  repository) 
        : ICommandHandler<MoviesGetQuery, Result<List<MovieGetDto>>>
{
        public async Task<Result<List<MovieGetDto>>> HandleAsync(MoviesGetQuery command)
        {
                var movies = await repository.GetAllAsync();

                var dtos = movies.ToDto();

                return Result<List<MovieGetDto>>.Ok(dtos);
        }
}