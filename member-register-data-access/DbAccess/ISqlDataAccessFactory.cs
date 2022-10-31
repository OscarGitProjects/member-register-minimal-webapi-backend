using Microsoft.Extensions.Configuration;

namespace MemberRegister.DataAccess.DataAccess;

public interface ISqlDataAccessFactory
{
    ISqlDataAccess? GetSqlDataAccess(TypeOfSqlAccess typeOfSqlAccess, IConfiguration configuration);
}
