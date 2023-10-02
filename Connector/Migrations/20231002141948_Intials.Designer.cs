﻿// <auto-generated />
using System;
using Connector.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Connector.Migrations
{
    [DbContext(typeof(ConnectorContext))]
    [Migration("20231002141948_Intials")]
    partial class Intials
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Connector.Models.ApiDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Apikey")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("APIKey");

                    b.Property<string>("AuthType")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("AuthUrl")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("ConsumerKey")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ConsumerSecret")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Method")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("OauthToken")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("OAuthToken");

                    b.Property<string>("OauthTokenSecret")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("OAuthTokenSecret");

                    b.Property<string>("Password")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Token")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("UserName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("ApiDetails");
                });

            modelBuilder.Entity("Connector.Models.ApiRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ApiId")
                        .HasColumnType("int")
                        .HasColumnName("ApiID");

                    b.Property<string>("BaseUrl")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsSuccessfull")
                        .HasColumnType("bit");

                    b.Property<string>("NextUrl")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("ResourceUrl")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Id");

                    b.HasIndex("ApiId");

                    b.ToTable("ApiRequest", (string)null);
                });

            modelBuilder.Entity("Connector.Models.Header", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Hkey")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("HKey");

                    b.Property<string>("Hvalue")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("HValue");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int?>("ReqId")
                        .HasColumnType("int")
                        .HasColumnName("ReqID");

                    b.HasKey("Id");

                    b.HasIndex("ReqId");

                    b.ToTable("Header", (string)null);
                });

            modelBuilder.Entity("Connector.Models.QueryParam", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Qkey")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("QKey");

                    b.Property<string>("Qvalue")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("QValue");

                    b.Property<int?>("ReqId")
                        .HasColumnType("int")
                        .HasColumnName("ReqID");

                    b.HasKey("Id");

                    b.HasIndex("ReqId");

                    b.ToTable("QueryParams");
                });

            modelBuilder.Entity("Connector.Models.ApiRequest", b =>
                {
                    b.HasOne("Connector.Models.ApiDetail", "Api")
                        .WithMany("ApiRequests")
                        .HasForeignKey("ApiId")
                        .HasConstraintName("FK_ApiRequest_ApiRequest");

                    b.Navigation("Api");
                });

            modelBuilder.Entity("Connector.Models.Header", b =>
                {
                    b.HasOne("Connector.Models.ApiRequest", "Req")
                        .WithMany("Headers")
                        .HasForeignKey("ReqId")
                        .HasConstraintName("FK_Header_ApiRequest");

                    b.Navigation("Req");
                });

            modelBuilder.Entity("Connector.Models.QueryParam", b =>
                {
                    b.HasOne("Connector.Models.ApiRequest", "Req")
                        .WithMany("QueryParams")
                        .HasForeignKey("ReqId")
                        .HasConstraintName("FK_QueryParams_ApiRequest");

                    b.Navigation("Req");
                });

            modelBuilder.Entity("Connector.Models.ApiDetail", b =>
                {
                    b.Navigation("ApiRequests");
                });

            modelBuilder.Entity("Connector.Models.ApiRequest", b =>
                {
                    b.Navigation("Headers");

                    b.Navigation("QueryParams");
                });
#pragma warning restore 612, 618
        }
    }
}
