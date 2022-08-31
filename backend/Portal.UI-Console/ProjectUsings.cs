global using System.Diagnostics.CodeAnalysis;
global using System.Text.RegularExpressions;
global using System.Text;

global using Portal.Domain.Interfaces;
global using Portal.Application.Interfaces.InnerImpl.Services;
global using Portal.Application.Interfaces.InnerImpl;
global using Portal.Application.DTO;
global using Portal.UI_Console.CommandManagement;
global using Portal.UI_Console.CommandManagement.ChooseCommand;
global using Portal.UI_Console.ConsoleCommands.Modify.Course;
global using Portal.UI_Console.ConsoleCommands.Modify.Course.Add;
global using Portal.UI_Console.ConsoleCommands.Modify.Course.Remove;
global using Portal.UI_Console.ConsoleCommands.Other;
global using Portal.UI_Console.ConsoleCommands.Modify.Materials.Article;
global using Portal.UI_Console.ConsoleCommands.Auth;
global using Portal.UI_Console.ConsoleCommands.Get;
global using Portal.UI_Console.ConsoleCommands.Modify.Materials.Book;
global using Portal.UI_Console.ConsoleCommands.Modify.Materials.Video;
global using Portal.UI_Console.ConsoleCommands.Modify.Skills;
global using Portal.UI_Console.ConsoleCommands.Menu.General;
global using Portal.UI_Console.ConsoleCommands.Menu;
global using Portal.UI_Console.Interfaces;
global using Portal.UI_Console.Parsers;

global using Microsoft.Extensions.DependencyInjection;