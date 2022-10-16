global using System.Reflection;

global using AutoMapper;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.Configuration;

global using Portal.Application.Interfaces.OuterImpl;
global using Portal.Domain.GenericSpecification;
global using Portal.Domain.Entities.Course;
global using Portal.Domain.Entities.Material;
global using Portal.Domain.Entities.Perk;
global using Portal.Domain.Entities.User;
global using Portal.Domain.Entities.Abstract;
global using Portal.Domain.Interfaces;
global using Portal.Persistence_EF_Core.Exceptions;
global using Portal.Persistence_EF_Core.Repositories.Abstract;
global using Portal.Persistence_EF_Core.FrameworkEntities;
global using Portal.Persistence_EF_Core.FrameworkEntities.Abstract;
global using Portal.Persistence_EF_Core.MappingProfiles;
global using Portal.Persistence_EF_Core.Repositories;
global using Portal.Persistence_EF_Core.Repositories.Extension;
