using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Extensions;
using Common.Paginado;
using Common.Util;
using finanza_backend_net.Models;
using finanza_backend_net.Models.dto;
using Microsoft.IdentityModel.Tokens;
using static finanza_backend_net.Models.dto.countryDto;

namespace finanza_backend_net.Services
{
    public interface IcountryService
    {
        Task createCountry(saveCoutry obj);
        PaginaCollection<listCountry> countryList(countryDto param);
    }
    public class countryService:IcountryService
    {
        private readonly ExpenseControlContext _context;
        private IWebHostEnvironment _hostEnvironment;

        public countryService(ExpenseControlContext context,IWebHostEnvironment webHostEnvironment)
        {
            this._context = context;
            this._hostEnvironment = webHostEnvironment;
        }

        public async Task createCountry(saveCoutry obj)
        {
            var uploadsFolder = Path.Combine(_hostEnvironment.WebRootPath, "public", "images");

            var uniqueFileName = Guid.NewGuid().ToString() + "_" + obj.Photo.FileName;
            var filePath = Path.Combine(uploadsFolder, uniqueFileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await obj.Photo.CopyToAsync(stream);
            }

            obj.Icon = Path.Combine("public", "images", uniqueFileName);

            Country country = Mapper<saveCoutry,Country>.Map(obj);

            await _context.Countries.AddAsync(country);
            await _context.SaveChangesAsync();
        }

        public PaginaCollection<listCountry> countryList(countryDto param)
        {
            var result = _context.Countries.Where(w =>
            (param.IdCountry.IsNullOrDefault() || w.IdCountry == param.IdCountry) &&
            (param.Country.IsNullOrEmpty() || w.Country1.ToUpper().Contains(param.Country.ToUpper()))
            ).Select(s => new listCountry
            {
                IdCountry = s.IdCountry,
                Country = s.Country1,
                Icon = s.Icon
            }).Paginar(param.pagina, param.registroPorPagina);

            return result;
        }
    }
}