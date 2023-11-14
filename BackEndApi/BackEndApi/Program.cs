using BackEndApi.Models;
using Microsoft.EntityFrameworkCore;
using BackEndApi.Services.Contrato;
using BackEndApi.Services.Implementacion;
using AutoMapper;
using BackEndApi.DTOs;
using BackEndApi.Utilidades;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<PruebasContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("cadenaSQL"));
});

builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IPersonaService, PersonaService>();

builder.Services.AddAutoMapper(typeof(AutomapperProfile));

builder.Services.AddCors(options => 
{
    options.AddPolicy("NuevaPolitica", app => 
    {
        app.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

#region Personas
app.MapGet("/personas/lista", async (
    IPersonaService _personaService,
    IMapper _mapper) =>
{
    var listaPersonas = await _personaService.GetList();
    var listaPersonasDTO = _mapper.Map<List<PersonaDTO>>(listaPersonas);

    if (listaPersonasDTO.Count > 0)
    {
        return Results.Ok(listaPersonasDTO);
    }
    else
    {
        return Results.NotFound();
    }
});
app.MapPost("/personas/guardar", async (
    PersonaDTO modelo,
    IPersonaService _personaService,
    IMapper _mapper) =>
{
    var _persona = _mapper.Map<Persona>(modelo);
    var _personaCreada = await _personaService.Add(_persona);
    if (_personaCreada.Id != 0)
    {
        return Results.Ok(_mapper.Map<PersonaDTO>(_personaCreada));
    }
    else
    {
        return Results.StatusCode(StatusCodes.Status500InternalServerError);
    }
});
app.MapPut("/personas/update/{idPersona}", async (
    int idPersona,
    PersonaDTO modelo,
    IPersonaService _personaService,
    IMapper _mapper) =>
{
    var _personaEncontrada = await _personaService.GetById(idPersona);
    if (_personaEncontrada is null)
    {
        return Results.NotFound();
    }
    else
    {
        var _persona = _mapper.Map<Persona>(modelo);
        _personaEncontrada.Nombres = _persona.Nombres;
        _personaEncontrada.Apellidos = _persona.Apellidos;
        _personaEncontrada.NoIdentificacion = _persona.NoIdentificacion;
        _personaEncontrada.Email = _persona.Email;
        _personaEncontrada.TpIdentificacion = _persona.TpIdentificacion;

        var resp = await _personaService.Update(_personaEncontrada);

        if (resp)
        {
            return Results.Ok(_mapper.Map<PersonaDTO>(_personaEncontrada));
        }
        else
        {
            return Results.StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
});
app.MapDelete("/personas/delete/{idPersona}", async (
    int idPersona,
    IPersonaService _personaService) =>
{
    var _personaEncontrada = await _personaService.GetById(idPersona);
    if (_personaEncontrada is null)
    {
        return Results.NotFound();
    }

    var resp = await _personaService.Delete(_personaEncontrada);
    if (resp)
        return Results.Ok();
    else
        return Results.StatusCode(StatusCodes.Status500InternalServerError);
});
#endregion

#region Usuarios
app.MapGet("/usuarios/lista", async (
    IUsuarioService _usuarioService,
    IMapper _mapper) =>
{
    var listaUsuarios = await _usuarioService.GetList();
    var listaUsuariosDTO = _mapper.Map<List<UsuarioDTO>>(listaUsuarios);

    if (listaUsuariosDTO.Count > 0)
    {
        return Results.Ok(listaUsuariosDTO);
    }
    else
    {
        return Results.NotFound();
    }
});
app.MapPost("/usuarios/guardar", async (
    UsuarioDTO modelo,
    IUsuarioService _usuarioService,
    IMapper _mapper) =>
{
    var _usuario = _mapper.Map<Usuario>(modelo);
    var _usuarioCreada = await _usuarioService.Add(_usuario);
    if (_usuarioCreada.Id != 0)
    {
        return Results.Ok(_mapper.Map<UsuarioDTO>(_usuarioCreada));
    }
    else
    {
        return Results.StatusCode(StatusCodes.Status500InternalServerError);
    }
});
app.MapPut("/usuarios/update/{idUsuario}", async (
    int idUsuario,
    UsuarioDTO modelo,
    IUsuarioService _usuarioService,
    IMapper _mapper) =>
{
    var _usuarioEncontrado = await _usuarioService.GetById(idUsuario);
    if (_usuarioEncontrado is null)
    {
        return Results.NotFound();
    }
    else
    {
        var _usuario = _mapper.Map<Usuario>(modelo);
        _usuarioEncontrado.Usuario1 = _usuario.Usuario1;
        _usuarioEncontrado.Pass = _usuario.Pass;

        var resp = await _usuarioService.Update(_usuarioEncontrado);

        if (resp)
        {
            return Results.Ok(_mapper.Map<UsuarioDTO>(_usuarioEncontrado));
        }
        else
        {
            return Results.StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
});
app.MapDelete("/usuarios/delete/{idUsuario}", async (
    int idUsuario,
    IUsuarioService _usuarioService) =>
{
    var _usuarioEncontrada = await _usuarioService.GetById(idUsuario);
    if (_usuarioEncontrada is null)
    {
        return Results.NotFound();
    }

    var resp = await _usuarioService.Delete(_usuarioEncontrada);
    if (resp)
        return Results.Ok();
    else
        return Results.StatusCode(StatusCodes.Status500InternalServerError);
});
#endregion

app.UseCors("NuevaPolitica");

app.Run();

/*
app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateTime.Now.AddDays(index),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");

app.Run();

internal record WeatherForecast(DateTime Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}*/