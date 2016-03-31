using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using GigaLoan_Model;
using Newtonsoft.Json;

namespace GigALoanWPF
{
    public class ServiceLayer
    {
        private const string URL = @"http://www.jumpcreek.com/GigALoan/GigALoanService.svc/";

        public string ServerMessage { get; set; }
        private readonly HttpClient client = new HttpClient();
        public List<DTO_College> colleges = new List<DTO_College>();
        public List<DTO_CORE_GigAlert> alerts = new List<DTO_CORE_GigAlert>();

        public ServiceLayer()
        {
            client.BaseAddress = new Uri(URL);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.Timeout = new TimeSpan(0, 5, 0);
        }

        public async Task GetColleges()
        {
            DTO_College token = new DTO_College { CollegeID = 1 };

            ServerMessage = string.Empty;
            try
            {
                HttpResponseMessage response = await client.PostAsJsonAsync(string.Format(@"{0}{1}", URL, "GetColleges"), token);
                response.EnsureSuccessStatusCode();
                colleges = await response.Content.ReadAsAsync<List<DTO_College>>();
            }
            catch (HttpRequestException hre)
            {
                Debug.WriteLine(hre.Message);
            }
        }

        public async Task GetCollege()
        {
            DTO_College token = new DTO_College { CollegeID = 1 };

            ServerMessage = string.Empty;
            try
            {
                HttpResponseMessage response = await client.PostAsJsonAsync(string.Format(@"{0}{1}", URL, "GetCollege"), token);
                response.EnsureSuccessStatusCode();
                colleges = await response.Content.ReadAsAsync<List<DTO_College>>();
            }
            catch (HttpRequestException hre)
            {
                Debug.WriteLine(hre.Message);
            }
        }

        public async Task GetAlert()
        {
            DTO_CORE_GigAlert request = new DTO_CORE_GigAlert { AlertID = 100 };
            
            HttpClient myClient = new HttpClient();
            string myURL = @"http://www.jumpcreek.com/gtc_spring/Search_Service.svc/";
            //string myURL = @"http://localhost:20078/Search_Service.svc/";

            ServerMessage = string.Empty;
            myClient.BaseAddress = new Uri(myURL);
            myClient.DefaultRequestHeaders.Accept.Clear();
            myClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            myClient.Timeout = new TimeSpan(0, 5, 0);
            try
            {
                string wtf = JsonConvert.SerializeObject(request);
                HttpResponseMessage response = await myClient.PostAsJsonAsync(string.Format(@"{0}{1}", myURL, "FindAlertByID"), wtf);
                response.EnsureSuccessStatusCode();
                alerts = await response.Content.ReadAsAsync<List<DTO_CORE_GigAlert>>();
            }
            catch (HttpRequestException hre)
            {
                Debug.WriteLine(hre.Message);
            }
        }
    }
}

