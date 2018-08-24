using Microsoft.EntityFrameworkCore;

namespace BloodsportApi.Models
{
    public partial class BloodsportContext : DbContext
    {

        public BloodsportContext(DbContextOptions<BloodsportContext> options)  
                : base(options)
        {
        }

        public virtual DbSet<Consulta> Consulta { get; set; }
        public virtual DbSet<Especialidad> Especialidad { get; set; }
        public virtual DbSet<ObraSocial> ObraSocial { get; set; }
        public virtual DbSet<Paciente> Paciente { get; set; }
        public virtual DbSet<PacienteObraSocial> PacienteObraSocial { get; set; }
        public virtual DbSet<PracticaMedica> PracticaMedica { get; set; }
        public virtual DbSet<Profesional> Profesional { get; set; }
        public virtual DbSet<TipoPracticaMedica> TiposPracticaMedica { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

//         protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//         {
//             if (!optionsBuilder.IsConfigured)
//             {
// #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                 optionsBuilder.UseMySql(Configuration.GetConnectionString("BloodsportDatabase"));
//             }
//         }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Consulta>(entity =>
            {
                entity.HasKey(e => e.IdConsulta);

                entity.ToTable("consultas");

                entity.HasIndex(e => e.IdProfesional)
                    .HasName("fk_consultas_profesionales1_idx");

                entity.HasIndex(e => new { e.IdPaciente, e.IdObraSocial })
                    .HasName("fk_consultas_id_paciente_id_obra_social_idx");

                entity.Property(e => e.IdConsulta)
                    .HasColumnName("id_consulta")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FechaConsulta)
                    .HasColumnName("fecha_consulta")
                    .HasColumnType("timestamp");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnName("fecha_creacion")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'");

                entity.Property(e => e.FechaModificacion)
                    .HasColumnName("fecha_modificacion")
                    .HasColumnType("timestamp");

                entity.Property(e => e.IdObraSocial)
                    .HasColumnName("id_obra_social")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.IdPaciente)
                    .HasColumnName("id_paciente")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdProfesional)
                    .HasColumnName("id_profesional")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Particular)
                    .HasColumnName("particular")
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("'b\\'0\\''");

                entity.HasOne(d => d.IdPacienteNavigation)
                    .WithMany(p => p.Consultas)
                    .HasForeignKey(d => d.IdPaciente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_consultas_id_paciente");

                entity.HasOne(d => d.IdProfesionalNavigation)
                    .WithMany(p => p.Consultas)
                    .HasForeignKey(d => d.IdProfesional)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_consultas_id_profesional");

                entity.HasOne(d => d.Id)
                    .WithMany(p => p.Consultas)
                    .HasForeignKey(d => new { d.IdPaciente, d.IdObraSocial })
                    .HasConstraintName("fk_consultas_id_paciente_id_obra_social");
            });

            modelBuilder.Entity<Especialidad>(entity =>
            {
                entity.HasKey(e => e.IdEspecialidad);

                entity.ToTable("especialidades");

                entity.Property(e => e.IdEspecialidad)
                    .HasColumnName("id_especialidad")
                    .HasColumnType("short(5)");

                entity.Property(e => e.NombreEspecialidad)
                    .HasColumnName("nombre_especialidad")
                    .HasColumnType("varchar(60)");
                
                entity.Property(e => e.FechaCreacion)
                    .HasColumnName("fecha_creacion")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'");

                entity.Property(e => e.FechaModificacion)
                    .HasColumnName("fecha_modificacion")
                    .HasColumnType("timestamp");
            });

            modelBuilder.Entity<ObraSocial>(entity =>
            {
                entity.HasKey(e => e.IdObraSocial);

                entity.ToTable("obras_sociales");

                entity.Property(e => e.IdObraSocial)
                    .HasColumnName("id_obra_social")
                    .HasColumnType("smallint(5)");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnName("fecha_creacion")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'");

                entity.Property(e => e.FechaModificacion)
                    .HasColumnName("fecha_modificacion")
                    .HasColumnType("timestamp");

                entity.Property(e => e.NombreObraSocial)
                    .IsRequired()
                    .HasColumnName("nombre_obra_social")
                    .HasColumnType("varchar(100)");
            });

            modelBuilder.Entity<Paciente>(entity =>
            {
                entity.HasKey(e => e.IdPaciente);

                entity.ToTable("pacientes");

                entity.HasIndex(e => e.IdProfesionalCabecera)
                    .HasName("fk_pacientes_id_profesional_cabecera_idx");

                entity.Property(e => e.IdPaciente)
                    .HasColumnName("id_paciente")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Apellido)
                    .IsRequired()
                    .HasColumnName("apellido")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.Dni)
                    .HasColumnName("dni")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Edad)
                    .HasColumnName("edad")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnName("fecha_creacion")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'");

                entity.Property(e => e.FechaModificacion)
                    .HasColumnName("fecha_modificacion")
                    .HasColumnType("timestamp");

                entity.Property(e => e.FechaNacimiento)
                    .HasColumnName("fecha_nacimiento")
                    .HasColumnType("timestamp");

                entity.Property(e => e.IdProfesionalCabecera)
                    .HasColumnName("id_profesional_cabecera")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasColumnType("varchar(100)");

                entity.HasOne(d => d.IdProfesionalCabeceraNavigation)
                    .WithMany(p => p.Pacientes)
                    .HasForeignKey(d => d.IdProfesionalCabecera)
                    .HasConstraintName("fk_pacientes_id_profesional_cabecera");
            });

            modelBuilder.Entity<PacienteObraSocial>(entity =>
            {
                entity.HasKey(e => new { e.IdPaciente, e.IdObraSocial });

                entity.ToTable("pacientes_obras_sociales");

                entity.HasIndex(e => e.IdObraSocial)
                    .HasName("fk_pacientes_obras_sociales_id_obra_social_idx");

                entity.Property(e => e.IdPaciente)
                    .HasColumnName("id_paciente")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdObraSocial)
                    .HasColumnName("id_obra_social")
                    .HasColumnType("smallint(5)");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnName("fecha_creacion")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'");

                entity.Property(e => e.FechaModificacion)
                    .HasColumnName("fecha_modificacion")
                    .HasColumnType("timestamp");

                entity.Property(e => e.NumeroAsociado)
                    .HasColumnName("numero_asociado")
                    .HasColumnType("varchar(20)");

                entity.HasOne(d => d.IdObraSocialNavigation)
                    .WithMany(p => p.PacientesObrasSociales)
                    .HasForeignKey(d => d.IdObraSocial)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_pacientes_obras_sociales_id_obra_social");

                entity.HasOne(d => d.IdPacienteNavigation)
                    .WithMany(p => p.PacientesObrasSociales)
                    .HasForeignKey(d => d.IdPaciente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_pacientes_obras_sociales_id_paciente");
            });

            modelBuilder.Entity<PracticaMedica>(entity =>
            {
                entity.HasKey(e => e.IdPracticaMedica);

                entity.ToTable("practicas_medicas");

                entity.HasIndex(e => e.IdConsulta)
                    .HasName("fk_practicas_medicas_consultas1_idx");

                entity.HasIndex(e => e.IdProfesional)
                    .HasName("fk_practicas_medicas_profesionales1_idx");

                entity.HasIndex(e => e.IdTipoPracticaMedica)
                    .HasName("fk_practicas_medicas_id_tipo_practica_medica_idx");

                entity.Property(e => e.IdPracticaMedica)
                    .HasColumnName("id_practica_medica")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnName("fecha_creacion")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'");

                entity.Property(e => e.FechaModificacion)
                    .HasColumnName("fecha_modificacion")
                    .HasColumnType("timestamp");

                entity.Property(e => e.FechaPracticaMedica)
                    .HasColumnName("fecha_practica_medica")
                    .HasColumnType("timestamp");

                entity.Property(e => e.IdConsulta)
                    .HasColumnName("id_consulta")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdProfesional)
                    .HasColumnName("id_profesional")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdTipoPracticaMedica)
                    .HasColumnName("id_tipo_practica_medica")
                    .HasColumnType("smallint(5)");

                entity.Property(e => e.TiposPracticaMedicaIdTipoPracticaMedica)
                    .HasColumnName("tipos_practica_medica_id_tipo_practica_medica")
                    .HasColumnType("smallint(6)");

                entity.HasOne(d => d.IdConsultaNavigation)
                    .WithMany(p => p.PracticasMedicas)
                    .HasForeignKey(d => d.IdConsulta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_practicas_medicas_id_consultas");

                entity.HasOne(d => d.IdProfesionalNavigation)
                    .WithMany(p => p.PracticasMedicas)
                    .HasForeignKey(d => d.IdProfesional)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_practicas_medicas_id_profesional");

                entity.HasOne(d => d.IdTipoPracticaMedicaNavigation)
                    .WithMany(p => p.PracticasMedicas)
                    .HasForeignKey(d => d.IdTipoPracticaMedica)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_practicas_medicas_id_tipo_practica_medica");
            });

            modelBuilder.Entity<Profesional>(entity =>
            {
                entity.HasKey(e => e.IdProfesional);

                entity.ToTable("profesionales");

                entity.HasIndex(e => e.IdUsuario)
                    .HasName("fk_profesional_id_usuario_idx");

                entity.Property(e => e.IdProfesional)
                    .HasColumnName("id_profesional")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnName("fecha_creacion")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'");

                entity.Property(e => e.FechaModificacion)
                    .HasColumnName("fecha_modificacion")
                    .HasColumnType("timestamp");

                entity.Property(e => e.IdEspecialidad)
                    .HasColumnName("id_especialidad")
                    .HasColumnType("smallint(5)");

                entity.Property(e => e.IdUsuario)
                    .HasColumnName("id_usuario")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Matricula)
                    .HasColumnName("matricula")
                    .HasColumnType("varchar(20)");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Profesionales)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_profesional_id_usuario");
                
                entity.HasOne(d => d.IdEspecialidadNavigation)
                    .WithMany(p => p.Profesionales)
                    .HasForeignKey(d => d.IdEspecialidad)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_profesional_id_especialidad");
            });

            modelBuilder.Entity<TipoPracticaMedica>(entity =>
            {
                entity.HasKey(e => e.IdTipoPracticaMedica);

                entity.ToTable("tipos_practica_medica");

                entity.Property(e => e.IdTipoPracticaMedica)
                    .HasColumnName("id_tipo_practica_medica")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnName("fecha_creacion")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'");

                entity.Property(e => e.FechaModificacion)
                    .HasColumnName("fecha_modificacion")
                    .HasColumnType("timestamp");

                entity.Property(e => e.NombrePractica)
                    .IsRequired()
                    .HasColumnName("nombre_practica")
                    .HasColumnType("varchar(60)");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario);

                entity.ToTable("usuarios");

                entity.HasIndex(e => e.Dni)
                    .HasName("dni_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.Email)
                    .HasName("email_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.Username)
                    .HasName("username_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.IdUsuario)
                    .HasColumnName("id_usuario")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Apellido)
                    .IsRequired()
                    .HasColumnName("apellido")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.Celular)
                    .HasColumnName("celular")
                    .HasColumnType("varchar(20)");

                entity.Property(e => e.Dni)
                    .HasColumnName("dni")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnName("fecha_creacion")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'");

                entity.Property(e => e.FechaModificacion)
                    .HasColumnName("fecha_modificacion")
                    .HasColumnType("timestamp");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasColumnType("varchar(32)");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username")
                    .HasColumnType("varchar(16)");
            });
        }
    }
}
