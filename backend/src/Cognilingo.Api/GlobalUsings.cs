// Global using directives

global using System.Text;
global using Cognilingo.Api.Common.Controllers;
global using Cognilingo.Application.Common.Responses.Base;
global using Cognilingo.Application.Identity.Commands.Login;
global using Cognilingo.Application.Identity.Commands.RefreshTokens;
global using Cognilingo.Application.Identity.Commands.Register;
global using Cognilingo.Application.Identity.Queries.GetLoggedUser;
global using Cognilingo.Infrastructure.Identity.Options;
global using MediatR;
global using Microsoft.AspNetCore.Authentication.JwtBearer;
global using Microsoft.AspNetCore.Authorization;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.IdentityModel.Tokens;