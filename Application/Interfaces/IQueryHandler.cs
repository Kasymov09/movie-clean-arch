namespace Application.Interfaces;

public interface IQueryHandler<in TQuery, TQueryResult> where TQuery : IQuery<TQueryResult>
{
    public Task<TQueryResult> Handle(TQuery query);
}