using MachineMaintenanceScheduler;
using MachineMaintenanceScheduler.Features.Machines.Interfaces;
using MachineMaintenanceScheduler.Features.Machines.Repositories;
using MachineMaintenanceScheduler.Features.Machines.Services;
using MachineMaintenanceScheduler.Features.Machines.Validators;
using MachineMaintenanceScheduler.Features.Skills.Interfaces;
using MachineMaintenanceScheduler.Features.Skills.Repositories;
using MachineMaintenanceScheduler.Features.Skills.Services;
using MachineMaintenanceScheduler.Features.Skills.Validators;
using MachineMaintenanceScheduler.Features.Technicians.Interfaces;
using MachineMaintenanceScheduler.Features.Technicians.Repositories;
using MachineMaintenanceScheduler.Features.Technicians.Services;
using MachineMaintenanceScheduler.Features.Technicians.Validators;
using MachineMaintenanceScheduler.Features.WorkingHours.Interfaces;
using MachineMaintenanceScheduler.Features.WorkingHours.Repositories;
using MachineMaintenanceScheduler.Features.WorkingHours.Services;
using MachineMaintenanceScheduler.Shared.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddScoped<ITechnicianService, TechnicianService>();
builder.Services.AddScoped<ITechnicianValidator, TechnicianValidator>();
builder.Services.AddSingleton<ITechnicianRepository, InMemoryTechnicianRepository>();

builder.Services.AddScoped<ISkillService, SkillService>();
builder.Services.AddScoped<ISkillValidator, SkillValidator>();
builder.Services.AddSingleton<ISkillRepository, InMemorySkillRepository>();

builder.Services.AddScoped<IMachineService, MachineService>();
builder.Services.AddScoped<IMachineValidator, MachineValidator>();
builder.Services.AddSingleton<IMachineRepository, InMemoryMachineRepository>();

builder.Services.AddScoped<IScheduleRepository, InMemoryScheduleRepository>();
builder.Services.AddScoped<IScheduleService, ScheduleService>();
builder.Services.AddScoped<IScheduleTemplateService, ScheduleTemplateService>();

builder.Services.AddScoped<IToastService, ToastService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
