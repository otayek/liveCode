using liveCodeBFF.Domain;
using liveCodeBFF.Dtos;
using System.Dynamic;
using System.Security;
using System.Text.Json;

namespace liveCodeBFF.Service.Impl
{
    public class ListaCartaoServiceImpl : IListaCartaoService
    {
        private string baseUrl = "https://challenge-november-temporary.vercel.app";
        public async Task<ResponseGenerico<List<Cartao>>> ListaCartao(string cpf)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"{baseUrl}/users/{cpf}/cards");

            var response = new ResponseGenerico<List<Cartao>>();

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", "bearer 123456");

                var responseApi = await client.SendAsync(request);
                var contentResp = await responseApi.Content.ReadAsStringAsync();
                var objResponse = JsonSerializer.Deserialize<Response>(contentResp);


                if (responseApi.IsSuccessStatusCode)
                {
                    response.CodigoHttp = responseApi.StatusCode;
                    IOrderedEnumerable<Cartao> orderedEnumerable = objResponse.data.cartoes.OrderBy(x => x.limite);
                    response.DadosRetorno = orderedEnumerable.ToList();
                }
                else
                {
                    response.CodigoHttp = responseApi.StatusCode;
                    response.ErroRetorno = JsonSerializer.Deserialize<ExpandoObject>(contentResp);
                }
            }
            return response;
        }

    }
}
