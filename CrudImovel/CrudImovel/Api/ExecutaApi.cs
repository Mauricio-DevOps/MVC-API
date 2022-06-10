using Newtonsoft.Json;

namespace CrudImovel.Api
{
    public class ExecutaApi
    {
        public static readonly HttpClient _cliet = new HttpClient();

        public static T ConsultaVerboGet<T>(string url)
        {
            var respose = _cliet.GetAsync(url).Result;

            if (respose.StatusCode != System.Net.HttpStatusCode.OK)
                throw new Exception("Ocorreu um erro na api:" + respose.Content.ReadAsStringAsync().Result);

            return JsonConvert.DeserializeObject<T>(respose.Content.ReadAsStringAsync().Result)!;
        }
        public static T ConsultaVerboPost<T>(string url, object objetoEntrada)
        {
            string json = JsonConvert.SerializeObject(objetoEntrada);
            StringContent content = new StringContent(json);
            var respose = _cliet.PostAsync(url, content).Result;
            if (respose.StatusCode != System.Net.HttpStatusCode.OK)
                throw new Exception("Ocorreu um erro na api:" + respose.Content.ReadAsStringAsync().Result);

            return JsonConvert.DeserializeObject<T>(respose.Content.ReadAsStringAsync().Result)!;
        }
    }
}
