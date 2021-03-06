// <auto-generated />
using System;
using MenuApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MenuApp.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220322101317_newtableaddedok5")]
    partial class newtableaddedok5
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.15")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MenuApp.Models.Itemname", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("item")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("itemnames");
                });

            modelBuilder.Entity("MenuApp.Models.MenuModel", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Itemid")
                        .HasColumnType("int");

                    b.Property<int?>("Itemnameid")
                        .HasColumnType("int");

                    b.Property<int>("Userid")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("Itemnameid");

                    b.HasIndex("Userid");

                    b.ToTable("MenuModel");
                });

            modelBuilder.Entity("MenuApp.Models.User", b =>
                {
                    b.Property<int>("userid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("userid");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MenuApp.Models.MenuModel", b =>
                {
                    b.HasOne("MenuApp.Models.Itemname", "Itemname")
                        .WithMany("Itemid")
                        .HasForeignKey("Itemnameid");

                    b.HasOne("MenuApp.Models.User", "user")
                        .WithMany("Itemid")
                        .HasForeignKey("Userid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Itemname");

                    b.Navigation("user");
                });

            modelBuilder.Entity("MenuApp.Models.Itemname", b =>
                {
                    b.Navigation("Itemid");
                });

            modelBuilder.Entity("MenuApp.Models.User", b =>
                {
                    b.Navigation("Itemid");
                });
#pragma warning restore 612, 618
        }
    }
}
