using System.Net.Http.Headers;
using fusogram_csharp.Dtos;

namespace fusogram_csharp.Services
{
    public class CosmicService
    {
        public string EnviarImagem(ImagemDto imagemdto)
        {
            Stream imagem;

            imagem = imagemdto.Imagem.OpenReadStream();

            var client = new HttpClient();

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "quxwUJ4VbzaCBkHRL1zq5NQPks57RlSYfGC0rp3u8FDPb0KYPV");

            var request = new HttpRequestMessage(HttpMethod.Post, "file");
            var conteudo = new MultipartFormDataContent
            {
                { new StreamContent(imagem), "media", imagemdto.Nome }
            };

            request.Content = conteudo;
            var retornoreq = client.PostAsync("https://workers.cosmicjs.com/v3/buckets/fusogrambucket-production/media", request.Content).Result;

            var urlretorno = retornoreq.Content.ReadFromJsonAsync<CosmicRespostaDto>();

            return urlretorno.Result.media.url;
        }
    }
}
