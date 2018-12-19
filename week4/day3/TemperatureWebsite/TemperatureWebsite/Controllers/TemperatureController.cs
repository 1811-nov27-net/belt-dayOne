using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TemperatureWebsite.Models;

namespace TemperatureWebsite.Controllers
{
    public class TemperatureController : Controller
    {
        public HttpClient Client { get; set; }

        public TemperatureController(HttpClient client)
        {
            Client = client;
        }
        // GET: Temperature
        public async Task<ActionResult> Index()
        {
            HttpResponseMessage response = await Client.GetAsync("https://localhost:44371/api/Temperature");

            if(!response.IsSuccessStatusCode)
            {
                return RedirectToAction("Error", "Home");
            }

            var responseBody = await response.Content.ReadAsStringAsync();

            List<TemperatureRecord> temperature = JsonConvert.DeserializeObject<List<TemperatureRecord>>(responseBody);



            return View(temperature);
        }

        // GET: Temperature/Details/5
        public async Task<ActionResult> Details(int id)
        {
            HttpResponseMessage response = await Client.GetAsync($"https://localhost:44371/api/Temperature/{id}");

            if (!response.IsSuccessStatusCode)
            {
                return RedirectToAction("Error", "Home");
            }

            var responseBody = await response.Content.ReadAsStringAsync();

            TemperatureRecord temperature = JsonConvert.DeserializeObject<TemperatureRecord>(responseBody);

            return View(temperature);
        }

        // GET: Temperature/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Temperature/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(TemperatureRecord temperature)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    HttpResponseMessage response = await Client.PostAsJsonAsync("https://localhost:44371/api/Temperature", temperature);
                    return RedirectToAction(nameof(Index));
                }
                return RedirectToAction("Error", "Home");

                
            }
            catch
            {
                return View();
            }
        }

        // GET: Temperature/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            HttpResponseMessage response = await Client.GetAsync($"https://localhost:44371/api/Temperature/{id}");

            if (!response.IsSuccessStatusCode)
            {
                return RedirectToAction("Error", "Home");
            }

            var responseBody = await response.Content.ReadAsStringAsync();

            TemperatureRecord temperature = JsonConvert.DeserializeObject<TemperatureRecord>(responseBody);

            return View(temperature);
        }

        // POST: Temperature/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, TemperatureRecord temperature)
        {
            try
            {
                HttpResponseMessage response = await Client.PutAsJsonAsync($"https://localhost:44371/api/Temperature/{id}", temperature);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Temperature/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            HttpResponseMessage response = await Client.GetAsync($"https://localhost:44371/api/Temperature/{id}");

            if (!response.IsSuccessStatusCode)
            {
                return RedirectToAction("Error", "Home");
            }

            var responseBody = await response.Content.ReadAsStringAsync();

            TemperatureRecord temperature = JsonConvert.DeserializeObject<TemperatureRecord>(responseBody);

            return View(temperature);
        }

        // POST: Temperature/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, TemperatureRecord temperature)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    HttpResponseMessage response = await Client.DeleteAsync($"https://localhost:44371/api/Temperature/{id}");
                    if (!response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Error", "Home");
                    }
                    return RedirectToAction(nameof(Index));
                }

                return RedirectToAction("Error","Home");
            }
            catch
            {
                return View();
            }
        }
    }
}