
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Api.Filters;
using Domain.Entity;

namespace Api.Controllers
{
    [EnableCors("AllowAllHeaders")]
    [Route("[controller]")]
    [ServiceFilter(typeof(AuthActionFilter))]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService clienteService;

        public ClienteController(IClienteService clienteService)
        {
            this.clienteService = clienteService;
        }

        [HttpGet("{id}")]
        public ActionResult<Cliente> PegarCadastro(int id) => Ok(clienteService.PegarPorId(id));

        [HttpGet]
        public ActionResult<Cliente> PegarTodos() => Ok(clienteService.PegarTodos());

        [HttpPost]
        public ActionResult<Cliente> Adicionar([FromBody] Cliente cliente) => Ok(clienteService.Adicionar(cliente));

        [HttpPut]
        public ActionResult<int> Atualizar([FromBody] Cliente cliente) => Ok(clienteService.Atualizar(cliente));

        [HttpDelete("{id}")]
        public ActionResult<int> Remover(int id) => Ok(clienteService.Remover(id));
    }
}
