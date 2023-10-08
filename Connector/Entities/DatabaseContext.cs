using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Connector.Entities;

public partial class DatabaseContext : DbContext
{
    public DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ApiDetail> ApiDetails { get; set; }

    public virtual DbSet<ApiRequest> ApiRequests { get; set; }

    public virtual DbSet<Header> Headers { get; set; }

    public virtual DbSet<QueryParameter> QueryParameters { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            // add IConfigurationRoot  to get connection string 
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("Default"));
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ApiDetail>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Apikey)
                .HasMaxLength(1000)
                .HasColumnName("APIKey");
            entity.Property(e => e.AuthType).HasMaxLength(10);
            entity.Property(e => e.AuthUrl).HasMaxLength(550);
            entity.Property(e => e.ConsumerKey).HasMaxLength(1000);
            entity.Property(e => e.ConsumerSecret).HasMaxLength(1000);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Method).HasMaxLength(10);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.OauthToken)
                .HasMaxLength(1000)
                .HasColumnName("OAuthToken");
            entity.Property(e => e.OauthTokenSecret)
                .HasMaxLength(1000)
                .HasColumnName("OAuthTokenSecret");
            entity.Property(e => e.Password).HasMaxLength(1000);
            entity.Property(e => e.Token).HasMaxLength(1000);
            entity.Property(e => e.UserName).HasMaxLength(1000);
        });

        modelBuilder.Entity<ApiRequest>(entity =>
        {
            entity.ToTable("ApiRequest");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ApiId).HasColumnName("ApiID");
            entity.Property(e => e.BaseUrl).HasMaxLength(550);
            entity.Property(e => e.ContentType).HasMaxLength(350);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Method).HasMaxLength(10);
            entity.Property(e => e.NextUrl).HasMaxLength(550);
            entity.Property(e => e.RequestBody).HasMaxLength(350);
            entity.Property(e => e.ResourceUrl).HasMaxLength(550);

            entity.HasOne(d => d.Api).WithMany(p => p.ApiRequests)
                .HasForeignKey(d => d.ApiId)
                .HasConstraintName("FK_ApiRequest_ApiRequest");
        });

        modelBuilder.Entity<Header>(entity =>
        {
            entity.ToTable("Header");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Key).HasMaxLength(1000);
            entity.Property(e => e.ReqId).HasColumnName("ReqID");
            entity.Property(e => e.Value).HasMaxLength(1000);

            entity.HasOne(d => d.Req).WithMany(p => p.Headers)
                .HasForeignKey(d => d.ReqId)
                .HasConstraintName("FK_Header_ApiRequest");
        });

        modelBuilder.Entity<QueryParameter>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_QueryParams");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Key).HasMaxLength(1000);
            entity.Property(e => e.ReqId).HasColumnName("ReqID");
            entity.Property(e => e.Value).HasMaxLength(1000);

            entity.HasOne(d => d.Req).WithMany(p => p.QueryParameters)
                .HasForeignKey(d => d.ReqId)
                .HasConstraintName("FK_QueryParameters_ApiRequest");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
