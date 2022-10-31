using Microsoft.AspNetCore.Mvc;

namespace MemberRegister.Minimal.Api;

public static class MemberSQLApi
{
    /// <summary>
    /// Extension method to the WebApplication class
    /// </summary>
    /// <param name="app"></param>
    public static void ConfigureMemberSQLApi(this WebApplication app)
    {
        // Api endpoints
        app.MapGet(pattern: "/MembersSql", GetMembersAsync).WithName("GetMembersSql");

        app.MapGet(pattern: "/MembersSql/{id}", GetMemberAsync).WithName("GetMemberSql");

        app.MapPost(pattern: "/MembersSql", InsertMemberAsync).WithName("InsertMemberSql");

        app.MapPut(pattern: "/MembersSql", UpdateMemberAsync).WithName("UpdateMemberSql");

        app.MapDelete(pattern: "/MembersSql", DeleteMemberAsync).WithName("DeleteMemberSql");
    }


    /// <summary>
    /// Method return members
    /// </summary>
    /// <param name="memberData">MemberDataSQL object that fetch data</param>
    /// <param name="logger">Logging</param>
    /// <returns>Result.Ok with members or if a exception we return Results.Problem</returns>
    private static async Task<IResult> GetMembersAsync([FromServices] IMemberDataSQL memberData, ILogger<Program> logger)
    {
        try
        {
            return Results.Ok(await memberData.GetMembersAsync());
        }
        catch (Exception exc)
        {
            logger.LogError($"Exception in {nameof(MemberSQLApi)}->GetMembersAsync(). " + exc.ToString());
            return Results.Problem(exc.Message);
        }
    }


    /// <summary>
    /// Method return a member with memberId
    /// </summary>
    /// <param name="id">Id for member we want information about</param>
    /// <param name="memberData">MemberDataSQL object that fetch data</param>
    /// <param name="logger">Logger</param>
    /// <returns>Results.Ok with member, Results.NotFound if we cant find the member or if a exception we return Results.Problem</returns>
    private static async Task<IResult> GetMemberAsync(int id, [FromServices] IMemberDataSQL memberData, ILogger<Program> logger)
    {
        try
        {
            var member = await memberData.GetMemberAsync(id);
            if (member == null)
                return Results.NotFound($"Cant find member with id = {id}");
            return Results.Ok(member);
        }
        catch (Exception exc)
        {
            logger.LogError($"Exception in {nameof(MemberSQLApi)}->GetMemberAsync(). " + exc.ToString());
            return Results.Problem(exc.Message, statusCode: 500);
        }
    }


    /// <summary>
    /// Method create a new member
    /// </summary>
    /// <param name="member">Member object</param>
    /// <param name="memberData">MemberDataSQL object that fetch data</param>
    /// <param name="logger">Logger</param>
    /// <returns>Results.Ok if we created a new member, Results.Problem if we cant find the member or if a exception we return Results.Problem</returns>
    private static async Task<IResult> InsertMemberAsync(Member member, [FromServices] IMemberDataSQL memberData, ILogger<Program> logger)
    {
        try
        {
            int iNumerOfRowsAffected = await memberData.InsertMemberAsync(member);
            if (iNumerOfRowsAffected > 0)
                return Results.Ok();

            return Results.Problem($"Cant create member", statusCode: 500);
        }
        catch (Exception exc)
        {
            logger.LogError($"Exception in {nameof(MemberSQLApi)}->InsertMemberAsync(). " + exc.ToString());
            return Results.Problem(exc.Message, statusCode: 500);
        }
    }


    /// <summary>
    /// Method update information about a member
    /// </summary>
    /// <param name="member">Member object</param>
    /// <param name="memberData">MemberDataSQL object that fetch data</param>
    /// <param name="logger">Logger</param>
    /// <returns>Results.Ok if we updated member, Results.Problem if we cant update the member or if a exception we return Results.Problem</returns>
    private static async Task<IResult> UpdateMemberAsync(Member member, [FromServices] IMemberDataSQL memberData, ILogger<Program> logger)
    {
        try
        {
            int iNumerOfRowsAffected = await memberData.UpdateMemberAsync(member);
            if (iNumerOfRowsAffected > 0)
                return Results.Ok();

            return Results.Problem($"Cant update member", statusCode: 500);
        }
        catch (Exception exc)
        {
            logger.LogError($"Exception in {nameof(MemberSQLApi)}->UpdateMemberAsync(). " + exc.ToString());
            return Results.Problem(exc.Message, statusCode: 500);
        }
    }


    /// <summary>
    /// Method delete a member
    /// </summary>
    /// <param name="id">Id for member that we want to delete</param>
    /// <param name="memberData">MemberDataSQL object that fetch data</param>
    /// <param name="logger">Logger</param>
    /// <returns>Results.Ok if deleted member, Results.Problem if we cant delete the member or if a exception we return Results.Problem</returns>
    private static async Task<IResult> DeleteMemberAsync(int id, [FromServices] IMemberDataSQL memberData, ILogger<Program> logger)
    {
        try
        {
            int iNumerOfRowsAffected = await memberData.DeleteMemberAsync(id);
            if (iNumerOfRowsAffected > 0)
                return Results.Ok();

            return Results.Problem($"Cant delete member", statusCode: 500);
        }
        catch (Exception exc)
        {
            logger.LogError($"Exception in {nameof(MemberSQLApi)}->DeleteMemberAsync(). " + exc.ToString());
            return Results.Problem(exc.Message, statusCode: 500);
        }
    }
}
