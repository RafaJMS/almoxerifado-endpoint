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

        public List<ItensNota> ObterTodosItensNota()
        {
            return _context.Itens_Nota.ToList();
        }

        public ItensNota ObterItemNotaPorID(int id)
        {
            return _context.Itens_Nota.FirstOrDefault(i => i.ITEM_NUM == id);
        }

        public ItensNota CriarItemNota(ItensNota itemNota)
        {
            _context.Itens_Nota.Add(itemNota);
            _context.SaveChanges();
            return itemNota;
        }
    }
}
