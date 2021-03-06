// <auto-generated />
using System;
using Library.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Library.DAL.Migrations
{
    [DbContext(typeof(BooksDBContext))]
    partial class BooksDBModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Library.Domain.Connections.Authors_Books", b =>
                {
                    b.Property<int>("AuthorID")
                        .HasColumnType("int");

                    b.Property<int>("BookID")
                        .HasColumnType("int");

                    b.HasKey("AuthorID", "BookID");

                    b.HasIndex("BookID");

                    b.ToTable("Authors_Books");
                });

            modelBuilder.Entity("Library.Domain.Connections.Genres_Books", b =>
                {
                    b.Property<string>("GenreName")
                        .HasColumnType("varchar(50)");

                    b.Property<int>("BookID")
                        .HasColumnType("int");

                    b.HasKey("GenreName", "BookID");

                    b.HasIndex("BookID");

                    b.ToTable("Genres_Books");
                });

            modelBuilder.Entity("Library.Domain.Entities.Author", b =>
                {
                    b.Property<int>("AuthorID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("Birthday")
                        .HasColumnType("date");

                    b.Property<string>("MiddleName")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("AuthorID");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("Library.Domain.Entities.Book", b =>
                {
                    b.Property<int>("BookID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("varchar(500)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("PublisherName")
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Year")
                        .IsRequired()
                        .HasColumnType("varchar(4)");

                    b.HasKey("BookID");

                    b.HasIndex("PublisherName");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("Library.Domain.Entities.Genre", b =>
                {
                    b.Property<string>("GenreName")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Description")
                        .HasColumnType("varchar(500)");

                    b.HasKey("GenreName");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("Library.Domain.Entities.Publisher", b =>
                {
                    b.Property<string>("PublisherName")
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnName("Adress")
                        .HasColumnType("varchar(200)");

                    b.Property<string>("EMail")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Phone")
                        .HasColumnType("varchar(50)");

                    b.HasKey("PublisherName");

                    b.ToTable("Publishers");
                });

            modelBuilder.Entity("Library.Domain.Connections.Authors_Books", b =>
                {
                    b.HasOne("Library.Domain.Entities.Author", "Author")
                        .WithMany("Authors_Books")
                        .HasForeignKey("AuthorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Library.Domain.Entities.Book", "Book")
                        .WithMany("Authors_Books")
                        .HasForeignKey("BookID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Library.Domain.Connections.Genres_Books", b =>
                {
                    b.HasOne("Library.Domain.Entities.Book", "Books")
                        .WithMany("Genres_Books")
                        .HasForeignKey("BookID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Library.Domain.Entities.Genre", "Genre")
                        .WithMany("Genres_Books")
                        .HasForeignKey("GenreName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Library.Domain.Entities.Book", b =>
                {
                    b.HasOne("Library.Domain.Entities.Publisher", "Publisher")
                        .WithMany("Books")
                        .HasForeignKey("PublisherName");
                });
#pragma warning restore 612, 618
        }
    }
}
