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
    [Migration("20231004130712_Initials")]
    partial class Initials
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
                        .HasMaxLength(350)
                        .HasColumnType("nvarchar(350)")
                        .HasColumnName("APIKey");

                    b.Property<string>("AuthType")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("AuthUrl")
                        .HasMaxLength(350)
                        .HasColumnType("nvarchar(350)");

                    b.Property<string>("ConsumerKey")
                        .HasMaxLength(350)
                        .HasColumnType("nvarchar(350)");

                    b.Property<string>("ConsumerSecret")
                        .HasMaxLength(350)
                        .HasColumnType("nvarchar(350)");

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
                        .HasMaxLength(350)
                        .HasColumnType("nvarchar(350)")
                        .HasColumnName("OAuthToken");

                    b.Property<string>("OauthTokenSecret")
                        .HasMaxLength(350)
                        .HasColumnType("nvarchar(350)")
                        .HasColumnName("OAuthTokenSecret");

                    b.Property<string>("Password")
                        .HasMaxLength(350)
                        .HasColumnType("nvarchar(350)");

                    b.Property<string>("Token")
                        .HasMaxLength(350)
                        .HasColumnType("nvarchar(350)");

                    b.Property<string>("UserName")
                        .HasMaxLength(350)
                        .HasColumnType("nvarchar(350)");

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
                        .HasMaxLength(350)
                        .HasColumnType("nvarchar(350)");

                    b.Property<string>("Body")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContentType")
                        .HasMaxLength(350)
                        .HasColumnType("nvarchar(350)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsSuccessful")
                        .HasColumnType("bit");

                    b.Property<string>("NextUrl")
                        .HasMaxLength(350)
                        .HasColumnType("nvarchar(350)");

                    b.Property<string>("ResourceUrl")
                        .HasMaxLength(350)
                        .HasColumnType("nvarchar(350)");

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

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Key")
                        .HasMaxLength(350)
                        .HasColumnType("nvarchar(350)");

                    b.Property<int?>("ReqId")
                        .HasColumnType("int")
                        .HasColumnName("ReqID");

                    b.Property<string>("Value")
                        .HasMaxLength(350)
                        .HasColumnType("nvarchar(350)");

                    b.HasKey("Id");

                    b.HasIndex("ReqId");

                    b.ToTable("Header", (string)null);
                });

            modelBuilder.Entity("Connector.Models.QueryParameter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Key")
                        .HasMaxLength(350)
                        .HasColumnType("nvarchar(350)");

                    b.Property<int?>("ReqId")
                        .HasColumnType("int")
                        .HasColumnName("ReqID");

                    b.Property<string>("Value")
                        .HasMaxLength(350)
                        .HasColumnType("nvarchar(350)");

                    b.HasKey("Id")
                        .HasName("PK_QueryParams");

                    b.HasIndex("ReqId");

                    b.ToTable("QueryParameters");
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

            modelBuilder.Entity("Connector.Models.QueryParameter", b =>
                {
                    b.HasOne("Connector.Models.ApiRequest", "Req")
                        .WithMany("QueryParameters")
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

                    b.Navigation("QueryParameters");
                });
#pragma warning restore 612, 618
        }
    }
}
