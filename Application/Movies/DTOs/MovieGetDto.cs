using Application.Common.Results;
using Application.Interfaces;

namespace Application.Movies.DTOs;

public class MovieGetDto : ICommand<Result<MovieGetDto>>
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string Director { get; set; } = null!;
    public List<string> Actors { get; set; } = null!;
    public DateTime ReleaseDate { get; set; }
    public string Genre { get; set; } = null!;
    public int Duration { get; set; }
    public string? Description { get; set; }
}