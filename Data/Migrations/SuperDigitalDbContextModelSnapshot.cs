﻿// <auto-generated />
using System;
using Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Data.Migrations
{
    [DbContext(typeof(SuperDigitalDbContext))]
    partial class SuperDigitalDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.3-rtm-32065")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.Entities.CheckingAccount", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<decimal>("Balance")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("DateModified");

                    b.Property<long>("Number");

                    b.Property<DateTime>("RegistrationDate");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("CheckingAccount");
                });

            modelBuilder.Entity("Domain.Entities.Transaction", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<decimal>("Amount")
                        .HasColumnName("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("DateModified");

                    b.Property<Guid>("FromCheckingAccountId")
                        .HasColumnName("FromCheckingAccountId");

                    b.Property<DateTime>("RegistrationDate");

                    b.Property<Guid>("ToCheckingAccountId")
                        .HasColumnName("ToCheckingAccountId");

                    b.HasKey("Id");

                    b.HasIndex("FromCheckingAccountId");

                    b.HasIndex("ToCheckingAccountId");

                    b.ToTable("Transaction");
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<DateTime?>("DateModified");

                    b.Property<string>("Email")
                        .HasColumnName("Email")
                        .HasMaxLength(150);

                    b.Property<string>("Name")
                        .HasColumnName("Name")
                        .HasMaxLength(255);

                    b.Property<string>("Password")
                        .HasColumnName("Password")
                        .HasMaxLength(255);

                    b.Property<DateTime>("RegistrationDate");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Domain.Entities.UserCode", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<Guid>("Code");

                    b.Property<DateTime?>("DateModified");

                    b.Property<DateTime>("RegistrationDate");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserCode");
                });

            modelBuilder.Entity("Domain.Entities.CheckingAccount", b =>
                {
                    b.HasOne("Domain.Entities.User", "User")
                        .WithMany("Accounts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Domain.Entities.Transaction", b =>
                {
                    b.HasOne("Domain.Entities.CheckingAccount", "FromCheckingAccount")
                        .WithMany("SentTransactions")
                        .HasForeignKey("FromCheckingAccountId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Domain.Entities.CheckingAccount", "ToCheckingAccount")
                        .WithMany("ReceivedTransactions")
                        .HasForeignKey("ToCheckingAccountId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Domain.Entities.UserCode", b =>
                {
                    b.HasOne("Domain.Entities.User", "User")
                        .WithMany("UserCodes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
