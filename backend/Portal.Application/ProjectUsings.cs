global using System.Reflection;
global using System.Configuration;

global using Portal.Application.Interfaces.Other;
global using Portal.Application.Interfaces.OuterImpl;
global using Portal.Application.Interfaces.InnerImpl;
global using Portal.Application.Interfaces.InnerImpl.Services;
global using Portal.Application.MappingProfiles;
global using Portal.Application.Services.Abstract;
global using Portal.Application.Services.Config;
global using Portal.Application.Services.Auth;
global using Portal.Application.Services.Rules;
global using Portal.Application.Services;
global using Newtonsoft.Json;

global using Portal.Application.DTO;

global using Portal.Domain.Entities;
global using Portal.Domain.Entities.Perk;
global using Portal.Domain.Entities.Material;
global using Portal.Domain.Entities.User;
global using Portal.Domain.Entities.Course;
global using Portal.Domain.Entities.Abstract;
global using Portal.Domain.Exceptions;

global using Microsoft.Extensions.DependencyInjection;

global using AutoMapper;