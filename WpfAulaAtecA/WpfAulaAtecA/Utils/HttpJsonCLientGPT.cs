using System.IO;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace WpfAulaAtecA.Utils
{
    public static class HttpJsonClientGPT<T>
    {
        public static async Task<T?> Post(string url, object data)
        {
            var request = WebRequest.CreateHttp(url);
            request.Method = "POST";
            request.ContentType = "application/json";

            using (var streamWriter = new StreamWriter(await request.GetRequestStreamAsync()))
            {
                var json = JsonSerializer.Serialize(data);
                streamWriter.Write(json);
            }

            try
            {
                using var response = (HttpWebResponse)await request.GetResponseAsync();
                using var reader = new StreamReader(response.GetResponseStream());
                var result = await reader.ReadToEndAsync();

                return JsonSerializer.Deserialize<T>(result, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
            }
            catch (WebException)
            {
                return default;
            }
        }
    }
}
