﻿using Microsoft.EntityFrameworkCore;

namespace CrudImovel.Models
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {

        }

        public DbSet<Imovel> Imovel { get; set; }
    }
}
