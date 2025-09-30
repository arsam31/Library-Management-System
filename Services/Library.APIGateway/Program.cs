using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


string routefile = string.Format("ocelot.{0}.json", builder.Environment.EnvironmentName);
builder.Configuration.SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile(routefile, optional: false, reloadOnChange: true);

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.UseOcelot().Wait();
app.Run();
app.Run();
