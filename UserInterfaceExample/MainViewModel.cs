using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace UserInterfaceExample
{
    public class MainViewModel : ViewModel
    {


        string statusText = "";

        public string StatusText { get => statusText; set { statusText = value; Notify("StatusText"); } }



        readonly Uri webServiceUri = new Uri("http://localhost:53750/");



        public ICommand Load { get; private set; }

        async void LoadImplementation()
        {
            StatusText = "Loading...";

            try
            {
                MainData data = await MakeRequestAsync("main");
                StatusText = data.Text;
            }
            catch (Exception ex)
            {
                StatusText = "Error";
            }
        }



        /// <summary>
        /// Make a service request
        /// </summary>
        private async Task<MainData> MakeRequestAsync(string path)
        {
            // create http request
            HttpClient client = new HttpClient
            {
                BaseAddress = webServiceUri
            };         

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


            // make request
            HttpResponseMessage response = await client.GetAsync(path);

            // deserialize response object
            using (MemoryStream stream = new MemoryStream(Encoding.Unicode.GetBytes(await response.Content.ReadAsStringAsync())))
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(MainData));
                return (MainData)serializer.ReadObject(stream);
            }
        }


        public static MainViewModel Instance { get; private set; }
        

        static MainViewModel()
        {
            Instance = new MainViewModel();
        }

        MainViewModel()
        {
            Load = new RelayCommand(LoadImplementation);
        }

    }
}
