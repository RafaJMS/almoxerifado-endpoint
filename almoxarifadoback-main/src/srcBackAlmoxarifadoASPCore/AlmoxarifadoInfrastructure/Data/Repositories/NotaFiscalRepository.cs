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
            return _context.Nota_Fiscal.Select(nf=>new Nota_Fiscal
            {
                ICMS = nf.ICMS ?? 0,
                ANO = nf.ANO,
                DATA_NOTA = nf.DATA_NOTA ?? null ,
                EMPENHO_NUM = nf.EMPENHO_NUM ?? 0,
                ID_FOR = nf.ID_FOR ?? 0,
                ID_NOTA = nf.ID_NOTA,
                ID_SEC = nf.ID_SEC,
                ID_TIPO_NOTA = nf.ID_TIPO_NOTA,
                ISS = nf.ISS ?? 0,
                MES = nf.MES ?? 0,
                NUM_NOTA = nf.NUM_NOTA,
                OBSERVACAO_NOTA = nf.OBSERVACAO_NOTA ?? "",
                QTD_ITEM = nf.QTD_ITEM,
                VALOR_NOTA = nf.VALOR_NOTA
            }).ToList();
        }

        public Nota_Fiscal CriarNotaFiscal(Nota_Fiscal notaFiscal)
        {
            _context.Nota_Fiscal.Add(notaFiscal);
            _context.SaveChanges();
            
            return notaFiscal;
        }
    }
}
