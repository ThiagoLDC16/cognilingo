// Global using directives

global using System.IdentityModel.Tokens.Jwt;
global using System.Security.Claims;
global using System.Security.Cryptography;
global using System.Text;
global using Cognilingo.Application.Common.Interfaces.Persistence;
global using Cognilingo.Application.Identity.Interfaces;
global using Cognilingo.Application.Identity.Interfaces.Context;
global using Cognilingo.Domain.Common.Base;
global using Cognilingo.Domain.Common.Interfaces;
global using Cognilingo.Domain.Identity.Entities;
global using Cognilingo.Domain.Simulations.Entities;
global using Cognilingo.Infrastructure.Common.Persistence.Extensions;
global using Cognilingo.Infrastructure.Common.Persistence.ValueGenerators;
global using Cognilingo.Infrastructure.Identity.Options;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.EntityFrameworkCore.ChangeTracking;
global using Microsoft.EntityFrameworkCore.Diagnostics;
global using Microsoft.EntityFrameworkCore.Metadata.Builders;
global using Microsoft.EntityFrameworkCore.ValueGeneration;
global using Microsoft.Extensions.Options;