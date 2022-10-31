using Microsoft.Extensions.Configuration;

namespace MemberRegister.DataAccess.DataAccess;

public enum TypeOfSqlAccess
{
    NA = 0,
    SQL = 1,
    STOREDPROCEDURE = 2
}

public class SqlDataAccessFactory : ISqlDataAccessFactory
{
    /// <summary>
    /// Method return a SqlDataAccess object
    /// </summary>
    /// <param name="typeOfSqlAccess">Type of SqlAccess we want. SQL och StoredProcedure</param>
    /// <param name="configuration">Reference to configuration object</param>
    /// <returns></returns>
    public ISqlDataAccess? GetSqlDataAccess(TypeOfSqlAccess typeOfSqlAccess, IConfiguration configuration)
    {
        ISqlDataAccess? sqlDataAccess = null;

        switch (typeOfSqlAccess)
        {
            case TypeOfSqlAccess.SQL:
                sqlDataAccess = new SqlDataAccess(configuration);
                break;
            case TypeOfSqlAccess.STOREDPROCEDURE:
                sqlDataAccess = new SqlDataStoredProcedureAccess(configuration);
                break;
        }

        return sqlDataAccess;
    }
}
