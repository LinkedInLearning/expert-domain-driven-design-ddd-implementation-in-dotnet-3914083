using Microsoft.EntityFrameworkCore;
using Wpm.Management.Domain.Entities;

namespace Wpm.Management.Api.Infrastructure;

public class ManagementDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Pet> Pets { get; set; }
}