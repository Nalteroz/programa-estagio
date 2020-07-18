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

        public void CreatePosicaoVeiculo(PosicaoVeiculo posicaoVeiculo)
        {
            try
            {
                //Nao da pra criar uma posicao de um veiculo que nao existe no banco de dados.
                Veiculo veiculoDB = _context.Veiculos.FirstOrDefault(x => x.Id == posicaoVeiculo.VeiculoId);
                if(veiculoDB != null)
                {
                    _context.PosicaoVeiculos.Add(posicaoVeiculo);
                    _context.SaveChanges();
                }
                else throw new System.Exception("Id do veiculo não existe no banco de dados.");
            }
            catch
            {
                throw new System.Exception("ERRO ao tentar criar posicaoveiculo no banco de dados.");
            }
        }

        public IEnumerable<PosicaoVeiculo> GetAllPosicaoVeiculos()
        {
            try
            {
                return _context.PosicaoVeiculos.ToList();
            }
            catch 
            {
                throw new System.Exception("ERRO ao tentar recuparar todas as posicoes de veiculos no bando de dados.");
            }
        }

        public PosicaoVeiculo GetPosicaoVeiculo(long veiculoId)
        {
            try
            {
                return _context.PosicaoVeiculos.FirstOrDefault(x => x.VeiculoId == veiculoId);
            }
            catch
            {
                throw new System.Exception("Erro ao tentar achar a posicao do veiculo com id = " + veiculoId);
            }
        }

        public void DeletePosicaoVeiculo(long veiculoId)
        {
            try
            {
                PosicaoVeiculo posicaoVeiculoDB = GetPosicaoVeiculo(veiculoId);
                if(posicaoVeiculoDB != null)
                {
                    _context.PosicaoVeiculos.Remove( posicaoVeiculoDB );
                    _context.SaveChanges();
                }
            }
            catch
            {
                throw new System.Exception("Erro ao tentar deletar a posicao do veiculo com id = " + veiculoId);
            }
        }

        public void UpdatePosicaoVeiculo(PosicaoVeiculo posicaoVeiculo)
        {
            try
            {
                PosicaoVeiculo posicaoVeiculoDB = GetPosicaoVeiculo(posicaoVeiculo.VeiculoId);
                if(posicaoVeiculo != null)
                {
                    posicaoVeiculoDB.Latitude = posicaoVeiculo.Latitude;
                    posicaoVeiculoDB.Longitude = posicaoVeiculo.Longitude;
                    _context.SaveChanges();
                }
                else 
                    CreatePosicaoVeiculo(posicaoVeiculo);
            }
            catch 
            {
                throw new System.Exception("ERRO ao tentar atualizar a posicao do veiculo com id = "+ posicaoVeiculo.VeiculoId);
            }
        }
    }
}