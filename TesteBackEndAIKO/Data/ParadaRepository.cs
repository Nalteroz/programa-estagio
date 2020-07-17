using System.Collections.Generic;
using TesteBackEndAIKO.Models;
using System.Linq;

namespace TesteBackEndAIKO.Data
{
    public class ParadaRepository : IParadaRepository
    {
        private readonly TesteDBContext _context;

        public ParadaRepository(TesteDBContext context)
        {
            _context = context;
        }

        public void CreateParada(Parada parada)
        {
            try
            {
                _context.Paradas.Add(parada);
                _context.SaveChanges();
            }
            catch
            {
                throw new System.Exception("ERRO ao tentar adicionar a parada.");
            }
        }

        public void DeleteParada(long id)
        {
            try
            {
                _context.Paradas.Remove( _context.Paradas.First( x => x.Id == id ) );
            }
            catch
            {
                throw new System.Exception("Erro ao tentar remover parada com id " + id);
            }
        }

        public IEnumerable<Parada> GetAllParadas()
        {
            return _context.Paradas.ToList();
        }

        public Parada GetParada(long id)
        {
            return _context.Paradas.FirstOrDefault( x => x.Id == id );
        }

        public void UpdateParada(Parada parada)
        {
            try
            {
                Parada paradaDB = GetParada(parada.Id);
                if(paradaDB != null)
                {
                    paradaDB.Latitude = parada.Latitude;
                    paradaDB.Longitude = parada.Longitude;
                    paradaDB.Name = parada.Name;
                    _context.SaveChanges();
                }
                else
                {
                    CreateParada(parada);
                }
            }
            catch
            {
                throw new System.Exception("Erro ao tentar atualizar parada.");
            }
        }
    }
}