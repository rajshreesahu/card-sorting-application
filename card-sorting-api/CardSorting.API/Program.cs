using CardSorting.API.Interfaces;
using CardSorting.API.Services;

var builder = WebApplication.CreateBuilder(args);

//Enable Application Insights to Azure
builder.Services.AddApplicationInsightsTelemetry();

//Add CORS Policy
builder.Services.AddCors(options =>
{
    //TODO: Allow specific origins
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
        });
}
);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddScoped<ICardSorter, CardSorter>();
builder.Services.AddScoped<ICardValidationService, CardValidationService>();

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
app.UseCors("AllowAllOrigins");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
