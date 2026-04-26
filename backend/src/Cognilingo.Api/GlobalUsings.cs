// Global using directives

global using System.Text;
global using Cognilingo.Api.Common.Controllers;
global using Cognilingo.Api.Simulations.Payloads;
global using Cognilingo.Application.Common.Responses.Base;
global using Cognilingo.Application.Identity.Commands.Login;
global using Cognilingo.Application.Identity.Commands.RefreshTokens;
global using Cognilingo.Application.Identity.Commands.Register;
global using Cognilingo.Application.Identity.Queries.GetLoggedUser;
global using Cognilingo.Application.Simulations.Commands.SendMessage;
global using Cognilingo.Application.Simulations.Commands.StartSimulation;
global using Cognilingo.Application.Simulations.Queries.ListCategories;
global using Cognilingo.Application.Simulations.Queries.ListSituations;
global using Cognilingo.Application.Simulations.Queries.ListSimulationMessages;
global using Cognilingo.Infrastructure.Common.Persistence;
global using Cognilingo.Infrastructure.Identity.Options;
global using MediatR;
global using Microsoft.AspNetCore.Authentication.JwtBearer;
global using Microsoft.AspNetCore.Authorization;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.IdentityModel.Tokens;
global using NSwag;
global using NSwag.Generation.Processors.Security;