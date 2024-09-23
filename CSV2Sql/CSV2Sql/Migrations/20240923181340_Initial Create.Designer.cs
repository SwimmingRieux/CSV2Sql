﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CSV2Sql.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240923181340_Initial Create")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("CSV2Sql.Models.Journal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("EISSN")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ISSN")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Language")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Province")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Publisher")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("YearId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("YearId")
                        .IsUnique();

                    b.ToTable("Journals");
                });

            modelBuilder.Entity("CSV2Sql.Models.Quality", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Q")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Qualities");
                });

            modelBuilder.Entity("CSV2Sql.Models.Year", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("CumulativeCitations")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ImmediateImpactFactor")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ImpactFactor")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("YearPublished")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Years");
                });

            modelBuilder.Entity("JournalQuality", b =>
                {
                    b.Property<int>("JournalsId")
                        .HasColumnType("integer");

                    b.Property<int>("QualitiesId")
                        .HasColumnType("integer");

                    b.HasKey("JournalsId", "QualitiesId");

                    b.HasIndex("QualitiesId");

                    b.ToTable("JournalQualities", (string)null);
                });

            modelBuilder.Entity("CSV2Sql.Models.Journal", b =>
                {
                    b.HasOne("CSV2Sql.Models.Year", "Year")
                        .WithOne("Journal")
                        .HasForeignKey("CSV2Sql.Models.Journal", "YearId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Year");
                });

            modelBuilder.Entity("JournalQuality", b =>
                {
                    b.HasOne("CSV2Sql.Models.Journal", null)
                        .WithMany()
                        .HasForeignKey("JournalsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CSV2Sql.Models.Quality", null)
                        .WithMany()
                        .HasForeignKey("QualitiesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CSV2Sql.Models.Year", b =>
                {
                    b.Navigation("Journal")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
