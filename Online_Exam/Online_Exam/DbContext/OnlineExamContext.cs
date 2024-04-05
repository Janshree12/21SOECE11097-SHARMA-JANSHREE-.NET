using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Online_Exam;
public class OnlineExamContext : DbContext
{
    public OnlineExamContext()
    {

    }

    public OnlineExamContext(DbContextOptions<OnlineExamContext> options) : base(options) 
    {
        
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("CON");
            optionsBuilder.UseSqlServer("Data Source=LAPTOP-B1VUAQ0K;Initial Catalog=OnlineExam;Integrated Security=True;TrustServerCertificate=true");

        }
    }

   /* protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);*/
}
