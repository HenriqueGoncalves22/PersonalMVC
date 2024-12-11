using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PersonalMVC.Models;
using System.Net.Http.Headers;
using System.Net.Http;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure;


namespace PersonalMVC.Controllers;

public class ViolinosController : Controller
{
    public string uriBase = "http://rique.somee.com/PersonalApi/Violinos/";
    public IActionResult Index()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View("Error!");
    }

    [HttpGet]
    public async Task<ActionResult> IndexAsync()
    {
        try
        {
            string uriComplementar = "GetAll";

            HttpClient httpClient = new HttpClient();
            //string token = HttpContext.Session.GetString("SessionTokenUsuario");
            //httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            HttpResponseMessage response = await httpClient.GetAsync(uriBase + uriComplementar);
            string serialized = await response.Content.ReadAsStringAsync();

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                List<ViolinoViewModel> listaViolinos = await Task.Run(() =>
                JsonConvert.DeserializeObject<List<ViolinoViewModel>>(serialized));

                return View(listaViolinos);
            }
            else
                throw new System.Exception(serialized);
        }
        catch (System.Exception ex)
        {
            TempData["MensagemErro"] = ex.Message;
            return RedirectToAction("Index");
        }
    }

    [HttpPost]
    public async Task<ActionResult> CreateAsync (ViolinoViewModel v)
    {
        try
        {
            HttpClient httpClient = new HttpClient();
            //string token = HttpContext.Session.GetString("SessionTokenUsuario");
            //httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var content = new StringContent(JsonConvert.SerializeObject(v));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            HttpResponseMessage response = await httpClient.PostAsync(uriBase, content);
            string serialized = await response.Content.ReadAsStringAsync();

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                TempData["Mensagem"] = string.Format("Violino da {0}, Id {1} salvo com sucesso!", v.Marca, serialized);
                return RedirectToAction("Index");
            }
            else
                throw new System.Exception(serialized);
        }
        catch (System.Exception ex)
        {
            TempData["MensagemErro"] = ex.Message;
            return RedirectToAction("Create");
        }
    }

    [HttpGet]
    public ActionResult Create()
    {
        return View();
    }

    [HttpGet]
    public async Task<ActionResult> DetailsAsync(int? id)
    {
        try
        {
            HttpClient httpClient = new HttpClient();
           // string token = HttpContext.Session.GetString("SessionTokenUsuario");
           // httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await httpClient.GetAsync(uriBase + id.ToString());
            string serialized = await response.Content.ReadAsStringAsync();

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                ViolinoViewModel v = await Task.Run(() =>
                JsonConvert.DeserializeObject<ViolinoViewModel>(serialized));
                return View(v);
            }
            else
                throw new System.Exception(serialized);
        }
        catch (System.Exception ex)
        {
            TempData["MensagemErro"] = ex.Message;
            return RedirectToAction("Index");
        }
    }

    [HttpGet]
    public async Task<ActionResult> EditAsync(int? id)
    {
        try
        {
            HttpClient httpClient = new HttpClient();
           // string token = HttpContext.Session.GetString("SessionTokenUsuario");
           // httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await httpClient.GetAsync(uriBase + id.ToString());
            string serialized = await response.Content.ReadAsStringAsync();

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                ViolinoViewModel v = await Task.Run(() =>
                JsonConvert.DeserializeObject<ViolinoViewModel>(serialized));
                return View(v);
            }
            else
                throw new System.Exception(serialized);
        }
        catch (System.Exception ex)
        {
            TempData["MensagemErro"] = ex.Message;
            return RedirectToAction("Index");
        }
    }

    [HttpPost]
    public async Task<ActionResult> EditAsync(ViolinoViewModel v)
    {
        try
        {
            HttpClient httpClient = new HttpClient();
           // string token = HttpContext.Session.GetString("SessionTokenUsuario");
           // httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var content = new StringContent(JsonConvert.SerializeObject(v));
            content.Headers.ContentType = new MediaTypeHeaderValue("aplication/json");
            HttpResponseMessage response = await httpClient.PutAsync(uriBase, content);
            string serialized = await response.Content.ReadAsStringAsync();

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                TempData["Mensagem"] =
                    string.Format("Violino da {0}, modelo {1} atualizado com sucesso!", v.Marca, v.Modelo);
                return RedirectToAction("Index");
            }
            else
                throw new System.Exception(serialized);
        }
        catch (System.Exception ex)
        {
            TempData["MensagemErro"] = ex.Message;
            return RedirectToAction("Index");
        }
    }

    [HttpGet]
    public async Task<ActionResult> DeleteAsync (int id)
    {
        try
        {
            HttpClient httpClient = new HttpClient();
           // string token = HttpContext.Session.GetString("SessionTokenUsuario");
           // httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            HttpResponseMessage response = await httpClient.DeleteAsync(uriBase + id.ToString());
            string serialized = await response.Content.ReadAsStringAsync();

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                TempData["Mensagem"] = string.Format("Violino Id {0} removido com sucesso!", id);
                return RedirectToAction("Index");
            }
            else
                throw new System.Exception(serialized);
        }
        catch (System.Exception ex)
        {
            TempData["MensagemErro"] = ex.Message;
            return RedirectToAction("Index");
        }
    }
}