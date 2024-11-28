using liveCodeBFF.Dtos;
using System.Dynamic;
using System.Text.Json;

namespace liveCodeBFF.Service.Impl
{
    public class ListaCartaoServiceImpl : IListaCartaoService
    {
        public async Task<ResponseGenerico<List<string>>> ListaCartao(string cpf)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $" {cpf}");

            var response = new ResponseGenerico<List<String>>();

            using (var client = new HttpClient())
            {
                var responseApi = await client.SendAsync(request);
                var contentResp = await responseApi.Content.ReadAsStringAsync();
                var objResponse = JsonSerializer.Deserialize<List<Object>>(contentResp);


                if (responseApi.IsSuccessStatusCode)
                {
                    response.CodigoHttp = responseApi.StatusCode;
                    IOrderedEnumerable<object> orderedEnumerable = objResponse.Order();
                    response.DadosRetorno = (List<string>?)orderedEnumerable;
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
