var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseDefaultFiles();
app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.MapFallback(async (context) =>
{
    var phpath = Path.Join(app.Environment.WebRootPath, context.Request.Path);
    var name = Path.Combine(Path.GetDirectoryName(phpath)!, "index.html");
    if (File.Exists(name))
    {
        context.Response.StatusCode = 200;
        await context.Response.SendFileAsync(name);
    }
});

app.Run();