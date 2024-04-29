using System;
using Microsoft.AspNetCore.Identity;

namespace BibliotecaApi.DbModels;
public class DBSeeder
{
    public static void Seed(BibliotecaDbContext context)
	{
		//Roles
		if (!context.Roles.Any())
		{

			var roles = new List<IdentityRole>
			{
				new IdentityRole
				{
					Name = "Admin",
					NormalizedName = "Admin",
					Id = "af7b9479-0880-4114-9104-45b1358e4f1b",
					ConcurrencyStamp = "af7b9479-0880-4114-9104-45b1358e4f1b"
				},
				new IdentityRole
				{
					Name = "Estudiante",
					NormalizedName = "Estudiante",
					Id = "5b77cf84-4032-4409-9178-e76e16ef0f3c",
					ConcurrencyStamp = "5b77cf84-4032-4409-9178-e76e16ef0f3c"
				}
			};

			context.AddRange(roles);
		}

		//Usuarios
		if (!context.Users.Any())
		{

			var userAdmin = new IdentityUser
			{
				UserName = "Admin",
				Email = "Admin@test.com",
				NormalizedEmail = "Admin@test.com".ToUpper(),
				NormalizedUserName = "Admin".ToUpper(),
				Id =  "cf87c98d-5de5-49ec-ac3a-a7102f3851cf"
			};

			var user = new IdentityUser
			{
				UserName = "User",
				Email = "User@test.com",
				NormalizedEmail = "User@test.com".ToUpper(),
				NormalizedUserName = "User".ToUpper(),
				Id = "1cb01fc4-6997-4918-8f3d-6b7c330bb7af"
			};

			userAdmin.PasswordHash = new PasswordHasher<IdentityUser>()
			.HashPassword(userAdmin,"seguro@123");

			user.PasswordHash = new PasswordHasher<IdentityUser>()
			.HashPassword(user,"seguro@123");

			var users = new List<IdentityUser<string>>{userAdmin,user};

			context.AddRange(users);
		}
		
		//Roles - Usuario
		if (!context.UserRoles.Any()){
			var userRoles = new List<IdentityUserRole<string>>
			{
				new IdentityUserRole<string>
				{
					RoleId= "af7b9479-0880-4114-9104-45b1358e4f1b",
					UserId= "cf87c98d-5de5-49ec-ac3a-a7102f3851cf"
				},
				new IdentityUserRole<string>
				{
					RoleId= "5b77cf84-4032-4409-9178-e76e16ef0f3c",
					UserId= "1cb01fc4-6997-4918-8f3d-6b7c330bb7af"
				}
			};
			context.AddRange(userRoles);
		}

		//Autores
		if (!context.Autores.Any())
		{
            var Autores = new List<Autor> {
			    new Autor{Nombre = "Octavio Paz",Estado = true },
				new Autor{Nombre = "Carlos Fuentes",Estado = true },
				new Autor{Nombre = "Juan Rulfo" ,Estado = true},
				new Autor{Nombre = "Elena Poniatowska" ,Estado = true},
				new Autor{Nombre = "Laura Esquivel" ,Estado = true},
				new Autor{Nombre = "Carlos Monsiváis" ,Estado = true},
				new Autor{Nombre = "Sergio Pitol" ,Estado = true},
				new Autor{Nombre = "Juan José Arreola" ,Estado = true},
				new Autor{Nombre = "Rosario Castellanos" ,Estado = true},
				new Autor{Nombre = "Alfonso Reyes" },
		    };
            
			context.AddRange(Autores);
		}

		//Editoriales
		if (!context.Editoriales.Any())
		{
            var Autores = new List<Editorial> {
			    new Editorial{Nombre = "Fondo de Cultura Económica (FCE)",Estado = true },
				new Editorial{Nombre = "Editorial Planeta Mexicana",Estado = true },
				new Editorial{Nombre = "Siglo XXI Editores" ,Estado = true},
				new Editorial{Nombre = "Ediciones Castillo" ,Estado = true},
				new Editorial{Nombre = "Editorial Diana" ,Estado = true},
				new Editorial{Nombre = "Editorial Alfaguara México" ,Estado = true}
		    };
            
			context.AddRange(Autores);
		}

		context.SaveChanges();
	}

}