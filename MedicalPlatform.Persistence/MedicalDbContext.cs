using MedicalPlatform.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalPlatform.Persistence
{
    public class MedicalDbContext(DbContextOptions<MedicalDbContext> options): DbContext(options)
    {
        public DbSet<UserEntity> Users { get; set; }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.ApplyConfigurationsFromAssembly(typeof(MedicalDbContext).Assembly);

        //}
    }
}
