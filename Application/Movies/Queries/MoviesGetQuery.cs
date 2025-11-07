using Application.Common.Results;
using Application.Interfaces;
using Application.Movies.DTOs;

namespace Application.Movies.Queries;

public class MoviesGetQuery : ICommand<Result<List<MovieGetDto>>>
{
    
}