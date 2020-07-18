using System.Collections.Generic;
using TesteBackEndAIKO.Models;
using System.Linq;

namespace TesteBackEndAIKO.Data
{
    public class LinhaRepository : ILinhaRepository
    {
        private readonly TesteDBContext _context;
        public LinhaRepository(TesteDBContext context)
        {
            _context = context;
        }

        public void CreateLinha(Linha linha)
        {
            try
            {
                _context.Linhas.Add(linha);
                _context.SaveChanges();
            }
            catch
            {
                throw new System.Exception("ERRO ao adicionar linha ao banco de dados.");
            }
        }
        
        public IEnumerable<Linha> GetAllLinhas()
        {
            try
            {
                return _context.Linhas.ToList();
            }
            catch
            {
                throw new System.Exception("ERRO ao tentar retornar todas as linhas.");
            }
        }

        public Linha GetLinha(long id)
        {
            try
            {
                return _context.Linhas.FirstOrDefault(x => x.Id == id);
            }
            catch
            {
                throw new System.Exception("Erro ao tentar recuperar linha com id " + id);
            }
        }

        public void DeleteLinha(long id)
        {
            try
            {
                Linha linhaDB = GetLinha(id);
                if(linhaDB != null) _context.Linhas.Remove( linhaDB );
                _context.SaveChanges();
            }
            catch
            {
                throw new System.Exception("ERRO ao tentar remover linha com Id = " + id);
            }
        }

        public void UpdateLinha(Linha linha)
        {
            try
            {
                Linha linhaNoBD = GetLinha(linha.Id);
                if(linhaNoBD != null)
                {
                    linhaNoBD.Name = linha.Name;
                    linhaNoBD.Paradas = linha.Paradas;
                    _context.SaveChanges();
                }
                else
                {
                    CreateLinha(linha);
                }
            }
            catch
            {
                throw new System.Exception("Erro ao tentar atualizar linha no BD.");
            }
        }
    }
}