using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;
using Application.Contracts;
using AutoMapper;
using Domain.Abstraction;
using Domain.Entities;
using Domain.Entities.Asistencia;
using Domain.Entities.Departamento;
using Domain.Enums;
using Domain.Models.Miscelaneo;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Internal;

namespace API.Controllers
{
    public class CacheController : BaseController
    {
        private readonly MainContext _context;
        private readonly IMapper _mapper;
        public CacheController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork)
        {
            _context = (MainContext) _uow.GetDbContext();
            _mapper = mapper;
        }

        private JsonResult MaptoMiscelaneo<T>(List<T> list) => new JsonResult(_mapper.Map<List<Miscelaneo>>(list));

        [HttpGet("provincias")]
        public async Task<JsonResult> GetProvincias() => MaptoMiscelaneo(await _context.Provincias.ToListAsync());

        [HttpGet("municipios")]
        public async Task<JsonResult> GetMunicipios([FromQuery] int provinviaId)
        {
            Expression<Func<Municipio, bool>> expression = x => x.ProvinciaId.Equals(provinviaId);
            return MaptoMiscelaneo(await _context.Municipios.Where(expression).ToListAsync());
        }

        [HttpGet("regiones")]
        public async Task<JsonResult> GetRegiones()
        {
            var regiones = await _context.RegionAsistencias
                           .Select(r => new 
                           { 
                                Id = r.Id, 
                                Region = r.Nombre, 
                                Macro = r.RegionMacro.ToString().Replace("_", " ") 
                            })
                           .ToListAsync();
            
            return new JsonResult(regiones);
        }

        [HttpGet("vehiculos")]
        public async Task<JsonResult> GetTipoVehiculos() => MaptoMiscelaneo(await _context.VehiculoTipos.ToListAsync());

        [HttpGet("marcas")]
        public async Task<JsonResult> GetMarcas() => MaptoMiscelaneo(await _context.VehiculoMarcas.ToListAsync());

        [HttpGet("modelos")]
        public async Task<JsonResult> GetModelos([FromQuery] int MarcaId)
        {
            Expression<Func<VehiculoModelo, bool>> expression = m => m.VehiculoMarcaId == MarcaId;
            return MaptoMiscelaneo(await _context.VehiculoModelos.Where(expression).ToListAsync());
        } 

        [HttpGet("departamentos")]
        public async Task<JsonResult> GetDepartamentos([FromQuery] bool NoReporta)
        {
            Expression<Func<Departamento, bool>> expression = d => d.NoReporta == NoReporta;
            return MaptoMiscelaneo(await _context.Departamentos.Where(expression).ToListAsync());
        }

        [HttpGet("rangos")]
        public async Task<JsonResult> GetRangos() => MaptoMiscelaneo(await _context.Rangos.ToListAsync());

        [HttpGet("unidades")]
        public async Task<JsonResult> GetTipoUnidades() => MaptoMiscelaneo(await _context.TipoUnidades.ToListAsync());

        [HttpGet("asistencias")]
        public async Task<JsonResult> GetTipoAsistencias([FromQuery] int categoria) 
        {
            Expression<Func<TipoAsistencia, bool>> expression = t => (int)t.CategoriaAsistencia == categoria;
            return MaptoMiscelaneo(await _context.TipoAsistencias.Where(expression).ToListAsync());
        }

        [HttpGet("placas")]
        public async Task<JsonResult> GetTipoPlaca()
        {
            var tipoPlacas = await _context.VehiculoPlacas
                             .Select(x => new 
                             {
                                Id = x.Id,
                                Nombre = $"{x.Descripcion} - ({x.Sigla})",
                                Tipo = x.TipoPlaca.ToString()
                             }).ToListAsync();
            
            return new JsonResult(tipoPlacas);
        }

    }
}