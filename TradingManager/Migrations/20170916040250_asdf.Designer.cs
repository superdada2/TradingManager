using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using TradingManager.Model;

namespace TradingManager.Migrations
{
    [DbContext(typeof(TMDbContext))]
    [Migration("20170916040250_asdf")]
    partial class asdf
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasDefaultSchema("TM")
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TradingManager.Model.Transactions", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("Amount");

                    b.Property<int>("Exchange");

                    b.Property<double>("Leverage");

                    b.Property<int>("OrderType");

                    b.Property<decimal>("Price");

                    b.Property<int>("Symbol");

                    b.Property<string>("TransactionId");

                    b.Property<DateTime>("TransactionTime")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<int>("TransactionType");

                    b.Property<decimal>("TranscationFee");

                    b.Property<string>("UserId");

                    b.Property<int?>("UserId1");

                    b.HasKey("Id");

                    b.HasIndex("UserId1");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("TradingManager.Model.Users", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("Password");

                    b.Property<string>("UserName");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TradingManager.Model.Transactions", b =>
                {
                    b.HasOne("TradingManager.Model.Users", "User")
                        .WithMany("Transactions")
                        .HasForeignKey("UserId1");
                });
        }
    }
}
