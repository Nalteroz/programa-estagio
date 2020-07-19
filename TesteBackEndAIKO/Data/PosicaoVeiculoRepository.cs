using System.Collections.Generic;
using System.Linq;
using TesteBackEndAIKO.Models;

namespace TesteBackEndAIKO.Data
{
    public class PosicaoVeiculoRepository : IPosicaoVeiculoRepository
    {
        private readonly TesteDBContext _context;

        public PosicaoVeiculoRepository(TesteDBContext context)
        {
            _context = context;;
        }

        public bool CreatePosicaoVeiculo(PosicaoVeiculo posicaoVeiculo)
        {
            //Nao da pra criar uma posicao de um veiculo que nao existe no banco de dados.
            if(!CheckPosicaoVeiculo(posicaoVeiculo))
                return false;
            
            _context.PosicaoVeiculos.Add(posicaoVeiculo);
            _context.SaveChanges();
            return true;
        }

        public IEnumerable<PosicaoVeiculo> GetAllPosicaoVeiculos()
        {
            return _context.PosicaoVeiculos.ToList();
        }

        public PosicaoVeiculo GetPosicaoVeiculo(long veiculoId)
        {
            return _context.PosicaoVeiculos.FirstOrDefault(x => x.VeiculoId == veiculoId);
        }

        public bool DeletePosicaoVeiculo(long veiculoId)
        {
            PosicaoVeiculo posicaoVeiculoDB = GetPosicaoVeiculo(veiculoId);
            if(posicaoVeiculoDB == null)
                return false;
            
            _context.PosicaoVeiculos.Remove( posicaoVeiculoDB );
            _context.SaveChanges();
            return true;
        }

        public bool CheckPosicaoVeiculo(PosicaoVeiculo posicaoVeiculo)
        {
            PosicaoVeiculo posicaoOnContext = _context.PosicaoVeiculos.FirstOrDefault( v => v.VeiculoId == posicaoVeiculo.VeiculoId);
            if(posicaoOnContext != null) 
                return false;
            
            Veiculo veiculo = _context.Veiculos.FirstOrDefault( v => v.Id == posicaoVeiculo.VeiculoId);
            if(veiculo == null)
                return false;
                
            if(posicaoVeiculo.Latitude == 0 || posicaoVeiculo.Longitude == 0)
                return false;

            return true;
        }

        public bool SaveChanges()
        {
            return ( _context.SaveChanges() >= 0);
        }
    }
}