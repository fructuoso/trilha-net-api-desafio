using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TrilhaApiDesafio.Context;
using TrilhaApiDesafio.Models;


public class DbInitializer : IDbInitializer
{
    private readonly IServiceScopeFactory _scopeFactory;

    public DbInitializer(IServiceScopeFactory scopeFactory, OrganizadorContext context)
    {
        _scopeFactory = scopeFactory;
    }

    public void Initialize()
    {
        using (var serviceScope = _scopeFactory.CreateScope())
        {
            using (var context = serviceScope.ServiceProvider.GetService<OrganizadorContext>())
            {
                context.Database.Migrate();
            }
        }
    }

    public void SeedData()
    {
        using (var serviceScope = _scopeFactory.CreateScope())
        {
            using (var context = serviceScope.ServiceProvider.GetService<OrganizadorContext>())
            {
                context.Database.EnsureCreated();

                context.Tarefas.Add(new Tarefa()
                {
                    Id = 1,
                    Titulo = "Tarefa 1",
                    Descricao = "Descrição da tarefa 1",
                    Data = System.DateTime.Now,
                    Status = EnumStatusTarefa.Pendente
                });

                context.Tarefas.Add(new Tarefa()
                {
                    Id = 2,
                    Titulo = "Tarefa 2",
                    Descricao = "Descrição da tarefa 2",
                    Data = System.DateTime.Now.AddDays(2),
                    Status = EnumStatusTarefa.Finalizado
                });

                context.SaveChanges();
            }
        }
    }
}