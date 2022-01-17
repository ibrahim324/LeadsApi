using Microsoft.EntityFrameworkCore;
using LeadsApi.EFCoreModels;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<LeadsDatabaseContext>(opt =>
    opt.UseSqlite("Filename=LeadsDatabase.db"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

var app = builder.Build();

app.MapGet("/", () => "Welcome to the Leads-API!");

app.MapGet("/leads", async (LeadsDatabaseContext dbContext) =>
    await dbContext.Leads.Select(lead => lead).ToListAsync());

app.MapGet("/leads/{name}", async (string name, LeadsDatabaseContext dbContext) => 
    await dbContext.Leads
    .Where(lead => lead.Name.Contains(name))
    .Select(lead => lead)
    .ToListAsync());
        

app.Run();