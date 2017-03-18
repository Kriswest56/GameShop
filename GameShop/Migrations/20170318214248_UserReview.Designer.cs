using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using GameShop.Models;

namespace GameShop.Migrations
{
    [DbContext(typeof(GameShopContext))]
    [Migration("20170318214248_UserReview")]
    partial class UserReview
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GameShop.Models.Consoles", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<decimal>("Price");

                    b.HasKey("ID");

                    b.ToTable("Console");
                });

            modelBuilder.Entity("GameShop.Models.Game", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Console")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<decimal>("Price");

                    b.Property<DateTime>("ReleaseDate");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.HasKey("ID");

                    b.ToTable("Game");
                });

            modelBuilder.Entity("GameShop.Models.UserReview", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("game")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("rating")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("review");

                    b.HasKey("ID");

                    b.ToTable("UserReview");
                });
        }
    }
}
