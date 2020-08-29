using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TrabajoSeed.Models
{
    public partial class GrupoSeedContext : DbContext
    {
        public GrupoSeedContext()
        {
        }

        public GrupoSeedContext(DbContextOptions<GrupoSeedContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AspectosRelevantesDeLaEvaluacion> AspectosRelevantesDeLaEvaluacion { get; set; }
        public virtual DbSet<AspectosSusceptiblesDeMejora> AspectosSusceptiblesDeMejora { get; set; }
        public virtual DbSet<Cronograma> Cronograma { get; set; }
        public virtual DbSet<Documentos> Documentos { get; set; }
        public virtual DbSet<EntePublico> EntePublico { get; set; }
        public virtual DbSet<EvaluacionDelDesempeño> EvaluacionDelDesempeño { get; set; }
        public virtual DbSet<FuenteDeFinanciamiento> FuenteDeFinanciamiento { get; set; }
        public virtual DbSet<Pae> Pae { get; set; }
        public virtual DbSet<ProgramasPresupuestarios> ProgramasPresupuestarios { get; set; }
        public virtual DbSet<RequisitosDeElegibilidad> RequisitosDeElegibilidad { get; set; }
        public virtual DbSet<Sesiones> Sesiones { get; set; }
        public virtual DbSet<TipoDeEvaluacion> TipoDeEvaluacion { get; set; }
        public virtual DbSet<Ued> Ued { get; set; }
        public virtual DbSet<UserInfo> UserInfo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Server=LAPTOP-HQ43O9U4\\SQLEXPRESS;Database=GrupoSeed;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspectosRelevantesDeLaEvaluacion>(entity =>
            {
                entity.ToTable("aspectos_relevantes_de_la_evaluacion");

                entity.Property(e => e.AspectosRelevantesDeLaEvaluacionId).HasColumnName("aspectos_relevantes_de_la_evaluacion_id");

                entity.Property(e => e.Conclusiones)
                    .IsRequired()
                    .HasColumnName("conclusiones")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CoordinadorDeLaEvaluacion)
                    .IsRequired()
                    .HasColumnName("coordinador_de_la_evaluacion")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CostoDeLaEvaluacion)
                    .IsRequired()
                    .HasColumnName("costo_de_la_evaluacion")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.DescripcionDelProgramaPresupuestario)
                    .IsRequired()
                    .HasColumnName("descripcion_del_programa_presupuestario")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Documentos).HasColumnName("documentos");

                entity.Property(e => e.Evaluacion).HasColumnName("evaluacion");

                entity.Property(e => e.FormaDeContratacion)
                    .IsRequired()
                    .HasColumnName("forma_de_contratacion")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FuenteDeFinanciamiento)
                    .IsRequired()
                    .HasColumnName("fuente_de_financiamiento")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.InstanciaEvaluadora)
                    .IsRequired()
                    .HasColumnName("instancia_evaluadora")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.NombreDelResponsable)
                    .IsRequired()
                    .HasColumnName("nombre_del_responsable")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ObjetivosPrincipales)
                    .IsRequired()
                    .HasColumnName("objetivos_principales")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PrincipalesHallazgos)
                    .IsRequired()
                    .HasColumnName("principales_hallazgos")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PrincipalesRecomendaciones)
                    .IsRequired()
                    .HasColumnName("principales_recomendaciones")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PropositoDeLaEvaluacion)
                    .IsRequired()
                    .HasColumnName("proposito_de_la_evaluacion")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasColumnName("titulo")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UnidadAdministrativa)
                    .IsRequired()
                    .HasColumnName("unidad_administrativa")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.EvaluacionNavigation)
                    .WithMany(p => p.AspectosRelevantesDeLaEvaluacion)
                    .HasForeignKey(d => d.Evaluacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_evaluacion_aspectos_relevantes");
            });

            modelBuilder.Entity<AspectosSusceptiblesDeMejora>(entity =>
            {
                entity.ToTable("aspectos_susceptibles_de_mejora");

                entity.Property(e => e.AspectosSusceptiblesDeMejoraId).HasColumnName("aspectos_susceptibles_de_mejora_id");

                entity.Property(e => e.Actividades)
                    .IsRequired()
                    .HasColumnName("actividades")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.AreaCoordinadora)
                    .IsRequired()
                    .HasColumnName("area_coordinadora")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.AreasResponsables)
                    .IsRequired()
                    .HasColumnName("areas_responsables")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Avance).HasColumnName("avance");

                entity.Property(e => e.Documentos).HasColumnName("documentos");

                entity.Property(e => e.EntesPublicosParticipantes)
                    .IsRequired()
                    .HasColumnName("entes_publicos_participantes")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Evaluacion).HasColumnName("evaluacion");

                entity.Property(e => e.FechaDeTermino)
                    .HasColumnName("fecha_de_termino")
                    .HasColumnType("datetime");

                entity.Property(e => e.GobiernosMunicipalesParticipantes)
                    .IsRequired()
                    .HasColumnName("gobiernos_municipales_participantes")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.IdentificacionDelDocumento)
                    .IsRequired()
                    .HasColumnName("identificacion_del_documento")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Observaciones)
                    .IsRequired()
                    .HasColumnName("observaciones")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PrioridadDelAsm)
                    .IsRequired()
                    .HasColumnName("prioridad_del_asm")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ProductosYEvidencias)
                    .IsRequired()
                    .HasColumnName("productos_y_evidencias")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ResultadoEsperado)
                    .IsRequired()
                    .HasColumnName("resultado_esperado")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasColumnName("titulo")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UnidadResponsable)
                    .IsRequired()
                    .HasColumnName("unidad_responsable")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.EvaluacionNavigation)
                    .WithMany(p => p.AspectosSusceptiblesDeMejora)
                    .HasForeignKey(d => d.Evaluacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_evaluacion_aspectos_susceptibles");
            });

            modelBuilder.Entity<Cronograma>(entity =>
            {
                entity.ToTable("cronograma");

                entity.Property(e => e.CronogramaId).HasColumnName("cronograma_id");

                entity.Property(e => e.Avance).HasColumnName("avance");

                entity.Property(e => e.Documentos).HasColumnName("documentos");

                entity.Property(e => e.Evaluacion).HasColumnName("evaluacion");

                entity.Property(e => e.FechaDeInicio)
                    .HasColumnName("fecha_de_inicio")
                    .HasColumnType("datetime");

                entity.Property(e => e.FechaDeTermino)
                    .HasColumnName("fecha_de_termino")
                    .HasColumnType("datetime");

                entity.Property(e => e.Observaciones)
                    .IsRequired()
                    .HasColumnName("observaciones")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasColumnName("titulo")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.EvaluacionNavigation)
                    .WithMany(p => p.Cronograma)
                    .HasForeignKey(d => d.Evaluacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_evaluacion_cronograma");
            });

            modelBuilder.Entity<Documentos>(entity =>
            {
                entity.ToTable("documentos");

                entity.Property(e => e.DocumentosId).HasColumnName("documentos_id");

                entity.Property(e => e.Creado)
                    .HasColumnName("creado")
                    .HasColumnType("datetime");

                entity.Property(e => e.CreadoPor)
                    .IsRequired()
                    .HasColumnName("creado_por")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.DireccionUrl)
                    .IsRequired()
                    .HasColumnName("direccion_url")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.DireccionUrlAbsolutaCodificada)
                    .IsRequired()
                    .HasColumnName("direccion_url_absoluta_codificada")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.IdDeInstanciaDeFlujoDeTrabajo)
                    .IsRequired()
                    .HasColumnName("id_de_instancia_de_flujo_de_trabajo")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Modificado)
                    .HasColumnName("modificado")
                    .HasColumnType("datetime");

                entity.Property(e => e.ModificadoPor)
                    .IsRequired()
                    .HasColumnName("modificado_por")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.RutaDeAcceso)
                    .IsRequired()
                    .HasColumnName("ruta_de_acceso")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.TipoDeArchivo)
                    .IsRequired()
                    .HasColumnName("tipo_de_archivo")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.TipoDeContenido)
                    .IsRequired()
                    .HasColumnName("tipo_de_contenido")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.TipoDeElemento)
                    .IsRequired()
                    .HasColumnName("tipo_de_elemento")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EntePublico>(entity =>
            {
                entity.ToTable("ente_publico");

                entity.Property(e => e.EntePublicoId).HasColumnName("ente_publico_id");

                entity.Property(e => e.Acronimo)
                    .IsRequired()
                    .HasColumnName("acronimo")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Ambito)
                    .IsRequired()
                    .HasColumnName("ambito")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Documentos).HasColumnName("documentos");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PeriodoDeAdministracion)
                    .IsRequired()
                    .HasColumnName("periodo_de_administracion")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UserUed).HasColumnName("userUED");

                entity.HasOne(d => d.UserUedNavigation)
                    .WithMany(p => p.EntePublico)
                    .HasForeignKey(d => d.UserUed)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_userUED");
            });

            modelBuilder.Entity<EvaluacionDelDesempeño>(entity =>
            {
                entity.ToTable("evaluacion_del_desempeño");

                entity.Property(e => e.EvaluacionDelDesempeñoId).HasColumnName("evaluacion_del_desempeño_id");

                entity.Property(e => e.Acronimo)
                    .IsRequired()
                    .HasColumnName("acronimo")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Ambito)
                    .IsRequired()
                    .HasColumnName("ambito")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Cancelada).HasColumnName("cancelada");

                entity.Property(e => e.Costo)
                    .IsRequired()
                    .HasColumnName("costo")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Cuenta).HasColumnName("cuenta");

                entity.Property(e => e.Documentos).HasColumnName("documentos");

                entity.Property(e => e.EjercicioFiscal)
                    .IsRequired()
                    .HasColumnName("ejercicio_fiscal")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.EnProceso).HasColumnName("en_proceso");

                entity.Property(e => e.Ep).HasColumnName("ep");

                entity.Property(e => e.Estatus)
                    .IsRequired()
                    .HasColumnName("estatus")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Fecha2014).HasColumnName("fecha2014");

                entity.Property(e => e.Fecha2015).HasColumnName("fecha2015");

                entity.Property(e => e.Fecha2016).HasColumnName("fecha2016");

                entity.Property(e => e.Fecha2017).HasColumnName("fecha2017");

                entity.Property(e => e.Fondo).HasColumnName("fondo");

                entity.Property(e => e.GenerarPosicionInstitucional)
                    .IsRequired()
                    .HasColumnName("generar_posicion_institucional")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.NoIniciada).HasColumnName("no_iniciada");

                entity.Property(e => e.Pae)
                    .IsRequired()
                    .HasColumnName("pae")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ProgramaPresupuestario).HasColumnName("programa_presupuestario");

                entity.Property(e => e.Programada).HasColumnName("programada");

                entity.Property(e => e.Realizada).HasColumnName("realizada");

                entity.Property(e => e.TipoDeEvaluacion).HasColumnName("tipo_de_evaluacion");

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasColumnName("titulo")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.EpNavigation)
                    .WithMany(p => p.EvaluacionDelDesempeño)
                    .HasForeignKey(d => d.Ep)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ep_evaluacion");

                entity.HasOne(d => d.FondoNavigation)
                    .WithMany(p => p.EvaluacionDelDesempeño)
                    .HasForeignKey(d => d.Fondo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_fondo_evaluacion");

                entity.HasOne(d => d.ProgramaPresupuestarioNavigation)
                    .WithMany(p => p.EvaluacionDelDesempeño)
                    .HasForeignKey(d => d.ProgramaPresupuestario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_programa_presupuestario");

                entity.HasOne(d => d.TipoDeEvaluacionNavigation)
                    .WithMany(p => p.EvaluacionDelDesempeño)
                    .HasForeignKey(d => d.TipoDeEvaluacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tipo_de_evaluacion");
            });

            modelBuilder.Entity<FuenteDeFinanciamiento>(entity =>
            {
                entity.HasKey(e => e.FuentesDeFinanciamientoId)
                    .HasName("PK__fuente_d__B054145C1C1679AD");

                entity.ToTable("fuente_de_financiamiento");

                entity.Property(e => e.FuentesDeFinanciamientoId).HasColumnName("fuentes_de_financiamiento_id");

                entity.Property(e => e.Documentos).HasColumnName("documentos");

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasColumnName("titulo")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Pae>(entity =>
            {
                entity.ToTable("pae");

                entity.Property(e => e.PaeId).HasColumnName("pae_id");

                entity.Property(e => e.Documentos).HasColumnName("documentos");

                entity.Property(e => e.Ep).HasColumnName("ep");

                entity.Property(e => e.Pae1)
                    .IsRequired()
                    .HasColumnName("pae")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasColumnName("titulo")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.EpNavigation)
                    .WithMany(p => p.Pae)
                    .HasForeignKey(d => d.Ep)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ep_pae");
            });

            modelBuilder.Entity<ProgramasPresupuestarios>(entity =>
            {
                entity.ToTable("programas_presupuestarios");

                entity.Property(e => e.ProgramasPresupuestariosId).HasColumnName("programas_presupuestarios_id");

                entity.Property(e => e.Ambito)
                    .IsRequired()
                    .HasColumnName("ambito")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasColumnName("descripcion")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Documentos).HasColumnName("documentos");

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasColumnName("titulo")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RequisitosDeElegibilidad>(entity =>
            {
                entity.ToTable("requisitos_de_elegibilidad");

                entity.Property(e => e.RequisitosDeElegibilidadId).HasColumnName("requisitos_de_elegibilidad_id");

                entity.Property(e => e.A1r1)
                    .IsRequired()
                    .HasColumnName("a1r1")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.A2r1)
                    .IsRequired()
                    .HasColumnName("a2r1")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.A2r2)
                    .IsRequired()
                    .HasColumnName("a2r2")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.A3r1)
                    .IsRequired()
                    .HasColumnName("a3r1")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.A4r1)
                    .IsRequired()
                    .HasColumnName("a4r1")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.A4r2)
                    .IsRequired()
                    .HasColumnName("a4r2")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.A4r3)
                    .IsRequired()
                    .HasColumnName("a4r3")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.A4r4)
                    .IsRequired()
                    .HasColumnName("a4r4")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.A4r5a)
                    .IsRequired()
                    .HasColumnName("a4r5a")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.A4r5b)
                    .IsRequired()
                    .HasColumnName("a4r5b")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.A4r5c)
                    .IsRequired()
                    .HasColumnName("a4r5c")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.A4r6)
                    .IsRequired()
                    .HasColumnName("a4r6")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.A4r7)
                    .IsRequired()
                    .HasColumnName("a4r7")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.A5r1)
                    .IsRequired()
                    .HasColumnName("a5r1")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.A5r2)
                    .IsRequired()
                    .HasColumnName("a5r2")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.A5r3)
                    .IsRequired()
                    .HasColumnName("a5r3")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.A5r4)
                    .IsRequired()
                    .HasColumnName("a5r4")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.A6r1)
                    .IsRequired()
                    .HasColumnName("a6r1")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.A6r2)
                    .IsRequired()
                    .HasColumnName("a6r2")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Documentos).HasColumnName("documentos");

                entity.Property(e => e.Evaluacion).HasColumnName("evaluacion");

                entity.Property(e => e.InstanciaEvaluadora)
                    .IsRequired()
                    .HasColumnName("instancia_evaluadora")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasColumnName("titulo")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.EvaluacionNavigation)
                    .WithMany(p => p.RequisitosDeElegibilidad)
                    .HasForeignKey(d => d.Evaluacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_evaluacion_requisitos");
            });

            modelBuilder.Entity<Sesiones>(entity =>
            {
                entity.ToTable("sesiones");

                entity.Property(e => e.SesionesId).HasColumnName("sesiones_id");

                entity.Property(e => e.AmbitoUed)
                    .IsRequired()
                    .HasColumnName("ambitoUED")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Año)
                    .IsRequired()
                    .HasColumnName("año")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Documentos).HasColumnName("documentos");

                entity.Property(e => e.Estatal).HasColumnName("estatal");

                entity.Property(e => e.Fecha)
                    .HasColumnName("fecha")
                    .HasColumnType("datetime");

                entity.Property(e => e.Mes)
                    .IsRequired()
                    .HasColumnName("mes")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Municipal).HasColumnName("municipal");

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasColumnName("titulo")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Ued).HasColumnName("ued");

                entity.Property(e => e.UpdateAmbitoUed)
                    .IsRequired()
                    .HasColumnName("update_ambitoUED")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.UedNavigation)
                    .WithMany(p => p.Sesiones)
                    .HasForeignKey(d => d.Ued)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ued_sesiones");
            });

            modelBuilder.Entity<TipoDeEvaluacion>(entity =>
            {
                entity.ToTable("tipo_de_evaluacion");

                entity.Property(e => e.TipoDeEvaluacionId).HasColumnName("tipo_de_evaluacion_id");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasColumnName("descripcion")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Documentos).HasColumnName("documentos");

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasColumnName("titulo")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Ued>(entity =>
            {
                entity.ToTable("ued");

                entity.Property(e => e.UedId).HasColumnName("ued_id");

                entity.Property(e => e.Contacto)
                    .IsRequired()
                    .HasColumnName("contacto")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CuartoVocal)
                    .IsRequired()
                    .HasColumnName("cuarto_vocal")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Documentos).HasColumnName("documentos");

                entity.Property(e => e.Ep).HasColumnName("ep");

                entity.Property(e => e.Fecha)
                    .HasColumnName("fecha")
                    .HasColumnType("datetime");

                entity.Property(e => e.PrimerVocal)
                    .IsRequired()
                    .HasColumnName("primer_vocal")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.QuintoVocal)
                    .IsRequired()
                    .HasColumnName("quinto_vocal")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.SecretarioEjecutivo)
                    .IsRequired()
                    .HasColumnName("secretario_ejecutivo")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.SegundoVocal)
                    .IsRequired()
                    .HasColumnName("segundo_vocal")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.TercerVocal)
                    .IsRequired()
                    .HasColumnName("tercer_vocal")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Titular)
                    .IsRequired()
                    .HasColumnName("titular")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.EpNavigation)
                    .WithMany(p => p.Ued)
                    .HasForeignKey(d => d.Ep)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ep_ued");
            });

            modelBuilder.Entity<UserInfo>(entity =>
            {
                entity.ToTable("user_info");

                entity.Property(e => e.UserInfoId).HasColumnName("user_info_id");

                entity.Property(e => e.AcercaDeMi)
                    .IsRequired()
                    .HasColumnName("acerca_de_mi")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Acronimo)
                    .IsRequired()
                    .HasColumnName("acronimo")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Ambito)
                    .IsRequired()
                    .HasColumnName("ambito")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CorreoElectronico)
                    .IsRequired()
                    .HasColumnName("correo_electronico")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Cuenta)
                    .IsRequired()
                    .HasColumnName("cuenta")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Departamento)
                    .IsRequired()
                    .HasColumnName("departamento")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.DireccionSip)
                    .IsRequired()
                    .HasColumnName("direccion_sip")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Documentos).HasColumnName("documentos");

                entity.Property(e => e.Eliminado).HasColumnName("eliminado");

                entity.Property(e => e.EsLaAdministracionDelSitio).HasColumnName("es_la_administracion_del_sitio");

                entity.Property(e => e.Imagen)
                    .IsRequired()
                    .HasColumnName("imagen")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.NumeroDeTelefonoMovil)
                    .IsRequired()
                    .HasColumnName("numero_de_telefono_movil")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Puesto)
                    .IsRequired()
                    .HasColumnName("puesto")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasColumnName("titulo")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
