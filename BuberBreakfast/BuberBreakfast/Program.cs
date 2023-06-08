using BuberBreakfast.Services.Breakfasts;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers();
    //mapping BreakfastService Implementation to IBreakfastService interface called in the controller 
    // constructor and use the BreakfastService object as the implementation for the interface.
    builder.Services.AddScoped<IBreakfastService,BreakfastService>();
}

var app = builder.Build();
{
    app.UseExceptionHandler("/error");
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}
