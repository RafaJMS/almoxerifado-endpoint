using System.Collections.Generic;
using System.Linq;
using AlmoxarifadoDomain.Models;
using AlmoxarifadoInfrastructure.Data.Interfaces;

namespace AlmoxarifadoInfrastructure.Data.Repositories
{
    public class ItensNotaRepository : IItensNotaRepository
    {
        private readonly ContextSQL _context;

        public ItensNotaRepository(ContextSQL context)
        {
            _context = context;
        }

        public List<Itens_Nota> ObterTodosItensNota()
        {
            return _context.Itens_Nota.ToList();
        }

        public Itens_Nota ObterItemNotaPorID(int id)
        {
            return _context.Itens_Nota.FirstOrDefault(i => i.ITEM_NUM == id);
        }

        public Itens_Nota CriarItemNota(Itens_Nota itemNota)
        {
            _context.Itens_Nota.Add(itemNota);
            _context.SaveChanges();
            return itemNota;
        }
    }
}
