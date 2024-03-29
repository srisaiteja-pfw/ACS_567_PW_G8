using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using HW.Models;
using static System.Net.Mime.MediaTypeNames;
namespace FintechWebApp.Pages.FintechApp
{
    public class MedianModel : PageModel
    {
        /// <summary>
		/// It declares a public DataAnalysis object named fini.
		/// </summary>
		public FinTechModel fini = new();
        /// <summary>
        /// It declares a public dictionary named dictionary, which will store the analysis data.
        /// </summary>
        public Dictionary<string, string> dictionary = new Dictionary<string, string>();

        /// <summary>
        /// It declares a public asynchronous method named OnGet.
        /// </summary>
        public async Task OnGet()
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5264");
                // creates a new HttpClient GET request to the "Bills/Analyse" API endpoint.
                //HTTP GET
                var responseTask = client.GetAsync("/Fintech/Median");
                responseTask.Wait();

                var readTask = await responseTask.Result.Content.ReadAsStringAsync();
                //The dictionary object is then used in the Razor Page to display the analysis data.
                dictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(readTask);


            }
        }
    }
}
