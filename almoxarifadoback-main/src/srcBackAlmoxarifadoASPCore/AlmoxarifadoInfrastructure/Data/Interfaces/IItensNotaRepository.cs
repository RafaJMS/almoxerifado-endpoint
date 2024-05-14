using AlmoxarifadoDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmoxarifadoInfrastructure.Data.Interfaces
{
    public interface IItensNotaRepository
    {
        List<Itens_Nota> ObterTodosItensNota();
        Itens_Nota ObterItemNotaPorID(int id);
        Itens_Nota CriarItemNota(Itens_Nota itemNota);
    }
}
