using System.Windows.Input;
using Application.Common.Results;
using Application.Interfaces;
using Application.Movies.Commands;
using Application.Movies.DTOs;
using Application.Movies.Mappers;
using Application.Movies.Queries;
using Domain.Interfaces;

namespace Application.Movies.Handlers;

public class MovieGetQueryHandler(IMovieRepository repository) : ICommandHandler<MovieGetDto, Result<MovieGetDto>>
{
    public async Task<Result<MovieGetDto>> HandleAsync(MovieGetDto command)
    {
        var movie = await repository.GetByIdAsync(command.Id);

        var dto = movie!.ToDto();
        
        return Result<MovieGetDto>.Ok(dto);
    }
}