using Dapper;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace MemberRegister.DataAccess.DataAccess;

/// <summary>
/// Simple C# Data Access with Dapper and SQL - Minimal API Project Part 1
/// https://www.youtube.com/watch?v=dwMFg6uxQ0I
/// 
/// Data access code. Uses dapper
/// Use this when u have use SQL
/// </summary>
public class SqlDataAccess : ISqlDataAccess
{
    private readonly IConfiguration m_Config;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="config">Reference to configuration object</param>
    public SqlDataAccess(IConfiguration config)
    {
        this.m_Config = config;
    }


    /// <summary>
    /// Select
    /// Method get data from database
    /// </summary>
    /// <typeparam name="T">Class of data we want back</typeparam>
    /// <typeparam name="U">Class of data we send as parameters</typeparam>
    /// <param name="strSqlOrStoredProcedureName">Name of the stored procedure</param>
    /// <param name="parameters">Parameters</param>
    /// <param name="strConnectionId">Id for the connectionstring</param>
    /// <returns>IEnumerable with data</returns>
    public async Task<IEnumerable<T>> QueryAsync<T, U>(string strSqlOrStoredProcedureName, U parameters, string strConnectionId = "dbSqlConnection")
    {
        using (IDbConnection connection = new SqlConnection(m_Config.GetConnectionString(strConnectionId)))
        {
            return await connection.QueryAsync<T>(strSqlOrStoredProcedureName, parameters, commandType: CommandType.Text);
        };
    }


    /// <summary>
    /// Insert, Update or delete
    /// Method insert, update or delete data in the database
    /// </summary>
    /// <typeparam name="U">Class of data we send as parameters</typeparam>
    /// <param name="strSqlOrStoredProcedureName">Name of the stored procedure</param>
    /// <param name="parameters">Parameters</param>
    /// <param name="strConnectionId">Id for the connectionstring</param>
    /// <returns>Number of rows affected</returns>
    public async Task<int> ExecuteAsync<U>(string strSqlOrStoredProcedureName, U parameters, string strConnectionId = "dbSqlConnection")
    {
        using (IDbConnection connection = new SqlConnection(m_Config.GetConnectionString(strConnectionId)))
        {
            return await connection.ExecuteAsync(strSqlOrStoredProcedureName, parameters, commandType: CommandType.Text);
        };
    }
}
