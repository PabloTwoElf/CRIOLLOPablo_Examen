using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CRIOLLOPablo_Examen.Models;

namespace CRIOLLOPablo_Examen.Data
{
    public class CRIOLLOPablo_ExamenContext : DbContext
    {
        public CRIOLLOPablo_ExamenContext (DbContextOptions<CRIOLLOPablo_ExamenContext> options)
            : base(options)
        {
        }

        public DbSet<CRIOLLOPablo_Examen.Models.PCriollo> PCriollo { get; set; } = default!;
        public DbSet<CRIOLLOPablo_Examen.Models.Celular> Celular { get; set; } = default!;
    }
}
