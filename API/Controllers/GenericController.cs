using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Application.Contracts;
using Application.Helpers;
using Domain.Abstraction;
using Domain.DTO.Pagination;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    public class GenericController<T> : BaseController where T : EntityMetadata
    {
        protected readonly IUnitOfWork _uow;
        protected readonly ISpecification<T> _spec;
        protected readonly Expression<Func<T, bool>> _expression;
        public GenericController(IUnitOfWork unitOfWork, ISpecification<T> specification)
        {
            _uow = unitOfWork;
            _spec = specification;
            _expression = _spec.GetPredicate(x => x.Estatus);
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] PaginationFilter filter)
        {
            var result = await _uow.Repository<T>().GetAllAsync(filter, _expression);
            return new JsonResult(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] object Id)
        {
            var result = await _uow.Repository<T>().GetById(Id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEntity([FromBody] T Entity)
        {
            await _uow.Repository<T>().InsertAsync(Entity);
            await _uow.CommitChangesAsync();
            return Created("CreateEntity", Entity);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateEntity([FromBody] T Entity)
        {
            _uow.Repository<T>().Update(Entity);
            await _uow.CommitChangesAsync();
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] T Entity)
        {
            _uow.Repository<T>().Delete(Entity);
            await _uow.CommitChangesAsync();
            return Ok();
        }
    }
}