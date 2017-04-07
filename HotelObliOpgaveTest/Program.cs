using System;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;


namespace HotelObliOpgaveTest
{
    class Program
    {
        static void Main(string[] args)
        {
            const string ServerURL ="http://localhost:18543/";
            
            //Post-Test            
            using (var client = new HttpClient())
            {                
                //Get Guest
                client.BaseAddress = new Uri(ServerURL);
                client.DefaultRequestHeaders.Clear();
                string urlString = "api/guests";
                try
                {
                    HttpResponseMessage response = client.GetAsync(urlString).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var GuestList = response.Content.ReadAsAsync<List<Guest>>().Result;
                        foreach (var Guest in GuestList)
                        {
                            Console.WriteLine("ID: "+ Guest.Guest_No + "Navn : " + Guest.Name + "Address : " + Guest.Address);
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Der er sket en fejl : " + e.Message);
                }
            }
            Console.ReadKey();
        }                       
    }
}
