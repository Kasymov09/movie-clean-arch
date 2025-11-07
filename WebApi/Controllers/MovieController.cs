using Application.Common.Results;
using Application.Interfaces;
using Application.Movies.Commands;
using Application.Movies.DTOs;
using Application.Movies.Queries;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MovieController(
    ICommandHandler<MoviesGetQuery,  Result<List<MovieGetDto>>> getMovies,
    ICommandHandler<CreateMovieCommand, Result<string>> createMovie,
    ICommandHandler<UpdateMovieCommand, Result<string>> updateMovie,
    ICommandHandler<MovieGetQuery, Result<MovieGetDto>> getMovie)
    : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllMovies()
    {
        var result = await getMovies.HandleAsync(new MoviesGetQuery());
        if (!result.IsSuccess)
            return HandleError(result);

        return Ok(result.Data);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetMovieById(int id)
    {
        var result = await getMovie.HandleAsync(new MovieGetQuery());
        if (!result.IsSuccess)
            return HandleError(result);
        return Ok(result.Data);
    }

    [HttpPost]
    public async Task<IActionResult> CreateMovie(CreateMovieCommand command)
    {
        var result = await createMovie.HandleAsync(command);
        
        if (!result.IsSuccess)
            return HandleError(result);
        
        return Created("", result.Message);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateMovie(UpdateMovieCommand command)
    {
        var result = await updateMovie.HandleAsync(command);
        if (!result.IsSuccess)
            return HandleError(result);
        
        return Ok(result.Message);
    }
    
    private IActionResult HandleError<T>(Result<T> result)
    {
        return result.ErrorType switch
        {
            ErrorType.NotFound => NotFound(new { error = result.Message }),
            ErrorType.Validation => BadRequest(new { error = result.Message }),
            ErrorType.Conflict => Conflict(new { error = result.Message }),
            ErrorType.Internal => StatusCode(500, new { error = result.Message }),
            _ => StatusCode(500, new { error = result.Message ?? "Unhandled error" })
        };
    }
}