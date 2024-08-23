using Microsoft.EntityFrameworkCore;

namespace Wpm.Clinic.Api.Infrastructure;

public class ClinicDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<ConsultationEventData> Consultations { get; set; }
    
}

public static class ClinicDbContextExtensions
{
    public static void EnsureDbIsCreated(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        var context = scope.ServiceProvider.GetService<ClinicDbContext>();
        context.Database.EnsureCreated();
        context.Database.CloseConnection();
    }
}

public record ConsultationEventData(Guid Id,
                                    string AggregateId,
                                    string EventName,
                                    string Data,
                                    string AssemblyQualifiedName);