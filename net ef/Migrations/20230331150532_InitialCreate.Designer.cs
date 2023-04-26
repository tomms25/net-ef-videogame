using net_ef_videogame.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace net_ef_videogame.Migrations
{
    [DbContext(typeof(VideogameContext))]
    [Migration("20230331150532_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("net_ef_videogame.SoftwareHouse", b =>
            {
                b.Property<long>("SoftwareHouseId")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("bigint");

                SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("SoftwareHouseId"));

                b.Property<string>("Name")
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");

                b.HasKey("SoftwareHouseId");

                b.ToTable("software_houses");
            });

            modelBuilder.Entity("net_ef_videogame.Videogame", b =>
            {
                b.Property<long>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("bigint");

                SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                b.Property<string>("Name")
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("Overview")
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");

                b.Property<DateTime>("ReleaseDate")
                    .HasColumnType("datetime2");

                b.Property<long>("SoftwareHouseId")
                    .HasColumnType("bigint");

                b.HasKey("Id");

                b.HasIndex("SoftwareHouseId");

                b.ToTable("videogames");
            });

            modelBuilder.Entity("net_ef_videogame.Videogame", b =>
            {
                b.HasOne("net_ef_videogame.SoftwareHouse", "SoftwareHouse")
                    .WithMany("Videogames")
                    .HasForeignKey("SoftwareHouseId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.Navigation("SoftwareHouse");
            });

            modelBuilder.Entity("net_ef_videogame.SoftwareHouse", b =>
            {
                b.Navigation("Videogames");
            });
#pragma warning restore 612, 618
        }
    }
}