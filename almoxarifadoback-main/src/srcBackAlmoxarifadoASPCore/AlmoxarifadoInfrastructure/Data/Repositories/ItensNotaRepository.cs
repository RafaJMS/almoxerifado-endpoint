using System.Collections.Generic;
using System.Linq;
using AlmoxarifadoDomain.Models;
using AlmoxarifadoInfrastructure.Data.Interfaces;

namespace AlmoxarifadoInfrastructure.Data.Repositories
{
    public class ItensNotaRepository : IItensNotaRepository
    {
        private readonly ContextSQL _context;

        public ItensNotaRepository(ContextSQL pContext)
        {
            _context = pContext;
        }

        public List<Itens_Nota> ObterTodosItensNota()
        {
            return _context.Itens_Nota.Select(i=>new Itens_Nota 
            {
                EST_LIN = i.EST_LIN,
                ID_NOTA = i.ID_NOTA,
                ID_PRO = i.ID_PRO,
                ID_SEC = i.ID_SEC,
                ITEM_NUM = i.ITEM_NUM,
                PRE_UNIT = i.PRE_UNIT,
                QTD_PRO = i.QTD_PRO,
            
            }).ToList();
        }

        public Itens_Nota CriarItemNota(Itens_Nota itemNota)
        {
            _context.Itens_Nota.Add(itemNota);
            _context.SaveChanges();
            return itemNota;
        }
    }
}
