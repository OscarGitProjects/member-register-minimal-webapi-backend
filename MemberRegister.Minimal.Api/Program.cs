using MemberRegister.DataAccess.DataAccess;
using MemberRegister.Minimal.Api;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddLogging();
builder.Services.AddSingleton<ISqlDataAccess, SqlDataAccess>();
builder.Services.AddSingleton<ISqlDataAccessFactory, SqlDataAccessFactory>();
builder.Services.AddSingleton<IMemberData, MemberData>();
builder.Services.AddSingleton<IMemberDataSQL, MemberDataSQL>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.ConfigureMemberApi();

app.ConfigureMemberSQLApi();

//app.MapGet(pattern: "/Members", async ([FromServices]MemberData memberData) => { 
//    return await memberData.GetMembersAsync();
//});

app.Run();