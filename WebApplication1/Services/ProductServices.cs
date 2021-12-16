using Newtonsoft.Json;
using Northwind_MVC.Model;
using System.Net.Http.Headers;

namespace Exercice_Intégré.Services
{
    public class ProductServices
    {
        public readonly string baseAddress = "https://localhost:7208/";
        //Uri baseAddress = new Uri("https://localhost:7208/Products/");
        HttpClient client;

        public ProductServices() {

            client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7208/");
        }

        public async Task<Products> getProduct(int id) {
            string urlAddress = baseAddress + String.Format("Products/{0}",id);
            
 
            Products product = new Products();
            HttpResponseMessage response = await client.GetAsync(urlAddress);
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                product = JsonConvert.DeserializeObject<Products>(data);
            }
            else
            {
                Console.WriteLine("rio");
            }
            
            return product;

        }

        
        public async Task<List<Products>> getProducts()
        {

            string urlAddress = baseAddress + "Products";
            //client.BaseAddress = new Uri(baseAddress);
            List<Products> products = new List<Products>();
            HttpResponseMessage response = await client.GetAsync(urlAddress);
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                products = JsonConvert.DeserializeObject<List<Products>>(data);
            }
            else
            {
                Console.WriteLine("rio");
            }

            return products;
        }


    }
}
