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

        public bool CreateLinha(Linha linha)
        {
            foreach(long id in linha.Paradas)
            {
                if(_context.Paradas.FirstOrDefault(x => x.Id == id) == null)
                    return false;
            }
            _context.Linhas.Add(linha);
            _context.SaveChanges();
            return true;
        }
        
        public IEnumerable<Linha> GetAllLinhas()
        {
            return _context.Linhas.ToList();
        }

        public Linha GetLinha(long id)
        {
            return _context.Linhas.FirstOrDefault(x => x.Id == id);
        }

        public bool DeleteLinha(long id)
        {
            Linha linhaDB = GetLinha(id);
            if(linhaDB == null) return false;

            _context.Linhas.Remove( linhaDB );
            _context.SaveChanges();
            return true;
        }

        public bool CheckParadas(List<long> paradas)
        {
            try
            {
                foreach(long paradaId in paradas)
                {
                    if(_context.Paradas.FirstOrDefault(p => p.Id == paradaId) == null) 
                        return false;
                }
            }
            catch
            {
                return false;
            }

            return true;
        }
        public bool SaveChanges()
        {
            return ( _context.SaveChanges() >= 0);
        }
    }
}