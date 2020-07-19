using System.Collections.Generic;
using System.Linq;
using TesteBackEndAIKO.Models;

namespace TesteBackEndAIKO.Data
{
    public class VeiculoRepository : IVeiculoRepository
    {
        private readonly TesteDBContext _context;
        public VeiculoRepository(TesteDBContext context)
        {
            _context = context;
        }

        public bool CreateVeiculo(Veiculo veiculo)
        {
            if(_context.Linhas.FirstOrDefault(l => l.Id == veiculo.LinhaId) == null)
                return false;

            _context.Veiculos.Add(veiculo);
            _context.SaveChanges();
            return true;
        }

        public IEnumerable<Veiculo> GetAllVeiculos()
        {
            return _context.Veiculos.ToList();
        }

        public Veiculo GetVeiculo(long id)
        {
            return _context.Veiculos.FirstOrDefault(x => x.Id == id);
        }

        public bool DeleteVeiculo(long id)
        {
            Veiculo veiculoDB = GetVeiculo(id);
            if(veiculoDB == null)
                return false;

            _context.Veiculos.Remove(veiculoDB);
            _context.SaveChanges();
            return true;
            
        }

        public bool CheckLinha(long linhaId)
        {
            Linha linha = _context.Linhas.FirstOrDefault( l => l.Id == linhaId);
            if(linha == null) return false;

            return true;
        }

        public bool SaveChanges()
        {
            return ( _context.SaveChanges() >= 0);
        }
    }
}