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

        public void CreateVeiculo(Veiculo veiculo)
        {
            try
            {
                _context.Veiculos.Add(veiculo);
                _context.SaveChanges();
            }
            catch 
            {
                throw new System.Exception("ERRO ao tentar criar veiculo no banco de dados.");
            }
        }

        public IEnumerable<Veiculo> GetAllVeiculos()
        {
            try
            {
                return _context.Veiculos.ToList();
            }
            catch 
            {
                throw new System.Exception("ERRO ao tentar recuperar todos os veiculos do banco de dados.");
            }
        }

        public Veiculo GetVeiculo(long id)
        {
            try
            {
                return _context.Veiculos.FirstOrDefault(x => x.Id == id);
            }
            catch 
            {
                throw new System.Exception("ERRO ao tentar recuperar no banco de dados o veiculo com id = " + id);
            }
        }

        public void DeleteVeiculo(long id)
        {
            try
            {
                Veiculo veiculoDB = GetVeiculo(id);
                if(veiculoDB != null)
                {
                    _context.Veiculos.Remove(veiculoDB);
                    _context.SaveChanges();
                }
            }
            catch
            {
                throw new System.Exception("ERRO ao tentar deletar no banco de dados o veiculo com id = " + id);
            }
        }

        public void UpdateVeiculo(Veiculo veiculo)
        {
            try
            {
                Veiculo veiculoDB = GetVeiculo(veiculo.Id);
                if(veiculoDB != null)
                {
                    veiculoDB = veiculo;
                    _context.SaveChanges();
                }
                else 
                    CreateVeiculo(veiculo);
            }
            catch 
            {
                throw new System.Exception("ERRO ao tentar atualizar as informaçoes do veiculo com id = "+ veiculo.Id);
            }
        }
    }
}