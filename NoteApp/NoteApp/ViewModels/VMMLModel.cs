using Newtonsoft.Json;
using NoteApp.Models;
using NoteApp.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteApp.ViewModels
{
    public class VMMLModel : IMLModel
    {
        public async Task<string> predict(ModelInput input)
        {
            string json = JsonConvert.SerializeObject(input);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(BaseUrl.strUrl + "/api/Model/predict");
            var responseMessage = await client.PostAsync("", content);

            var result = await responseMessage.Content.ReadAsStringAsync();
            return await Task.FromResult(result);
        }
    }
}
