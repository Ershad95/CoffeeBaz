using AutoMapper;
using CoffeeBaz.Data.Domain;
using CoffeeBaz.Service.TableService;
using CoffeeBaz.Shared.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace CoffeeBaz.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TableApiController : ControllerBase
    {
        private readonly ITableService _tableService;
        private readonly IMapper _mapper;
        public TableApiController(ITableService tableService,IMapper mapper)
        {
            _mapper = mapper;
            _tableService = tableService;
        }
        [HttpGet("/{id}")]
        public async Task<TableDTO> Get([FromQuery]int id,CancellationToken cancellationToken)
        {
            var table = await _tableService.GetById(id, cancellationToken);
            return  _mapper.Map<TableDTO>(table);
        }
        [HttpPost]
        public async Task<TableDTO> Post([FromBody] TableDTO tableDTO, CancellationToken cancellationToken)
        {
            var table = await _tableService.Insert(_mapper.Map<Table>(tableDTO), cancellationToken);
            return _mapper.Map<TableDTO>(table);
        }
    }
}
