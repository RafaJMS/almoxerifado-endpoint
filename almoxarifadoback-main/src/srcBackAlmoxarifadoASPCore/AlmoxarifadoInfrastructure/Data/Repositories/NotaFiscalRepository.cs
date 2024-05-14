using AlmoxarifadoDomain.Models;
using AlmoxarifadoInfrastructure.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmoxarifadoInfrastructure.Data.Repositories
{
    public class NotaFiscalRepository : INotaFiscalRepository
    {
        private readonly ContextSQL _context;

        public NotaFiscalRepository(ContextSQL pContext)
        {
            _context = pContext;
        }

        public List<Nota_Fiscal> ObterTodasNotasFiscais()
        {
            return _context.Nota_Fiscal.ToList();
        }

        public Nota_Fiscal ObterNotaFiscalPorId(int id)
        {
            return _context.Nota_Fiscal.FirstOrDefault(nf => nf.ID_NOTA == id);
        }

        public Nota_Fiscal CriarNotaFiscal(Nota_Fiscal notaFiscal)
        {
            _context.Nota_Fiscal.Add(notaFiscal);
            _context.SaveChanges();
            return notaFiscal;
        }
    }
}
