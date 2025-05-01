using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Maquis_EvaluacionProgreso1_PrograIV.Models;

    public class Maquis_DataBase_EvaluacionProgreso1_PrograIV : DbContext
    {
        public Maquis_DataBase_EvaluacionProgreso1_PrograIV (DbContextOptions<Maquis_DataBase_EvaluacionProgreso1_PrograIV> options)
            : base(options)
        {
        }

        public DbSet<Maquis_EvaluacionProgreso1_PrograIV.Models.PropietarioMascota> PropietarioMascota { get; set; } = default!;

public DbSet<Maquis_EvaluacionProgreso1_PrograIV.Models.Mascota> Mascota { get; set; } = default!;

public DbSet<Maquis_EvaluacionProgreso1_PrograIV.Models.VisitaVeterinaria> VisitaVeterinaria { get; set; } = default!;
    }
