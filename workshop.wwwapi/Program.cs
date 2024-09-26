using Microsoft.EntityFrameworkCore;
using workshop.wwwapi.Data;
using workshop.wwwapi.Endpoints;
using workshop.wwwapi.Models;
using workshop.wwwapi.Repository;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(opt => {
    opt.UseInMemoryDatabase("Complaints");
});
builder.Services.AddCors();
builder.Services.AddScoped<IRepository<ComplaintDetails>, Repository<ComplaintDetails>>();
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors(x => x
                  .AllowAnyMethod()
                  .AllowAnyHeader()
                  .SetIsOriginAllowed(origin => true) 
                  .AllowCredentials()); 
}
app.UseHttpsRedirection();
app.ConfigureComplaintsEndpoint();
app.Run();

