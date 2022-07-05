global using Signaturit_PT.Servicios;
using Microsoft.AspNetCore.Mvc;
using Signaturit_PT.Domain.Entities;
using Signaturit_PT.Domain.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<ISignature, SignatureService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("/getWinner", (ContractVersus contract, ISignature _iSignature) =>
{
    return _iSignature.WinnerByContract(contract); ;
})
.WithName("getWinner");

app.Run();