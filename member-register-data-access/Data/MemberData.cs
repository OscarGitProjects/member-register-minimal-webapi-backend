using MemberRegister.DataAccess.DataAccess;
using MemberRegister.DataAccess.Models;

namespace MemberRegister.DataAccess.Data;


/// <summary>
/// This class is a interface that implements CRUD methods for this project
/// </summary>
public class MemberData : IMemberData
{
    private readonly ISqlDataAccess m_SqlDataAccess;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="sqlDataAccess">Reference to the data access object</param>
    public MemberData(ISqlDataAccess sqlDataAccess)
    {
        this.m_SqlDataAccess = sqlDataAccess;
    }


    /// <summary>
    /// Method return IEnumerable with members
    /// </summary>
    /// <returns>IEnumerable with members</returns>
    public async Task<IEnumerable<Member>> GetMembersAsync()
    {
        return await m_SqlDataAccess.LoadDataAsync<Member, dynamic>(strStoredProcedureName: "dbo.usp_Members_GetMembers", new { });
    }


    /// <summary>
    /// Method return a member
    /// </summary>
    /// <param name="id">Id for member we want</param>
    /// <returns>member</returns>
    public async Task<Member?> GetMemberAsync(int id)
    {
        Member? member = null;
        var members = await m_SqlDataAccess.LoadDataAsync<Member, dynamic>(strStoredProcedureName: "dbo.usp_Members_GetMember", new { Id = id });

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
        // Fornamn, Efternamn, Adress, Postnummer, Postort, Skapatdatum, Senastuppdateraddatum
        int iNumerOfRowsAffected = await m_SqlDataAccess.SaveDataAsync(strStoredProcedureName: "dbo.usp_Members_InsertMember", new { member.Fornamn, member.Efternamn, member.Adress, member.Postnummer, member.Postort, member.Skapatdatum, member.Senastuppdateraddatum });
        return iNumerOfRowsAffected;
    }


    /// <summary>
    /// Method update information about a member
    /// </summary>
    /// <param name="member">member</param>
    /// <returns>Number of rows affected</returns>
    public async Task<int> UpdateMemberAsync(Member member)
    {
        // Fornamn, Efternamn, Adress, Postnummer, Postort, Skapatdatum, Senastuppdateraddatum
        int iNumerOfRowsAffected = await m_SqlDataAccess.SaveDataAsync(strStoredProcedureName: "dbo.usp_Members_UpdateMember", new { member.Id, member.Fornamn, member.Efternamn, member.Adress, member.Postnummer, member.Postort, member.Skapatdatum, member.Senastuppdateraddatum });
        return iNumerOfRowsAffected;
    }


    /// <summary>
    /// Method delete a member
    /// </summary>
    /// <param name="id">Id for member we want to delete</param>
    /// <returns>Number of rows affected</returns>
    public async Task<int> DeleteMemberAsync(int id)
    {
        int iNumerOfRowsAffected = await m_SqlDataAccess.SaveDataAsync(strStoredProcedureName: "dbo.usp_Members_DeleteMember", new { Id = id });
        return iNumerOfRowsAffected;
    }
}