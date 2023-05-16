using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using atteducation.api.Data;
using atteducation.api.Models;
using Microsoft.EntityFrameworkCore;

namespace atteducation.api.Seeders
{
    public static class SeedRoles
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using(var context = new DataContext(serviceProvider.GetRequiredService<DbContextOptions<DataContext>>()))
            {
                if(context.Rols.Any()) 
                    return;

                context.Rols.AddRange(
                    new Rol
                    {
                        Namerol = "Admin"
                    },
                    new Rol
                    {
                        Namerol = "Docente"
                    },
                    new Rol
                    {
                        Namerol = "Estudiante"
                    }
                );    

                context.SaveChanges();
            }

        }
    }
}