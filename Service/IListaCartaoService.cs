using liveCodeBFF.Dtos;

namespace liveCodeBFF.Service
{
    public interface IListaCartaoService
    {
        Task<ResponseGenerico<List<string>>> ListaCartao(string cpf);
    }
}
