using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EstudiantesInfrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "GE");

            migrationBuilder.CreateTable(
                name: "EstadoEstudiante",
                schema: "GE",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoEstudiante", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EstadoProfesor",
                schema: "GE",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoProfesor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EstudianteMateria",
                schema: "GE",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstudianteMateria", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Materia",
                schema: "GE",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materia", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoDocumento",
                schema: "GE",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoDocumento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Estudiantes",
                schema: "GE",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Documento = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Sexo = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FechaIngreso = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaEgreso = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaRetiro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TipoDocumentoId = table.Column<int>(type: "int", nullable: false),
                    EstadoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estudiantes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Estudiantes_EstadoEstudiante_EstadoId",
                        column: x => x.EstadoId,
                        principalSchema: "GE",
                        principalTable: "EstadoEstudiante",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Estudiantes_TipoDocumento_TipoDocumentoId",
                        column: x => x.TipoDocumentoId,
                        principalSchema: "GE",
                        principalTable: "TipoDocumento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Profesor",
                schema: "GE",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Documento = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TipoDocumentoId = table.Column<int>(type: "int", nullable: false),
                    EstadoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profesor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Profesor_EstadoProfesor_EstadoId",
                        column: x => x.EstadoId,
                        principalSchema: "GE",
                        principalTable: "EstadoProfesor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Profesor_TipoDocumento_TipoDocumentoId",
                        column: x => x.TipoDocumentoId,
                        principalSchema: "GE",
                        principalTable: "TipoDocumento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EstudiantesXMateria",
                schema: "GE",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstudianteId = table.Column<int>(type: "int", nullable: false),
                    MateriaId = table.Column<int>(type: "int", nullable: false),
                    EstadoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstudiantesXMateria", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EstudiantesXMateria_EstudianteMateria_EstadoId",
                        column: x => x.EstadoId,
                        principalSchema: "GE",
                        principalTable: "EstudianteMateria",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EstudiantesXMateria_Estudiantes_EstudianteId",
                        column: x => x.EstudianteId,
                        principalSchema: "GE",
                        principalTable: "Estudiantes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EstudiantesXMateria_Materia_MateriaId",
                        column: x => x.MateriaId,
                        principalSchema: "GE",
                        principalTable: "Materia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProfesorXMateria",
                schema: "GE",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfesorId = table.Column<int>(type: "int", nullable: false),
                    MateriaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfesorXMateria", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProfesorXMateria_Materia_MateriaId",
                        column: x => x.MateriaId,
                        principalSchema: "GE",
                        principalTable: "Materia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProfesorXMateria_Profesor_ProfesorId",
                        column: x => x.ProfesorId,
                        principalSchema: "GE",
                        principalTable: "Profesor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Estudiantes_Documento",
                schema: "GE",
                table: "Estudiantes",
                column: "Documento",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Estudiantes_EstadoId",
                schema: "GE",
                table: "Estudiantes",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Estudiantes_TipoDocumentoId",
                schema: "GE",
                table: "Estudiantes",
                column: "TipoDocumentoId");

            migrationBuilder.CreateIndex(
                name: "IX_EstudiantesXMateria_EstadoId",
                schema: "GE",
                table: "EstudiantesXMateria",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_EstudiantesXMateria_EstudianteId",
                schema: "GE",
                table: "EstudiantesXMateria",
                column: "EstudianteId");

            migrationBuilder.CreateIndex(
                name: "IX_EstudiantesXMateria_MateriaId",
                schema: "GE",
                table: "EstudiantesXMateria",
                column: "MateriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Materia_Code",
                schema: "GE",
                table: "Materia",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Profesor_Documento",
                schema: "GE",
                table: "Profesor",
                column: "Documento",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Profesor_EstadoId",
                schema: "GE",
                table: "Profesor",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Profesor_TipoDocumentoId",
                schema: "GE",
                table: "Profesor",
                column: "TipoDocumentoId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfesorXMateria_MateriaId",
                schema: "GE",
                table: "ProfesorXMateria",
                column: "MateriaId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfesorXMateria_ProfesorId",
                schema: "GE",
                table: "ProfesorXMateria",
                column: "ProfesorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EstudiantesXMateria",
                schema: "GE");

            migrationBuilder.DropTable(
                name: "ProfesorXMateria",
                schema: "GE");

            migrationBuilder.DropTable(
                name: "EstudianteMateria",
                schema: "GE");

            migrationBuilder.DropTable(
                name: "Estudiantes",
                schema: "GE");

            migrationBuilder.DropTable(
                name: "Materia",
                schema: "GE");

            migrationBuilder.DropTable(
                name: "Profesor",
                schema: "GE");

            migrationBuilder.DropTable(
                name: "EstadoEstudiante",
                schema: "GE");

            migrationBuilder.DropTable(
                name: "EstadoProfesor",
                schema: "GE");

            migrationBuilder.DropTable(
                name: "TipoDocumento",
                schema: "GE");
        }
    }
}
