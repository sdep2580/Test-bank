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
    public class FCustomerDataController : Controller
    {
        // GET: FCustomerData
        public ActionResult Browse()
        {
            List<FCustomerData> list = new List<FCustomerData>();
            HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:49777/");
        //   client.BaseAddress = new Uri("http://leetestbank.somee.com/");
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync("api/fcustomerdata").Result;
            if (response.IsSuccessStatusCode)
            {
                list = response.Content.ReadAsAsync<List<FCustomerData>>().Result;
            }


            return View(list);
        }

        // 新增一筆資料
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(FCustomerData model)
        {
            HttpClient client = new HttpClient();
               client.BaseAddress = new Uri("http://localhost:49777/");
        //     client.BaseAddress = new Uri("http://leetestbank.somee.com/");
            client.PostAsJsonAsync("api/fcustomerData", model)
                .ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode());

            return RedirectToAction("Browse");
        }

        // 修改資料時的畫面
        [HttpGet]
        public ActionResult Edit(int id)
        {
            FCustomerData fcusdata = new FCustomerData();

            HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:49777/");
        //    client.BaseAddress = new Uri("http://leetestbank.somee.com/");
            HttpResponseMessage response = client.GetAsync("api/fcustomerdata/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                fcusdata = response.Content.ReadAsAsync<FCustomerData>().Result;
            }

            return View(fcusdata);
        }

        // 修改資料後送出
        [HttpPost]
        public ActionResult Edit(int id, FCustomerData model)
        {
            HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:49777/");
        //    client.BaseAddress = new Uri("http://leetestbank.somee.com/");

            client.DefaultRequestHeaders.Accept.Add(
                       new MediaTypeWithQualityHeaderValue("application/json"));
            /*
            string json = JsonConvert.SerializeObject(model);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PutAsync("api/fcustomerdata/" + model.FCustomerId,content).Result;
            */

            client.PutAsJsonAsync("api/fcustomerdata/" + id, model)
                        .ContinueWith((putTask) => putTask.Result.EnsureSuccessStatusCode());

            return RedirectToAction("Browse");
        }

        // 檢視單一資料內容
        public ActionResult Detail(int id)
        {
            FCustomerData model = new FCustomerData();
            HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:49777/");
        //    client.BaseAddress = new Uri("http://leetestbank.somee.com/");

            HttpResponseMessage response = client.GetAsync("api/fcustomerdata/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                model = response.Content.ReadAsAsync<FCustomerData>().Result;
            }

            return View(model);
        }

        // 檢視刪除資料畫面
        [HttpGet]
        public ActionResult Delete(int id)
        {
            FCustomerData model = new FCustomerData();
            HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:49777/");
        //    client.BaseAddress = new Uri("http://leetestbank.somee.com/");

            HttpResponseMessage response = client.GetAsync("api/fcustomerdata/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                model = response.Content.ReadAsAsync<FCustomerData>().Result;
            }

            return View(model);
        }

        // 確認刪除資料
        [HttpPost]
        public ActionResult Delete(int id, FCustomerData model)
        {

            HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:49777/");
         //   client.BaseAddress = new Uri("http://leetestbank.somee.com/");

            client.DefaultRequestHeaders.Accept.Add(
                       new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.DeleteAsync("api/fcustomerdata/" + id).Result;

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Browse");
            }

            return View();
        }


    }
}