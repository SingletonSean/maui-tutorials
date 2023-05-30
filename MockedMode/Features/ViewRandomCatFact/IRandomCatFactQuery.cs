namespace MockedMode.Features.ViewRandomCatFact
{
    public interface IRandomCatFactQuery
    {
        Task<CatFact> Execute();
    }
}