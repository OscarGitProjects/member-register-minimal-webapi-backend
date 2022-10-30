namespace MemberRegister.DataAccess.DataAccess
{
    public interface ISqlDataAccess
    {
        Task<IEnumerable<T>> LoadDataAsync<T, U>(string strStoredProcedureName, U parameters, string strConnectionId = "dbSqlConnection");
        Task<int> SaveDataAsync<U>(string strStoredProcedureName, U parameters, string strConnectionId = "dbSqlConnection");
    }
}