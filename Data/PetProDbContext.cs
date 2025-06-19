using Microsoft.EntityFrameworkCore;
using ProPet.Models;

namespace ProPet.Data;

public class PetProDbContext : DbContext
{
    public PetProDbContext(DbContextOptions<PetProDbContext> options) : base(options)
    {
    }

    public DbSet<Tutor> Tutors { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Pet> Pets { get; set; }
    public DbSet<UserRole> Roles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<UserRole>().HasData(
            new UserRole { Id = 1, Descricao = "Admin" },
            new UserRole { Id = 2, Descricao = "Normal" }
        );

        modelBuilder.Entity<Tutor>().HasData(
            new Tutor
            {
                Id = 1,
                Nome = "Admin",
                SobreNome = "do Sistema",
                Endereco = "Rua do Servidor, 123",
                NumeroContato = "99999-0001"
            },
            new Tutor
            {
                Id = 2,
                Nome = "Usuário",
                SobreNome = "Padrão",
                Endereco = "Avenida do Cliente, 456",
                NumeroContato = "99999-0002"
            }
        );

        modelBuilder.Entity<User>().HasData(
            new User
            {
                Id = 1,
                Username = "admin",
                PasswordHash = "$2a$11$EQ8DKANsZ1Ck8dz7ZjT7AOQA2SGcH3oJ6zLv5zCU9WxVK9sDUWD5y",
                UserRoleId = 1,
                TutorId = 1
            },
            new User
            {
                Id = 2,
                Username = "user",
                PasswordHash = "$2a$11$ALlMdekzq5gzlr/dCs/qge7uKAxE77ZrYWeCLxohwTWt5zJO7qoyS",
                UserRoleId = 2,
                TutorId = 2
            }
        );

        modelBuilder.Entity<Pet>().HasData(
            new Pet { Id = 1, Nome = "Fígaro", Tipo = "Gato", Raca = "SRD", Idade = 3, TutorId = 1 },
            new Pet { Id = 2, Nome = "Pluto", Tipo = "Cachorro", Raca = "SRD", Idade = 5, TutorId = 1 },
            new Pet { Id = 3, Nome = "Garfield", Tipo = "Gato", Raca = "Persa", Idade = 7, TutorId = 2 },
            new Pet { Id = 4, Nome = "Snoopy", Tipo = "Cachorro", Raca = "Beagle", Idade = 6, TutorId = 2 }
        );
    }
}