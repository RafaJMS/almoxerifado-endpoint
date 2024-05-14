using System.Collections.Generic;
using AlmoxarifadoDomain.Models;
using AlmoxarifadoInfrastructure.Data.Interfaces;
using AlmoxarifadoInfrastructure.Data.Repositories;
using AlmoxarifadoServices.DTO;
using AutoMapper;

namespace AlmoxarifadoServices.Services
{
    public class ItensNotaService
    {
        private readonly IItensNotaRepository _itensNotaRepository;
        private readonly MapperConfiguration _configurationMapper;

        public ItensNotaService(IItensNotaRepository itensNotaRepository)
        {
            _itensNotaRepository = itensNotaRepository;
            _configurationMapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Itens_Nota, ItensNotaGetDTO>();
                cfg.CreateMap<ItensNotaPostDTO, Itens_Nota>();
            });
        }

        public List<ItensNotaGetDTO> ObterTodosItensNota()
        {
            var mapper = _configurationMapper.CreateMapper();
            return mapper.Map<List<ItensNotaGetDTO>>(_itensNotaRepository.ObterTodosItensNota());
        }

        public Itens_Nota ObterItemNotaPorID(int id)
        {
            return _itensNotaRepository.ObterItemNotaPorID(id);
        }

        public ItensNotaGetDTO CriarItemNota(ItensNotaPostDTO itemNota)
        {
            var itemNotaSalvo = _itensNotaRepository.CriarItemNota(
                new Itens_Nota
                {
                    ID_PRO = itemNota.ID_PRO,
                    ID_NOTA = itemNota.ID_NOTA,
                    ID_SEC = itemNota.ID_SEC,
                    QTD_PRO = itemNota.QTD_PRO,
                    PRE_UNIT = itemNota.PRE_UNIT,
                    EST_LIN = itemNota.EST_LIN,
                    ITEM_NUM = itemNota.ITEM_NUM,
                }
            );

            return new ItensNotaGetDTO
            {
                ITEM_NUM = itemNotaSalvo.ITEM_NUM,
                ID_PRO = itemNotaSalvo.ID_PRO,
                ID_NOTA = itemNotaSalvo.ID_NOTA,
                ID_SEC = itemNotaSalvo.ID_SEC,
                QTD_PRO = itemNotaSalvo.QTD_PRO,
                PRE_UNIT = itemNotaSalvo.PRE_UNIT,
                EST_LIN = itemNotaSalvo.EST_LIN
            };
        }
    }
}
