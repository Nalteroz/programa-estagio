using System.Collections.Generic;
using TesteBackEndAIKO.Models;
using System.Linq;
using Microsoft.AspNetCore.JsonPatch;
using TesteBackEndAIKO.Dtos;

namespace TesteBackEndAIKO.Data
{
    public class ParadaRepository : IParadaRepository
    {
        private readonly TesteDBContext _context;

        public ParadaRepository(TesteDBContext context)
        {
            _context = context;
        }

        public bool CreateParada(Parada parada)
        {
            if(parada == null || parada.Latitude == 0 || parada.Longitude == 0) 
                return false;

            _context.Paradas.Add(parada);
            _context.SaveChanges();
            return true;
        }

        public IEnumerable<Parada> GetAllParadas()
        {
            return _context.Paradas.ToList();
        }

        public Parada GetParada(long id)
        {
            return _context.Paradas.FirstOrDefault( x => x.Id == id );
        }

        public bool DeleteParada(long id)
        {
            Parada paradaDB = GetParada(id);
            if(paradaDB == null) return false;
            _context.Paradas.Remove( paradaDB );
            _context.SaveChanges();
            return true;
        }

        public bool SaveChanges()
        {
            return ( _context.SaveChanges() >= 0);
        }
    }
}