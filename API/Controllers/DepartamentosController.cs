using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Contracts;
using Application.Helpers;
using Domain.Entities.Departamento;

namespace API.Controllers
{
    public class DepartamentosController : GenericController<Departamento>
    {
        public DepartamentosController(IUnitOfWork unitOfWork, ISpecification<Departamento> specification) : base(unitOfWork, specification)
        {
            _expression = _spec.GetPredicate(x => x.Nombre.Contains(_searchTerm) && x.Estatus == _status);
            _orderBy = _spec.GetOrderBy(x => x.Nombre);
        }
    }
}