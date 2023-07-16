﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using PhoneBook.Data.DataAccess.Context;

#nullable disable

namespace PhoneBook.Data.DataAccess.Migrations
{
    [DbContext(typeof(PhoneBookContext))]
    partial class PhoneBookContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("PhoneBook.Data.Entities.Concrete.Book", b =>
                {
                    b.Property<Guid>("UUID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Company")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("Deleted")
                        .HasColumnType("boolean");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("UUID");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("PhoneBook.Data.Entities.Concrete.BookContact", b =>
                {
                    b.Property<Guid>("UUID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("BookUUID")
                        .HasColumnType("uuid");

                    b.Property<bool>("Deleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Information")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.HasKey("UUID");

                    b.HasIndex("BookUUID");

                    b.ToTable("BookContacts");
                });

            modelBuilder.Entity("PhoneBook.Data.Entities.Concrete.BookContact", b =>
                {
                    b.HasOne("PhoneBook.Data.Entities.Concrete.Book", "Book")
                        .WithMany("BookContacts")
                        .HasForeignKey("BookUUID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");
                });

            modelBuilder.Entity("PhoneBook.Data.Entities.Concrete.Book", b =>
                {
                    b.Navigation("BookContacts");
                });
#pragma warning restore 612, 618
        }
    }
}
