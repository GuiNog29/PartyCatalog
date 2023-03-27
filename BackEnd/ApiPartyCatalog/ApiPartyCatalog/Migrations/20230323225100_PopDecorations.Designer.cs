﻿// <auto-generated />
using ApiPartyCatalog.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ApiPartyCatalog.Migrations
{
    [DbContext(typeof(ApiPartyCatalogContext))]
    [Migration("20230323225100_PopDecorations")]
    partial class PopDecorations
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ApiPartyCatalog.Models.Decoration", b =>
                {
                    b.Property<int>("DecorationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("DecoratorId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(5000)
                        .HasColumnType("varchar(5000)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("UrlImage")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("varchar(300)");

                    b.HasKey("DecorationId");

                    b.HasIndex("DecoratorId");

                    b.ToTable("Decorations");
                });

            modelBuilder.Entity("ApiPartyCatalog.Models.Decorator", b =>
                {
                    b.Property<int>("DecoratorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("NameDecorator")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.HasKey("DecoratorId");

                    b.ToTable("Decorators");
                });

            modelBuilder.Entity("ApiPartyCatalog.Models.Decoration", b =>
                {
                    b.HasOne("ApiPartyCatalog.Models.Decorator", "Decorator")
                        .WithMany("Decorations")
                        .HasForeignKey("DecoratorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Decorator");
                });

            modelBuilder.Entity("ApiPartyCatalog.Models.Decorator", b =>
                {
                    b.Navigation("Decorations");
                });
#pragma warning restore 612, 618
        }
    }
}
