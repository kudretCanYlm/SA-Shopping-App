namespace SA.Data.Context
{
	public interface IBaseDbContext
	{
		void Commit();

		void BeginTransaction();
		void RollBack();
	}
}
