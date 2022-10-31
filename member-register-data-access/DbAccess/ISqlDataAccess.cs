namespace MemberRegister.DataAccess.DataAccess;

public interface ISqlDataAccess
{
    Task<IEnumerable<T>> QueryAsync<T, U>(string strSqlOrStoredProcedureName, U parameters, string strConnectionId = "dbSqlConnection");
    Task<int> ExecuteAsync<U>(string strSqlOrStoredProcedureName, U parameters, string strConnectionId = "dbSqlConnection");
}