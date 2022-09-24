global using System.Security.Claims;
global using System.Reflection;
global using AutoMapper;

global using Microsoft.AspNetCore.Mvc;
global using Microsoft.AspNetCore.Authentication.Cookies;
global using Microsoft.AspNetCore.Authorization;
global using Microsoft.AspNetCore.Authentication;

global using Portal.UI_MVC_Web.MappingProfiles;
global using Portal.UI_MVC_Web.Controllers.Absract;
global using Portal.UI_MVC_Web.Services;
global using Portal.UI_MVC_Web.Models.Course;
global using Portal.UI_MVC_Web.Models.Materials;
global using Portal.UI_MVC_Web.Models.Perk;
global using Portal.UI_MVC_Web.Models.Auth;
global using Portal.UI_MVC_Web.Interfaces;
global using Portal.Domain.Entities.User;
global using Portal.Domain.Entities.Material.Specification;
global using Portal.Domain.Entities.Perk.Specification;
global using Portal.Domain.Entities.User.Specification;
global using Portal.Application;
global using Portal.Application.DTO;
global using Portal.Application.Interfaces.InnerImpl.Services;
global using Portal.Application.Interfaces.InnerImpl;