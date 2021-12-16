using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Northwind_MVC.Model;
using System.Net.Http.Headers;
using System.Text;

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

        public async Task<Products> Create(Products product)
        {
            string jsonString = JsonConvert.SerializeObject(product, Formatting.Indented);
            string urlAddress = baseAddress + "Products/";
            var json = JsonConvert.SerializeObject(product);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(urlAddress, data);
            string result = response.Content.ReadAsStringAsync().Result;
            product = JsonConvert.DeserializeObject<Products>(result);
            Console.WriteLine(result);
            Console.WriteLine();
            return product;
          
        }

        public async Task<int> Delete(int id)
        {
           
            string urlAddress = baseAddress + "Products/"+id;
            var response = await client.DeleteAsync(urlAddress);
            string result = response.Content.ReadAsStringAsync().Result;

            return id;
            

        }



    }
}
