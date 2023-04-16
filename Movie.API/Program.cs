using Movie.API.Providers;

var builder = WebApplication.CreateBuilder(args);



ConfigureServices(builder.Services, builder.Configuration);
var app = builder.Build();
Configure(app);
void  ConfigureServices(IServiceCollection services,ConfigurationManager configuration)
{
    services.AddProviderServices(configuration);
    services.AddCors(options =>
    {
        options.AddPolicy("Open", builder =>
        builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()
        .WithExposedHeaders("X-Pagination"));
    });
    // Add services to the container.
    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

}
void Configure(WebApplication app)
{
    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseHsts();
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
