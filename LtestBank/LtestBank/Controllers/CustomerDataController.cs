using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LtestBank.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Text;

namespace LtestBank.Controllers
{
    public class CustomerDataController : Controller
    {

        // 首頁放置全部資料
        // GET: CustomerData
        public ActionResult Browse(string customerNo)
        {
            List<CustomerData> list = new List<CustomerData>();
            HttpClient client = new HttpClient();

                client.BaseAddress = new Uri("http://localhost:49777/");
        //    client.BaseAddress = new Uri("http://leetestbank.somee.com/");
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync("api/customerdata").Result;
            if (response.IsSuccessStatusCode)
            {
                list = response.Content.ReadAsAsync<List<CustomerData>>().Result;
            }

            var model = from m in list select m;
            //過濾單筆資料
            if (!string.IsNullOrEmpty(customerNo))
            {
                model = list.Where(s => s.CustomerNo.Contains(customerNo));
            }
            return View(model);
        }

        // 新增一筆資料
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CustomerData  model)
        {
            HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:49777/");
        //    client.BaseAddress = new Uri("http://leetestbank.somee.com/");

            client.PostAsJsonAsync("api/customerdata", model)
                .ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode());

            return RedirectToAction("Browse") ;
        }

        // 修改資料時的畫面
        [HttpGet]
        public ActionResult Edit(int id)
        {
            CustomerData cusdata = new CustomerData();

            HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:49777/");
        //   client.BaseAddress = new Uri("http://leetestbank.somee.com/");
            HttpResponseMessage response = client.GetAsync("api/customerdata/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                cusdata = response.Content.ReadAsAsync<CustomerData>().Result;
            }

            //   return View(cusdata);
            return View(cusdata);
        }

        // 修改資料後送出
        [HttpPost]
        public ActionResult Edit(int id,CustomerData model)
        {
            HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:49777/");
        //    client.BaseAddress = new Uri("http://leetestbank.somee.com/");

            client.DefaultRequestHeaders.Accept.Add(
                       new MediaTypeWithQualityHeaderValue("application/json"));
            /*
            string json = JsonConvert.SerializeObject(model);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PutAsync("api/customerdata/" + model.CustomerId,content).Result;
            */

            client.PutAsJsonAsync("api/customerdata/" + id, model)
                        .ContinueWith((putTask) => putTask.Result.EnsureSuccessStatusCode());

            return RedirectToAction("Browse");
        }

        // 檢視單一資料內容
        public ActionResult Detail(int id)
        {
            CustomerData model = new CustomerData();
            HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:49777/");
        //    client.BaseAddress = new Uri("http://leetestbank.somee.com/");

            HttpResponseMessage response = client.GetAsync("api/customerdata/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                model = response.Content.ReadAsAsync<CustomerData>().Result;
            }

            return View(model);
        }

        // 檢視刪除資料畫面
        [HttpGet]
        public ActionResult Delete(int id)
        {
            CustomerData model = new CustomerData();
            HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:49777/");
        //    client.BaseAddress = new Uri("http://leetestbank.somee.com/");

            HttpResponseMessage response = client.GetAsync("api/customerdata/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                model = response.Content.ReadAsAsync<CustomerData>().Result;
            }

            return View(model);
        }

        // 確認刪除資料
        [HttpPost]
        public ActionResult Delete(int id,CustomerData model)
        {
            
            HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:49777/");
        //    client.BaseAddress = new Uri("http://leetestbank.somee.com/");

            client.DefaultRequestHeaders.Accept.Add(
                       new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.DeleteAsync("api/customerdata/" + id).Result;

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Browse");
            }

            return View();
        }

    }
}