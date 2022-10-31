using MemberRegister.DataAccess.Models;

namespace MemberRegister.DataAccess.Data;

public interface IMemberDataSQL
{
    Task<int> DeleteMemberAsync(int id);
    Task<IEnumerable<Member>> GetMembersAsync();
    Task<Member?> GetMemberAsync(int id);
    Task<int> InsertMemberAsync(Member member);
    Task<int> UpdateMemberAsync(Member member);
}