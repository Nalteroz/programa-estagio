using Microsoft.EntityFrameworkCore;
using TesteBackEndAIKO.Models;

namespace TesteBackEndAIKO.Data
{
    public class TesteDBContext : DbContext
    {
        public TesteDBContext(DbContextOptions<TesteDBContext> opt) : base(opt)
        {
            
        }

        public DbSet<Linha> Linhas { get; set;} 
        public DbSet<Parada> Paradas { get; set;} 
        public DbSet<PosicaoVeiculo> PosicaoVeiculos { get; set;} 
        public DbSet<Veiculo> Veiculos { get; set;} 
    }
}