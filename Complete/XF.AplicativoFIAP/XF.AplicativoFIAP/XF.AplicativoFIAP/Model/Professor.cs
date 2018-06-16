using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace XF.AplicativoFIAP.Model
{
    public class Professor
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Titulo { get; set; }
    }

    public static class ProfessorRepository
    {
        private static IEnumerable<Professor> professoresSqlAzure;

        public static async Task<ObservableCollection<Professor>> GetProfessoresSqlAzureAsync()
        {
            var httpRequest = new HttpClient();
            var stream = await httpRequest.GetStreamAsync(
                "{Informe o endereço da Web API}");

            var professorSerializer = new DataContractJsonSerializer(typeof(List<Professor>));
            professoresSqlAzure = (List<Professor>)professorSerializer.ReadObject(stream);

            return new ObservableCollection<Professor>(professoresSqlAzure);
        }       

        public static async Task<bool> PostProfessorSqlAzureAsync(Professor profAdd)
        {
            if (profAdd == null) return false;

            var httpRequest = new HttpClient();
            httpRequest.BaseAddress = new Uri("{Informe o endereço da Web API}");
            httpRequest.DefaultRequestHeaders.Accept.Clear();
            httpRequest.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            string profJson = Newtonsoft.Json.JsonConvert.SerializeObject(profAdd);
            var response = await httpRequest.PostAsync("api/professors",
                new StringContent(profJson, System.Text.Encoding.UTF8, "application/json"));

            if (response.IsSuccessStatusCode) return true;

            return false;
        }

        public static async Task<bool> DeleteProfessorSqlAzureAsync(string profId)
        {
            if (string.IsNullOrWhiteSpace(profId)) return false;

            var httpRequest = new HttpClient();
            httpRequest.BaseAddress = new Uri("{Informe o endereço da Web API}");
            httpRequest.DefaultRequestHeaders.Accept.Clear();
            httpRequest.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            var response = await httpRequest.DeleteAsync(string.Format("api/professors/{0}", profId));

            if (response.IsSuccessStatusCode) return true;

            return false;
        }
    }
}
