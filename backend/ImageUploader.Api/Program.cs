using Microsoft.Extensions.FileProviders;
var b=WebApplication.CreateBuilder(args);
b.Services.AddControllers(); b.Services.AddEndpointsApiExplorer(); b.Services.AddSwaggerGen();
b.Services.AddCors(o=>o.AddDefaultPolicy(p=>p.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));
var app=b.Build(); app.UseSwagger(); app.UseSwaggerUI(); app.UseCors();
Directory.CreateDirectory("uploads");
app.UseStaticFiles(new StaticFileOptions{FileProvider=new PhysicalFileProvider(Path.Combine(app.Environment.ContentRootPath,"uploads")),RequestPath="/uploads"});
app.MapControllers(); app.Run();