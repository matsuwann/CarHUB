using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CarHUB.Models;
using Newtonsoft.Json;
using System.Text;

namespace CarHUB.Controllers
{
    public class CarController : Controller
    {
        // GET: CarController
        public async Task<ActionResult> Index()
        {
            string apiUrl = "https://localhost:7005/api/car";

            List<Cars> cars = new List<Cars>();

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl);

                var result = await response.Content.ReadAsStringAsync();
                cars = JsonConvert.DeserializeObject<List<Cars>>(result);
            }

            return View(cars);

        }

            // GET: CarController/Details/5
            public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CarController/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Cars cars)
        {
            string apiUrl = "https://localhost:7005/api/car";
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(cars), Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(apiUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(cars);
        }

        // GET: CarController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CarController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CarController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CarController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
