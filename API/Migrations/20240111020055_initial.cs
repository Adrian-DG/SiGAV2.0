using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Asistencia");

            migrationBuilder.EnsureSchema(
                name: "Unidad");

            migrationBuilder.EnsureSchema(
                name: "misc");

            migrationBuilder.EnsureSchema(
                name: "Miembro");

            migrationBuilder.EnsureSchema(
                name: "Ubicacion");

            migrationBuilder.EnsureSchema(
                name: "Asistencias");

            migrationBuilder.EnsureSchema(
                name: "Vehiculo");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Departamentos",
                schema: "misc",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NoReporta = table.Column<bool>(type: "INTEGER", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "TEXT", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Estatus = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    Nombre = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departamentos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Provincias",
                schema: "Ubicacion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RegionMacro = table.Column<int>(type: "INTEGER", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "TEXT", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Estatus = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    Nombre = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provincias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rangos",
                schema: "Miembro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NombreArmada = table.Column<string>(type: "TEXT", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "TEXT", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Estatus = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    Nombre = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rangos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RegionAsistencia",
                schema: "Asistencias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RegionMacro = table.Column<int>(type: "INTEGER", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "TEXT", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Estatus = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    Nombre = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegionAsistencia", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoAsistencias",
                schema: "Asistencia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CategoriaAsistencia = table.Column<int>(type: "INTEGER", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "TEXT", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Estatus = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    Nombre = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoAsistencias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoUnidades",
                schema: "Unidad",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FechaCreacion = table.Column<DateTime>(type: "TEXT", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Estatus = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    Nombre = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoUnidades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VehiculoColores",
                schema: "Vehiculo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FechaCreacion = table.Column<DateTime>(type: "TEXT", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Estatus = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    Nombre = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehiculoColores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VehiculoMarcas",
                schema: "Vehiculo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FechaCreacion = table.Column<DateTime>(type: "TEXT", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Estatus = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    Nombre = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehiculoMarcas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VehiculoPlacas",
                schema: "Vehiculo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Sigla = table.Column<string>(type: "TEXT", nullable: true),
                    TipoPlaca = table.Column<int>(type: "INTEGER", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "TEXT", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Estatus = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehiculoPlacas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VehiculoTipos",
                schema: "Vehiculo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FechaCreacion = table.Column<DateTime>(type: "TEXT", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Estatus = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    Nombre = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehiculoTipos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Nombre = table.Column<string>(type: "TEXT", nullable: true),
                    Apellido = table.Column<string>(type: "TEXT", nullable: true),
                    DepartamentoId = table.Column<int>(type: "INTEGER", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Departamentos_DepartamentoId",
                        column: x => x.DepartamentoId,
                        principalSchema: "misc",
                        principalTable: "Departamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Municipios",
                schema: "Ubicacion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProvinciaId = table.Column<int>(type: "INTEGER", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "TEXT", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Estatus = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    Nombre = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Municipios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Municipios_Provincias_ProvinciaId",
                        column: x => x.ProvinciaId,
                        principalSchema: "Ubicacion",
                        principalTable: "Provincias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tramos",
                schema: "Ubicacion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RegionAsistenciaId = table.Column<int>(type: "INTEGER", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "TEXT", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Estatus = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    Nombre = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tramos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tramos_RegionAsistencia_RegionAsistenciaId",
                        column: x => x.RegionAsistenciaId,
                        principalSchema: "Asistencias",
                        principalTable: "RegionAsistencia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VehiculoModelos",
                schema: "Vehiculo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    VehiculoMarcaId = table.Column<int>(type: "INTEGER", nullable: false),
                    VehiculoTipoId = table.Column<int>(type: "INTEGER", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "TEXT", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Estatus = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    Nombre = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehiculoModelos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VehiculoModelos_VehiculoMarcas_VehiculoMarcaId",
                        column: x => x.VehiculoMarcaId,
                        principalSchema: "Vehiculo",
                        principalTable: "VehiculoMarcas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VehiculoModelos_VehiculoTipos_VehiculoTipoId",
                        column: x => x.VehiculoTipoId,
                        principalSchema: "Vehiculo",
                        principalTable: "VehiculoTipos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderKey = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Miembros",
                schema: "Miembro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Cedula = table.Column<string>(type: "TEXT", nullable: true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: true),
                    Apellido = table.Column<string>(type: "TEXT", nullable: true),
                    Sexo = table.Column<int>(type: "INTEGER", nullable: false),
                    RangoId = table.Column<int>(type: "INTEGER", nullable: false),
                    Institucion = table.Column<int>(type: "INTEGER", nullable: false),
                    DepartamentoId = table.Column<int>(type: "INTEGER", nullable: false),
                    NivelAcceso = table.Column<int>(type: "INTEGER", nullable: false),
                    Autorizado = table.Column<bool>(type: "INTEGER", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "TEXT", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Estatus = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreadorId = table.Column<string>(type: "TEXT", nullable: true),
                    EditorId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Miembros", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Miembros_AspNetUsers_CreadorId",
                        column: x => x.CreadorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Miembros_AspNetUsers_EditorId",
                        column: x => x.EditorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Miembros_Departamentos_DepartamentoId",
                        column: x => x.DepartamentoId,
                        principalSchema: "misc",
                        principalTable: "Departamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Miembros_Rangos_RangoId",
                        column: x => x.RangoId,
                        principalSchema: "Miembro",
                        principalTable: "Rangos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Denominaciones",
                schema: "Unidad",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TramoId = table.Column<int>(type: "INTEGER", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "TEXT", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Estatus = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    Nombre = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Denominaciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Denominaciones_Tramos_TramoId",
                        column: x => x.TramoId,
                        principalSchema: "Ubicacion",
                        principalTable: "Tramos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HistoricoMiembros",
                schema: "Miembro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RangoId = table.Column<int>(type: "INTEGER", nullable: false),
                    DepartamentoId = table.Column<int>(type: "INTEGER", nullable: false),
                    MiembroId = table.Column<int>(type: "INTEGER", nullable: false),
                    Institucion = table.Column<int>(type: "INTEGER", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "TEXT", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Estatus = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoricoMiembros", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HistoricoMiembros_Departamentos_DepartamentoId",
                        column: x => x.DepartamentoId,
                        principalSchema: "misc",
                        principalTable: "Departamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HistoricoMiembros_Miembros_MiembroId",
                        column: x => x.MiembroId,
                        principalSchema: "Miembro",
                        principalTable: "Miembros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HistoricoMiembros_Rangos_RangoId",
                        column: x => x.RangoId,
                        principalSchema: "Miembro",
                        principalTable: "Rangos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Unidades",
                schema: "Unidad",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Ficha = table.Column<string>(type: "TEXT", nullable: true),
                    DenominacionId = table.Column<int>(type: "INTEGER", nullable: false),
                    TipoUnidadId = table.Column<int>(type: "INTEGER", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "TEXT", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Estatus = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Unidades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Unidades_Denominaciones_DenominacionId",
                        column: x => x.DenominacionId,
                        principalSchema: "Unidad",
                        principalTable: "Denominaciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Unidades_TipoUnidades_TipoUnidadId",
                        column: x => x.TipoUnidadId,
                        principalSchema: "Unidad",
                        principalTable: "TipoUnidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Asistencias",
                schema: "Asistencia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Identificacion = table.Column<string>(type: "TEXT", nullable: true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: true),
                    Apellido = table.Column<string>(type: "TEXT", nullable: true),
                    Sexo = table.Column<int>(type: "INTEGER", nullable: false),
                    Edad = table.Column<int>(type: "INTEGER", nullable: false),
                    EsExtranjero = table.Column<bool>(type: "INTEGER", nullable: false),
                    VehiculoTipoId = table.Column<int>(type: "INTEGER", nullable: false),
                    VehiculoColorId = table.Column<int>(type: "INTEGER", nullable: false),
                    VehiculoMarcaId = table.Column<int>(type: "INTEGER", nullable: false),
                    VehiculoModeloId = table.Column<int>(type: "INTEGER", nullable: false),
                    TipoPlaca = table.Column<int>(type: "INTEGER", nullable: false),
                    Placa = table.Column<string>(type: "TEXT", nullable: true),
                    ProvinciaId = table.Column<int>(type: "INTEGER", nullable: false),
                    MunicipioId = table.Column<int>(type: "INTEGER", nullable: false),
                    Direccion = table.Column<string>(type: "TEXT", nullable: true),
                    Coordenadas = table.Column<string>(type: "TEXT", nullable: true),
                    TramoId = table.Column<int>(type: "INTEGER", nullable: false),
                    UnidadId = table.Column<int>(type: "INTEGER", nullable: false),
                    DenominacionId = table.Column<int>(type: "INTEGER", nullable: false),
                    TipoUnidadId = table.Column<int>(type: "INTEGER", nullable: false),
                    MiembroId = table.Column<int>(type: "INTEGER", nullable: false),
                    TiempoLlegada = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TiempoCompletada = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EstatusAsistencia = table.Column<int>(type: "INTEGER", nullable: false),
                    CategoriaAsistencia = table.Column<int>(type: "INTEGER", nullable: false),
                    TipoAsistencias = table.Column<string>(type: "TEXT", nullable: true),
                    Imagenes = table.Column<string>(type: "TEXT", nullable: true),
                    Comentario = table.Column<string>(type: "TEXT", nullable: true),
                    QuienReporto = table.Column<int>(type: "INTEGER", nullable: false),
                    FueReasignada = table.Column<bool>(type: "INTEGER", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "TEXT", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Estatus = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreadorId = table.Column<string>(type: "TEXT", nullable: true),
                    EditorId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asistencias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Asistencias_AspNetUsers_CreadorId",
                        column: x => x.CreadorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Asistencias_AspNetUsers_EditorId",
                        column: x => x.EditorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Asistencias_Denominaciones_DenominacionId",
                        column: x => x.DenominacionId,
                        principalSchema: "Unidad",
                        principalTable: "Denominaciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Asistencias_Miembros_MiembroId",
                        column: x => x.MiembroId,
                        principalSchema: "Miembro",
                        principalTable: "Miembros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Asistencias_Municipios_MunicipioId",
                        column: x => x.MunicipioId,
                        principalSchema: "Ubicacion",
                        principalTable: "Municipios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Asistencias_Provincias_ProvinciaId",
                        column: x => x.ProvinciaId,
                        principalSchema: "Ubicacion",
                        principalTable: "Provincias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Asistencias_TipoUnidades_TipoUnidadId",
                        column: x => x.TipoUnidadId,
                        principalSchema: "Unidad",
                        principalTable: "TipoUnidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Asistencias_Tramos_TramoId",
                        column: x => x.TramoId,
                        principalSchema: "Ubicacion",
                        principalTable: "Tramos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Asistencias_Unidades_UnidadId",
                        column: x => x.UnidadId,
                        principalSchema: "Unidad",
                        principalTable: "Unidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Asistencias_VehiculoColores_VehiculoColorId",
                        column: x => x.VehiculoColorId,
                        principalSchema: "Vehiculo",
                        principalTable: "VehiculoColores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Asistencias_VehiculoMarcas_VehiculoMarcaId",
                        column: x => x.VehiculoMarcaId,
                        principalSchema: "Vehiculo",
                        principalTable: "VehiculoMarcas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Asistencias_VehiculoModelos_VehiculoModeloId",
                        column: x => x.VehiculoModeloId,
                        principalSchema: "Vehiculo",
                        principalTable: "VehiculoModelos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Asistencias_VehiculoTipos_VehiculoTipoId",
                        column: x => x.VehiculoTipoId,
                        principalSchema: "Vehiculo",
                        principalTable: "VehiculoTipos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HistoricoUnidades",
                schema: "Unidad",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DenominacionId = table.Column<int>(type: "INTEGER", nullable: false),
                    TipoUnidadId = table.Column<int>(type: "INTEGER", nullable: false),
                    UnidadId = table.Column<int>(type: "INTEGER", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "TEXT", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Estatus = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoricoUnidades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HistoricoUnidades_Denominaciones_DenominacionId",
                        column: x => x.DenominacionId,
                        principalSchema: "Unidad",
                        principalTable: "Denominaciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HistoricoUnidades_TipoUnidades_TipoUnidadId",
                        column: x => x.TipoUnidadId,
                        principalSchema: "Unidad",
                        principalTable: "TipoUnidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HistoricoUnidades_Unidades_UnidadId",
                        column: x => x.UnidadId,
                        principalSchema: "Unidad",
                        principalTable: "Unidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HistoricoAsistencias",
                schema: "Asistencia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UnidadId = table.Column<int>(type: "INTEGER", nullable: false),
                    MiembroId = table.Column<int>(type: "INTEGER", nullable: false),
                    AsistenciaId = table.Column<int>(type: "INTEGER", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "TEXT", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Estatus = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoricoAsistencias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HistoricoAsistencias_Asistencias_AsistenciaId",
                        column: x => x.AsistenciaId,
                        principalSchema: "Asistencia",
                        principalTable: "Asistencias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HistoricoAsistencias_Miembros_MiembroId",
                        column: x => x.MiembroId,
                        principalSchema: "Miembro",
                        principalTable: "Miembros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HistoricoAsistencias_Unidades_UnidadId",
                        column: x => x.UnidadId,
                        principalSchema: "Unidad",
                        principalTable: "Unidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Asistencias_CreadorId",
                schema: "Asistencia",
                table: "Asistencias",
                column: "CreadorId");

            migrationBuilder.CreateIndex(
                name: "IX_Asistencias_DenominacionId",
                schema: "Asistencia",
                table: "Asistencias",
                column: "DenominacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Asistencias_EditorId",
                schema: "Asistencia",
                table: "Asistencias",
                column: "EditorId");

            migrationBuilder.CreateIndex(
                name: "IX_Asistencias_MiembroId",
                schema: "Asistencia",
                table: "Asistencias",
                column: "MiembroId");

            migrationBuilder.CreateIndex(
                name: "IX_Asistencias_MunicipioId",
                schema: "Asistencia",
                table: "Asistencias",
                column: "MunicipioId");

            migrationBuilder.CreateIndex(
                name: "IX_Asistencias_ProvinciaId",
                schema: "Asistencia",
                table: "Asistencias",
                column: "ProvinciaId");

            migrationBuilder.CreateIndex(
                name: "IX_Asistencias_TipoUnidadId",
                schema: "Asistencia",
                table: "Asistencias",
                column: "TipoUnidadId");

            migrationBuilder.CreateIndex(
                name: "IX_Asistencias_TramoId",
                schema: "Asistencia",
                table: "Asistencias",
                column: "TramoId");

            migrationBuilder.CreateIndex(
                name: "IX_Asistencias_UnidadId",
                schema: "Asistencia",
                table: "Asistencias",
                column: "UnidadId");

            migrationBuilder.CreateIndex(
                name: "IX_Asistencias_VehiculoColorId",
                schema: "Asistencia",
                table: "Asistencias",
                column: "VehiculoColorId");

            migrationBuilder.CreateIndex(
                name: "IX_Asistencias_VehiculoMarcaId",
                schema: "Asistencia",
                table: "Asistencias",
                column: "VehiculoMarcaId");

            migrationBuilder.CreateIndex(
                name: "IX_Asistencias_VehiculoModeloId",
                schema: "Asistencia",
                table: "Asistencias",
                column: "VehiculoModeloId");

            migrationBuilder.CreateIndex(
                name: "IX_Asistencias_VehiculoTipoId",
                schema: "Asistencia",
                table: "Asistencias",
                column: "VehiculoTipoId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_DepartamentoId",
                table: "AspNetUsers",
                column: "DepartamentoId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Denominaciones_TramoId",
                schema: "Unidad",
                table: "Denominaciones",
                column: "TramoId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricoAsistencias_AsistenciaId",
                schema: "Asistencia",
                table: "HistoricoAsistencias",
                column: "AsistenciaId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricoAsistencias_MiembroId",
                schema: "Asistencia",
                table: "HistoricoAsistencias",
                column: "MiembroId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricoAsistencias_UnidadId",
                schema: "Asistencia",
                table: "HistoricoAsistencias",
                column: "UnidadId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricoMiembros_DepartamentoId",
                schema: "Miembro",
                table: "HistoricoMiembros",
                column: "DepartamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricoMiembros_MiembroId",
                schema: "Miembro",
                table: "HistoricoMiembros",
                column: "MiembroId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricoMiembros_RangoId",
                schema: "Miembro",
                table: "HistoricoMiembros",
                column: "RangoId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricoUnidades_DenominacionId",
                schema: "Unidad",
                table: "HistoricoUnidades",
                column: "DenominacionId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricoUnidades_TipoUnidadId",
                schema: "Unidad",
                table: "HistoricoUnidades",
                column: "TipoUnidadId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricoUnidades_UnidadId",
                schema: "Unidad",
                table: "HistoricoUnidades",
                column: "UnidadId");

            migrationBuilder.CreateIndex(
                name: "IX_Miembros_Cedula",
                schema: "Miembro",
                table: "Miembros",
                column: "Cedula",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Miembros_CreadorId",
                schema: "Miembro",
                table: "Miembros",
                column: "CreadorId");

            migrationBuilder.CreateIndex(
                name: "IX_Miembros_DepartamentoId",
                schema: "Miembro",
                table: "Miembros",
                column: "DepartamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Miembros_EditorId",
                schema: "Miembro",
                table: "Miembros",
                column: "EditorId");

            migrationBuilder.CreateIndex(
                name: "IX_Miembros_RangoId",
                schema: "Miembro",
                table: "Miembros",
                column: "RangoId");

            migrationBuilder.CreateIndex(
                name: "IX_Municipios_ProvinciaId",
                schema: "Ubicacion",
                table: "Municipios",
                column: "ProvinciaId");

            migrationBuilder.CreateIndex(
                name: "IX_Tramos_RegionAsistenciaId",
                schema: "Ubicacion",
                table: "Tramos",
                column: "RegionAsistenciaId");

            migrationBuilder.CreateIndex(
                name: "IX_Unidades_DenominacionId",
                schema: "Unidad",
                table: "Unidades",
                column: "DenominacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Unidades_Ficha",
                schema: "Unidad",
                table: "Unidades",
                column: "Ficha",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Unidades_TipoUnidadId",
                schema: "Unidad",
                table: "Unidades",
                column: "TipoUnidadId");

            migrationBuilder.CreateIndex(
                name: "IX_VehiculoModelos_VehiculoMarcaId",
                schema: "Vehiculo",
                table: "VehiculoModelos",
                column: "VehiculoMarcaId");

            migrationBuilder.CreateIndex(
                name: "IX_VehiculoModelos_VehiculoTipoId",
                schema: "Vehiculo",
                table: "VehiculoModelos",
                column: "VehiculoTipoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "HistoricoAsistencias",
                schema: "Asistencia");

            migrationBuilder.DropTable(
                name: "HistoricoMiembros",
                schema: "Miembro");

            migrationBuilder.DropTable(
                name: "HistoricoUnidades",
                schema: "Unidad");

            migrationBuilder.DropTable(
                name: "TipoAsistencias",
                schema: "Asistencia");

            migrationBuilder.DropTable(
                name: "VehiculoPlacas",
                schema: "Vehiculo");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Asistencias",
                schema: "Asistencia");

            migrationBuilder.DropTable(
                name: "Miembros",
                schema: "Miembro");

            migrationBuilder.DropTable(
                name: "Municipios",
                schema: "Ubicacion");

            migrationBuilder.DropTable(
                name: "Unidades",
                schema: "Unidad");

            migrationBuilder.DropTable(
                name: "VehiculoColores",
                schema: "Vehiculo");

            migrationBuilder.DropTable(
                name: "VehiculoModelos",
                schema: "Vehiculo");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Rangos",
                schema: "Miembro");

            migrationBuilder.DropTable(
                name: "Provincias",
                schema: "Ubicacion");

            migrationBuilder.DropTable(
                name: "Denominaciones",
                schema: "Unidad");

            migrationBuilder.DropTable(
                name: "TipoUnidades",
                schema: "Unidad");

            migrationBuilder.DropTable(
                name: "VehiculoMarcas",
                schema: "Vehiculo");

            migrationBuilder.DropTable(
                name: "VehiculoTipos",
                schema: "Vehiculo");

            migrationBuilder.DropTable(
                name: "Departamentos",
                schema: "misc");

            migrationBuilder.DropTable(
                name: "Tramos",
                schema: "Ubicacion");

            migrationBuilder.DropTable(
                name: "RegionAsistencia",
                schema: "Asistencias");
        }
    }
}
