using BibliotecaApi.DbModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace AdminETL.DbModels;
public partial class BibliotecaDbContext : IdentityDbContext
{
    public BibliotecaDbContext()
    {
    }

    public BibliotecaDbContext(DbContextOptions<BibliotecaDbContext> options)
        : base(options)
    {
    }

    public DbSet<Autor> Autores { get; set; }
    public DbSet<Editorial> Editoriales { get; set; }
    public DbSet<Estudiante> Estudiantes { get; set; }
    public DbSet<Libro> Libros { get; set; }
    public DbSet<Prestamo> Prestamos { get; set; }
    public DbSet<AppLog> AppLogs { get; set; }

    protected override void OnConfiguring
    (DbContextOptionsBuilder optionsBuilder)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        var adminRoleId = "af7b9479-0880-4114-9104-45b1358e4f1b";
        var userRoleId = "5b77cf84-4032-4409-9178-e76e16ef0f3c";

        var roles = new List<IdentityRole>
        {
            new IdentityRole
            {
                Name = "Admin",
                NormalizedName = "Admin",
                Id = adminRoleId,
                ConcurrencyStamp = adminRoleId
            },
            new IdentityRole
            {
                Name = "Estudiante",
                NormalizedName = "Estudiante",
                Id = userRoleId,
                ConcurrencyStamp = userRoleId
            }
        };
        builder.Entity<IdentityRole>().HasData(roles);

        var userAdminId = "cf87c98d-5de5-49ec-ac3a-a7102f3851cf";
        var userId = "1cb01fc4-6997-4918-8f3d-6b7c330bb7af";

        var userAdmin = new IdentityUser
        {
            UserName = "Admin",
            Email = "Admin@test.com",
            NormalizedEmail = "AdminETL@test.com".ToUpper(),
            NormalizedUserName = "Admin".ToUpper(),
            Id = userAdminId
        };
        var user = new IdentityUser
        {
            UserName = "User",
            Email = "User@test.com",
            NormalizedEmail = "User@test.com".ToUpper(),
            NormalizedUserName = "User".ToUpper(),
            Id = userId
        };

        userAdmin.PasswordHash = new PasswordHasher<IdentityUser>()
        .HashPassword(userAdmin,"seguro@123");

        user.PasswordHash = new PasswordHasher<IdentityUser>()
        .HashPassword(user,"seguro@123");
        
        var users = new List<IdentityUser<string>>{userAdmin,user};

        builder.Entity<IdentityUser>().HasData(users);

        var superAdminRoles = new List<IdentityUserRole<string>>
        {
            new IdentityUserRole<string>
            {
                RoleId= adminRoleId,
                UserId= userAdminId
            },
            new IdentityUserRole<string>
            {
                RoleId= userRoleId,
                UserId= userId
            }
        };

        builder.Entity<IdentityUserRole<string>>().HasData(superAdminRoles);

        builder.Entity<Autor>(entity =>
        {
            entity.ToTable("Autores");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsRequired();
            entity.Property(e => e.Estado)
            .IsRequired()
            .HasDefaultValue(true);

            entity.HasData(
                new Autor { Id = 1, Nombre = "Autor 1" },
                new Autor { Id = 2, Nombre = "Autor 2" },
                new Autor { Id = 3, Nombre = "Autor 3" },
                new Autor { Id = 4, Nombre = "Autor 4" }
            );
        });

        builder.Entity<Editorial>(entity =>
        {
            entity.ToTable("Editoriales");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsRequired();
            entity.Property(e => e.Estado)
            .IsRequired()
            .HasDefaultValue(true);
        });

        builder.Entity<Estudiante>(entity =>
        {
            entity.ToTable("Estudiantes");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsRequired();
            entity.Property(e => e.Direccion)
                .HasMaxLength(200)
                .IsRequired();
            entity.Property(e => e.Telefono)
                .HasMaxLength(10)
                .IsRequired()
                .HasColumnType("nvarchar(10)");
            entity.Property(e => e.Correo)
                .HasMaxLength(100)
                .IsRequired();
            entity.Property(e => e.Estado)
            .IsRequired()
            .HasDefaultValue(true);
        });
    
        builder.Entity<Libro>(entity =>
        {
            entity.ToTable("Libros");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsRequired();
            entity.Property(e => e.Descripcion)
                .IsRequired()
                .HasColumnType("varchar(max)");
            entity.Property(e => e.Copias)
                .IsRequired()
                .HasDefaultValue(1);
            entity.Property(e => e.Fecha_Publicacion)
                .HasColumnType("date");
            entity.Property(e => e.Estado)
            .IsRequired()
            .HasDefaultValue(true);
            entity.HasOne(l => l.Editorial)
            .WithMany()
            .HasForeignKey(l => l.Id_Editorial);
            entity.HasOne(l => l.Autor)
            .WithMany()
            .HasForeignKey(l => l.Id_Autor);
        });

        builder.Entity<Prestamo>(entity =>
        {
            entity.ToTable("Prestamos");
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Fecha_Prestamo)
            .HasColumnType("datetime");

            entity.Property(e => e.Fecha_Devolucion_Esperada)
            .HasColumnType("datetime");

            entity.Property(e => e.Fecha_Devolucion_Real)
            .HasColumnType("datetime");

            entity.HasOne(l => l.Libro)
            .WithMany()
            .HasForeignKey(l => l.Id_Libro);

             entity.HasOne(l => l.Estudiante)
            .WithMany()
            .HasForeignKey(l => l.Id_Estudiante);
        });

        builder.Entity<AppLog>(entity =>
        {
            entity.ToTable("AppLogs");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Action)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.CallSite)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.Controller)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.Exceptcion).IsUnicode(false);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Level)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Logger)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.MachineName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Message).IsUnicode(false);
            entity.Property(e => e.RequestIp)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.RequestUrl)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.TraceId)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

    }

}