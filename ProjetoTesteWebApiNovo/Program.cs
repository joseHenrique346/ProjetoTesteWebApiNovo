using Microsoft.AspNetCore.Mvc;
using ProjetoTesteWebApiNovo.Extension;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureContext(builder.Configuration);
builder.Services.ConfigureInjectionDependency();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.InvalidModelStateResponseFactory = context =>
    {
        var errors = context.ModelState
            .Select(kvp =>
            {
                string fieldName = kvp.Key; // Nome do campo com erro, ex: listTInputCreateDTO[2].Code
                string errorMessage = kvp.Value.Errors.First().ErrorMessage; // Pega a mensagem de erro

                // Express�o regular para encontrar a posi��o do array dentro de colchetes []
                var match = System.Text.RegularExpressions.Regex.Match(fieldName, @"\[(\d+)\]");
                string position = match.Success ? $"(Posi��o {int.Parse(match.Groups[1].Value) + 1})" : ""; // Incrementa 1 no �ndice

                return $"{errorMessage} {position}".Trim();
            })
            .ToList();

        return new BadRequestObjectResult(new { message = errors });
    };
});

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.MapControllers();

app.Run();
