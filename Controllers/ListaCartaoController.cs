using liveCodeBFF.Application;
using liveCodeBFF.Dtos;
using liveCodeBFF.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace liveCodeBFF.Controllers
{

    [ApiController]
    public class ListaCartaoController : Controller
    {

        private IListaCartaoService listaCartaoService;

        public ListaCartaoController(IListaCartaoService listaCartaoService)
        {
            this.listaCartaoService = listaCartaoService;
        }

        [HttpGet("Lista_Cartao")]        
        public IActionResult ListaCartao(string cpf)
        {

            try
            {
                Task<ResponseGenerico<List<string>>> data = listaCartaoService.ListaCartao(cpf);

                
                return OkObjectResult(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        private IActionResult OkObjectResult(object pesquisa)
        {
            throw new NotImplementedException();
        }
    }
}
