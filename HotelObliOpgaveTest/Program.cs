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
            var TestGuest = new Guest()
            {
                Name = "TestBob",
                Address = "TestStreet",
                Guest_No = 555
            };


            //Post-Test            
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ServerURL);
                client.DefaultRequestHeaders.Clear();

                try
                {
                    var response = client.PostAsJsonAsync<Guest>("api/Guest", TestGuest).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        Console.WriteLine("Du har indsat en ny gæst");
                        Console.WriteLine("Post context: " + response.Content.ReadAsStringAsync());
                    }
                    else
                    {
                        Console.WriteLine("Fejl, Eventet blev ikke oprettet!");
                        Console.WriteLine("Statuscode: " + response.StatusCode);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Der er sket en fejl : " + e.Message);
                }
                Console.WriteLine();
                Console.WriteLine();


                //Get Guest
                client.BaseAddress = new Uri(ServerURL);
                client.DefaultRequestHeaders.Clear();
                string urlString = "api/guests/555";
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
        }                       
    }
}
