using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;

const string _corsPolicyName = "AllHosts";
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy(_corsPolicyName, builder => builder.AllowAnyOrigin()
                                                .AllowAnyHeader()
                                                 .AllowAnyMethod());
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var client = new AmazonDynamoDBClient();
builder.Services.AddSingleton<IAmazonDynamoDB>(client);
builder.Services.AddSingleton<IDynamoDBContext, DynamoDBContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseCors(_corsPolicyName);

app.UseAuthorization();

app.MapControllers();

app.Run();
