using MemberRegister.DataAccess.DataAccess;
using MemberRegister.DataAccess.Models;
using Microsoft.Extensions.Configuration;

namespace MemberRegister.DataAccess.Data;


/// <summary>
/// This class is a interface that implements CRUD methods for this project
/// Here we use SQL for manipulation data in the database
/// </summary>
public class MemberDataSQL : IMemberDataSQL
{
    private readonly ISqlDataAccess? m_SqlDataAccess = null;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="sqlDataAccess">Reference to the data access object</param>
    public MemberDataSQL(ISqlDataAccessFactory sqlDataAccessFactory, IConfiguration configuration)
    {
        if (sqlDataAccessFactory == null)
            throw new ArgumentNullException($"{nameof(MemberData)}. Reference to SqlDataAccessFactory is null");

        if (configuration == null)
            throw new ArgumentNullException($"{nameof(MemberData)}. Reference to Configuration is null");

        m_SqlDataAccess = sqlDataAccessFactory?.GetSqlDataAccess(TypeOfSqlAccess.SQL, configuration);
    }


    /// <summary>
    /// Method return IEnumerable with members
    /// </summary>
    /// <returns>IEnumerable with members</returns>
    public async Task<IEnumerable<Member>> GetMembersAsync()
    {
        return await m_SqlDataAccess.QueryAsync<Member, dynamic>(strSqlOrStoredProcedureName: "SELECT * FROM dbo.[Members]", new { });
    }


    /// <summary>
    /// Method return a member
    /// </summary>
    /// <param name="id">Id for member we want</param>
    /// <returns>member</returns>
    public async Task<Member?> GetMemberAsync(int id)
    {
        Member? member = null;
        var members = await m_SqlDataAccess.QueryAsync<Member, dynamic>(strSqlOrStoredProcedureName: "SELECT * FROM dbo.[Members] WHERE Id = @Id", new { Id = id });

        if (members != null)
            member = members.FirstOrDefault();

        return member;
    }


    /// <summary>
    /// Method insert a new member
    /// </summary>
    /// <param name="member">New member</param>
    /// <returns>Number of rows affected</returns>
    public async Task<int> InsertMemberAsync(Member member)
    {
        string sql = "INSERT INTO dbo.[Members] (Fornamn, Efternamn, Adress, Postnummer, Postort, Skapatdatum, Senastuppdateraddatum) VALUES (@Fornamn, @Efternamn, @Adress, @Postnummer, @Postort, @Skapatdatum, @Senastuppdateraddatum)";
        int iNumerOfRowsAffected = await m_SqlDataAccess.ExecuteAsync(strSqlOrStoredProcedureName: sql, new { member.Fornamn, member.Efternamn, member.Adress, member.Postnummer, member.Postort, member.Skapatdatum, member.Senastuppdateraddatum });
        return iNumerOfRowsAffected;
    }


    /// <summary>
    /// Method update information about a member
    /// </summary>
    /// <param name="member">member</param>
    /// <returns>Number of rows affected</returns>
    public async Task<int> UpdateMemberAsync(Member member)
    {
        string sql = "UPDATE dbo.[Members] SET Fornamn = @Fornamn, Efternamn = @Efternamn, Adress = @Adress, Postnummer = @Postnummer, Postort = @Postort, Skapatdatum = @Skapatdatum, Senastuppdateraddatum = @Senastuppdateraddatum WHERE Id = @Id";
        int iNumerOfRowsAffected = await m_SqlDataAccess.ExecuteAsync(strSqlOrStoredProcedureName: sql, new { member.Id, member.Fornamn, member.Efternamn, member.Adress, member.Postnummer, member.Postort, member.Skapatdatum, member.Senastuppdateraddatum });
        return iNumerOfRowsAffected;
    }


    /// <summary>
    /// Method delete a member
    /// </summary>
    /// <param name="id">Id for member we want to delete</param>
    /// <returns>Number of rows affected</returns>
    public async Task<int> DeleteMemberAsync(int id)
    {
        string sql = "DELETE FROM dbo.[Members] WHERE Id = @Id;";
        int iNumerOfRowsAffected = await m_SqlDataAccess.ExecuteAsync(strSqlOrStoredProcedureName: sql, new { Id = id });
        return iNumerOfRowsAffected;
    }
}
