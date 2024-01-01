using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Extensions;
using Common.Paginado;
using finanza_backend_net.Models;
using finanza_backend_net.Models.dto;
using static finanza_backend_net.Models.dto.moneyDto;

namespace finanza_backend_net.Services
{
    public interface ImoneyService
    {
        PaginaCollection<listMoney> moneyList(moneyDto param);
    }

    public class moneyService:ImoneyService
    {
        private readonly ExpenseControlContext _context;
        public moneyService(ExpenseControlContext context)
        {
            this._context = context;
        }

        public PaginaCollection<listMoney> moneyList(moneyDto param)
        {
            var data = _context.Money.Where(w =>
            (param.IdMoney.IsNullOrDefault() || w.IdMoney == param.IdMoney)
            ).Select(s => new listMoney
            {
                IdMoney = s.IdMoney,
                Money1 = s.Money1,
                Symbol = s.Symbol
            }).Paginar(param.pagina,param.registroPorPagina);

            return data;
        }
    }
}