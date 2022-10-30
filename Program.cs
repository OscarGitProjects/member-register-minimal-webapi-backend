var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();  

var app = builder.Build();

if(app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/", () => "Hello World!");

app.Run();

/* 
    Port 7209, 5077
*/

/* usp_Members_GetMembers */
/* 
[HttpGet("GetMembers")]
public async Task<ActionResult<IEnumerable<MemberDto>>> GetMembers()


[HttpGet("GetMember/{id}")]
public async Task<ActionResult<MemberDto>> GetMember(int id)


[HttpPost("CreateMember")]
public async Task<ActionResult<MemberDto>> PostMember([FromBody]MemberDto memberDto)


[HttpPut("UpdateMember/{id}")]
public async Task<ActionResult> UpdateMember(int id, [FromBody] MemberDto memberDto)


[HttpDelete("DeleteMember/{id}")]
public async Task<ActionResult> DeleteMember(int id)


[HttpGet("Ping")]
public async Task<ActionResult> Ping()


[HttpGet("GetCoffe")]
public async Task<ActionResult> BrewCoffe()
*/
