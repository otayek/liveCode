using liveCodeBFF.Domain;
using liveCodeBFF.Dtos;

namespace liveCodeBFF.Service
{
    public interface IListaCartaoService
    {
        Task<ResponseGenerico<List<Cartao>>> ListaCartao(string cpf);
    }
}
