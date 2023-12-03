﻿// <auto-generated />
using System;
using Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Domain.AggregateModels.CampeonatoModels.Campeonato", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<DateTime>("DataFim")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataInicio")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ModalidadeCampeonatoId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<long>("OrganizadorId")
                        .HasColumnType("bigint");

                    b.Property<int>("QuantidadeRodadas")
                        .HasColumnType("int");

                    b.Property<int?>("StatusCampeonatoId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int?>("TipoCampeonatoId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ModalidadeCampeonatoId");

                    b.HasIndex("OrganizadorId");

                    b.HasIndex("StatusCampeonatoId");

                    b.HasIndex("TipoCampeonatoId");

                    b.ToTable("Campeonato", (string)null);
                });

            modelBuilder.Entity("Domain.AggregateModels.CampeonatoModels.EquipeInscricao", b =>
                {
                    b.Property<long>("EquipeId")
                        .HasColumnType("bigint");

                    b.Property<long>("InscricaoId")
                        .HasColumnType("bigint");

                    b.Property<long>("Id")
                        .HasColumnType("bigint");

                    b.HasKey("EquipeId", "InscricaoId");

                    b.HasIndex("InscricaoId");

                    b.ToTable("EquipeInscricao", (string)null);
                });

            modelBuilder.Entity("Domain.AggregateModels.CampeonatoModels.Inscricao", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<long?>("CampeonatoId")
                        .IsRequired()
                        .HasColumnType("bigint");

                    b.Property<DateTime>("DataFim")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataInicio")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CampeonatoId")
                        .IsUnique();

                    b.ToTable("Inscricao", (string)null);
                });

            modelBuilder.Entity("Domain.AggregateModels.CampeonatoModels.ModalidadeCampeonato", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("ModalidadeCampeonato", (string)null);
                });

            modelBuilder.Entity("Domain.AggregateModels.CampeonatoModels.StatusCampeonato", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("StatusCampeonato", (string)null);
                });

            modelBuilder.Entity("Domain.AggregateModels.CampeonatoModels.TipoCampeonato", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("TipoCampeonato", (string)null);
                });

            modelBuilder.Entity("Domain.AggregateModels.Equipe", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<long>("GerenteId")
                        .HasColumnType("bigint");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.HasKey("Id");

                    b.HasIndex("GerenteId")
                        .IsUnique();

                    b.ToTable("Equipe", (string)null);
                });

            modelBuilder.Entity("Domain.AggregateModels.EquipeUsuario", b =>
                {
                    b.Property<long>("EquipeId")
                        .HasColumnType("bigint");

                    b.Property<long>("UsuarioId")
                        .HasColumnType("bigint");

                    b.HasKey("EquipeId", "UsuarioId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("EquipeUsuario", (string)null);
                });

            modelBuilder.Entity("Domain.AggregateModels.Partida", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<long>("CampeonatoId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("DataFim")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataInicio")
                        .HasColumnType("datetime2");

                    b.Property<long?>("EquipeAId")
                        .HasColumnType("bigint");

                    b.Property<long?>("EquipeBId")
                        .HasColumnType("bigint");

                    b.Property<long?>("EquipeVencedoraId")
                        .HasColumnType("bigint");

                    b.Property<long?>("ProximaPartidaId")
                        .HasColumnType("bigint");

                    b.Property<int>("Rodada")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CampeonatoId");

                    b.HasIndex("EquipeAId");

                    b.HasIndex("EquipeBId");

                    b.HasIndex("EquipeVencedoraId");

                    b.HasIndex("ProximaPartidaId");

                    b.ToTable("Partida", (string)null);
                });

            modelBuilder.Entity("Domain.AggregateModels.Perfil", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<long?>("UsuarioId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.HasIndex("UsuarioId");

                    b.ToTable("UsuarioPerfil", (string)null);
                });

            modelBuilder.Entity("Domain.AggregateModels.Usuario", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<bool>("Ativo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("Usuario", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<long>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("RoleId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("PerfilPermissao", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<long>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UsuarioPermissao", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<long>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("UsuarioLogin", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<long>", b =>
                {
                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.Property<long>("RoleId")
                        .HasColumnType("bigint");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("UsuarioPerfilUsuario", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<long>", b =>
                {
                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("UsuarioToken", (string)null);
                });

            modelBuilder.Entity("Domain.AggregateModels.CampeonatoModels.Campeonato", b =>
                {
                    b.HasOne("Domain.AggregateModels.CampeonatoModels.ModalidadeCampeonato", "ModalidadeCampeonato")
                        .WithMany()
                        .HasForeignKey("ModalidadeCampeonatoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.AggregateModels.Usuario", "Organizador")
                        .WithMany()
                        .HasForeignKey("OrganizadorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.AggregateModels.CampeonatoModels.StatusCampeonato", "StatusCampeonato")
                        .WithMany()
                        .HasForeignKey("StatusCampeonatoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.AggregateModels.CampeonatoModels.TipoCampeonato", "TipoCampeonato")
                        .WithMany()
                        .HasForeignKey("TipoCampeonatoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ModalidadeCampeonato");

                    b.Navigation("Organizador");

                    b.Navigation("StatusCampeonato");

                    b.Navigation("TipoCampeonato");
                });

            modelBuilder.Entity("Domain.AggregateModels.CampeonatoModels.EquipeInscricao", b =>
                {
                    b.HasOne("Domain.AggregateModels.Equipe", "Equipe")
                        .WithMany("Campeonatos")
                        .HasForeignKey("EquipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.AggregateModels.CampeonatoModels.Inscricao", "Inscricao")
                        .WithMany("Equipes")
                        .HasForeignKey("InscricaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Equipe");

                    b.Navigation("Inscricao");
                });

            modelBuilder.Entity("Domain.AggregateModels.CampeonatoModels.Inscricao", b =>
                {
                    b.HasOne("Domain.AggregateModels.CampeonatoModels.Campeonato", "Campeonato")
                        .WithOne("Inscricao")
                        .HasForeignKey("Domain.AggregateModels.CampeonatoModels.Inscricao", "CampeonatoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Campeonato");
                });

            modelBuilder.Entity("Domain.AggregateModels.Equipe", b =>
                {
                    b.HasOne("Domain.AggregateModels.Usuario", "Gerente")
                        .WithOne("EquipeGerenciada")
                        .HasForeignKey("Domain.AggregateModels.Equipe", "GerenteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Gerente");
                });

            modelBuilder.Entity("Domain.AggregateModels.EquipeUsuario", b =>
                {
                    b.HasOne("Domain.AggregateModels.Equipe", "Equipe")
                        .WithMany("Jogadores")
                        .HasForeignKey("EquipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.AggregateModels.Usuario", "Usuario")
                        .WithMany("Equipes")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Equipe");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Domain.AggregateModels.Partida", b =>
                {
                    b.HasOne("Domain.AggregateModels.CampeonatoModels.Campeonato", "Campeonato")
                        .WithMany("Partidas")
                        .HasForeignKey("CampeonatoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.AggregateModels.Equipe", "EquipeA")
                        .WithMany()
                        .HasForeignKey("EquipeAId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("Domain.AggregateModels.Equipe", "EquipeB")
                        .WithMany()
                        .HasForeignKey("EquipeBId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("Domain.AggregateModels.Equipe", "EquipeVencedora")
                        .WithMany()
                        .HasForeignKey("EquipeVencedoraId");

                    b.HasOne("Domain.AggregateModels.Partida", "ProximaPartida")
                        .WithMany()
                        .HasForeignKey("ProximaPartidaId");

                    b.Navigation("Campeonato");

                    b.Navigation("EquipeA");

                    b.Navigation("EquipeB");

                    b.Navigation("EquipeVencedora");

                    b.Navigation("ProximaPartida");
                });

            modelBuilder.Entity("Domain.AggregateModels.Perfil", b =>
                {
                    b.HasOne("Domain.AggregateModels.Usuario", null)
                        .WithMany("UserRoles")
                        .HasForeignKey("UsuarioId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<long>", b =>
                {
                    b.HasOne("Domain.AggregateModels.Perfil", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<long>", b =>
                {
                    b.HasOne("Domain.AggregateModels.Usuario", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<long>", b =>
                {
                    b.HasOne("Domain.AggregateModels.Usuario", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<long>", b =>
                {
                    b.HasOne("Domain.AggregateModels.Perfil", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.AggregateModels.Usuario", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<long>", b =>
                {
                    b.HasOne("Domain.AggregateModels.Usuario", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.AggregateModels.CampeonatoModels.Campeonato", b =>
                {
                    b.Navigation("Inscricao")
                        .IsRequired();

                    b.Navigation("Partidas");
                });

            modelBuilder.Entity("Domain.AggregateModels.CampeonatoModels.Inscricao", b =>
                {
                    b.Navigation("Equipes");
                });

            modelBuilder.Entity("Domain.AggregateModels.Equipe", b =>
                {
                    b.Navigation("Campeonatos");

                    b.Navigation("Jogadores");
                });

            modelBuilder.Entity("Domain.AggregateModels.Usuario", b =>
                {
                    b.Navigation("EquipeGerenciada")
                        .IsRequired();

                    b.Navigation("Equipes");

                    b.Navigation("UserRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
