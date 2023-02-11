namespace SA.Data.Context
{
	public interface IBaseDbContext
	{
		Task Commit();

		Task BeginTransaction();
		Task RollBack();
	}
}
