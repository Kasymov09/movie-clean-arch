using Application.Common.Results;
using Application.Interfaces;
using Application.Movies.Commands;
using Application.Movies.Mappers;
using Domain.Interfaces;

namespace Application.Movies.Handlers;

public class UpdateMovieCommandHandler(
    IMovieRepository  repository,
    IUnitOfWork  unitOfWork,
    IValidator<UpdateMovieCommand> validator)
        : ICommandHandler<UpdateMovieCommand, Result<string>>
{
    public async Task<Result<string>> HandleAsync(UpdateMovieCommand command)
    {
        var validation =  validator.Validate(command);
        if (!validation.IsValid)
        {
            var errors = string.Join("\n",  validation.Errors.Select(e => e));
            return Result<string>.Fail(errors, ErrorType.Validation);
        }
        
        var student = command.ToEntity();
        
        await repository.AddAsync(student);
        await unitOfWork.SaveChangesAsync();

        return Result<string>.Ok(null, "Updated successfully");
    }
}