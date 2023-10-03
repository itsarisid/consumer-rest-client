using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Connector.Models;

public partial class ConnectorContext : DbContext
{
    public ConnectorContext()
    {
    }

    public ConnectorContext(DbContextOptions<ConnectorContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ApiDetail> ApiDetails { get; set; }

    public virtual DbSet<ApiRequest> ApiRequests { get; set; }

    public virtual DbSet<Header> Headers { get; set; }

    public virtual DbSet<QueryParam> QueryParams { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=ARISID;Database=Connector;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ApiDetail>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Apikey)
                .HasMaxLength(100)
                .HasColumnName("APIKey");
            entity.Property(e => e.AuthType).HasMaxLength(10);
            entity.Property(e => e.AuthUrl).HasMaxLength(150);
            entity.Property(e => e.ConsumerKey).HasMaxLength(100);
            entity.Property(e => e.ConsumerSecret).HasMaxLength(100);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Method).HasMaxLength(10);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.OauthToken)
                .HasMaxLength(100)
                .HasColumnName("OAuthToken");
            entity.Property(e => e.OauthTokenSecret)
                .HasMaxLength(100)
                .HasColumnName("OAuthTokenSecret");
            entity.Property(e => e.Password).HasMaxLength(100);
            entity.Property(e => e.Token).HasMaxLength(250);
            entity.Property(e => e.UserName).HasMaxLength(100);
        });

        modelBuilder.Entity<ApiRequest>(entity =>
        {
            entity.ToTable("ApiRequest");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ApiId).HasColumnName("ApiID");
            entity.Property(e => e.BaseUrl).HasMaxLength(250);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.NextUrl).HasMaxLength(250);
            entity.Property(e => e.ResourceUrl).HasMaxLength(250);

            entity.HasOne(d => d.Api).WithMany(p => p.ApiRequests)
                .HasForeignKey(d => d.ApiId)
                .HasConstraintName("FK_ApiRequest_ApiRequest");
        });

        modelBuilder.Entity<Header>(entity =>
        {
            entity.ToTable("Header");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Hkey)
                .HasMaxLength(50)
                .HasColumnName("HKey");
            entity.Property(e => e.Hvalue)
                .HasMaxLength(50)
                .HasColumnName("HValue");
            entity.Property(e => e.ReqId).HasColumnName("ReqID");

            entity.HasOne(d => d.Req).WithMany(p => p.Headers)
                .HasForeignKey(d => d.ReqId)
                .HasConstraintName("FK_Header_ApiRequest");
        });

        modelBuilder.Entity<QueryParam>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Qkey)
                .HasMaxLength(50)
                .HasColumnName("QKey");
            entity.Property(e => e.Qvalue)
                .HasMaxLength(50)
                .HasColumnName("QValue");
            entity.Property(e => e.ReqId).HasColumnName("ReqID");

            entity.HasOne(d => d.Req).WithMany(p => p.QueryParams)
                .HasForeignKey(d => d.ReqId)
                .HasConstraintName("FK_QueryParams_ApiRequest");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
