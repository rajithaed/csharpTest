namespace CSharpTest.Data.Context
{
    public interface IContextFactory<out TContext> where TContext : IContext
    {
        TContext Create();
    }
}