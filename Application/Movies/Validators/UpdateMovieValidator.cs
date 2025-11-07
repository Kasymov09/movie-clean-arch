using Application.Common.Validations;
using Application.Interfaces;
using Application.Movies.Commands;

namespace Application.Movies.Validators;

public class UpdateMovieValidator : IValidator<UpdateMovieCommand>
{
    public ValidationResult Validate(UpdateMovieCommand value)
    {
        var result = new ValidationResult();
        
        if (string.IsNullOrWhiteSpace(value.Title))
            result.AddError("Title is required");
        if(value.Title.Length > 100)
            result.AddError("Title is too long");
        
        if(string.IsNullOrWhiteSpace(value.Director))
            result.AddError("Director is required");
        if(value.Director.Length > 100)
            result.AddError("Director name is too long");
        
        if(string.IsNullOrWhiteSpace(value.Genre))
            result.AddError("Genre is required");
        if(value.Genre.Length > 50)
            result.AddError("Genre name is too long");


        foreach (var actor in value.Actors)
        {
            if (string.IsNullOrWhiteSpace(actor))
                result.AddError("Actor is required");
            
            if (actor.Length > 100)
                result.AddError("Actor name is too long");
        }
        
        if(value.Description?.Length > 500)
            result.AddError("Description is too long");
        
        if(value.Duration <= 0)
            result.AddError("Duration is required and cannot be less than 0");
        
        if(value.ReleaseDate.Year < 1700)
            result.AddError("Release date cannot be earlier than 1700");
        
        return result;
    }
}