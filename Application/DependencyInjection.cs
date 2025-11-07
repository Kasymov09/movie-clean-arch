using Application.Common.Results;
using Application.Interfaces;
using Application.Movies.Commands;
using Application.Movies.DTOs;
using Application.Movies.Handlers;
using Application.Movies.Queries;
using Application.Movies.Validators;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class DependencyInjection
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<ICommandHandler<CreateMovieCommand, Result<string>>, CreateMovieCommandHandler>();
        services.AddScoped<ICommandHandler<MoviesGetQuery, Result<List<MovieGetDto>>>, MoviesGetQueryHandler>();
        services.AddScoped<ICommandHandler<UpdateMovieCommand, Result<string>>, UpdateMovieCommandHandler>();
        services.AddScoped<IValidator<CreateMovieCommand>, CreateMovieValidator>();
    }
}