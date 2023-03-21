using Microsoft.AspNetCore.Mvc;
using myfinance_web_dotnet.Models;
using myfinance_web_dotnet.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace myfinance_web_dotnet.Controllers
{
    [Route("[controller]")]
    public class TransacaoController : Controller
    {
        private readonly ILogger<TransacaoController> _logger;
        private readonly ITransacaoService _service;
        private readonly IPlanoContaService _PlanoContaService;

        public TransacaoController(ILogger<TransacaoController> logger,
        ITransacaoService service, IPlanoContaService PlanoContaService)
        {
            _logger = logger;
            _service = service;
            _PlanoContaService = PlanoContaService;
        }

        [HttpGet]
        [Route("Index")]
        public IActionResult Index()
        {
            ViewBag.ListaTransacao = _service.GetAll();
            return View();
        }

        [HttpGet]
        [Route("Cadastrar")]
        [Route("Cadastrar/{id}")]
        public IActionResult Cadastrar(int? id)
        {
            var model = new TransacaoModel();

            if (id != null)
            {
                model = _service.Get((int)id);
            } else {
                model.DataTransacao = DateTime.Now;
            }

            var listPlanoConta = _PlanoContaService.GetAll();
            model.PlanoContas = new SelectList(listPlanoConta, "Id", "Description");            
            
            return View(model);
        }

        [HttpPost]
        [Route("Cadastrar")]
        [Route("Cadastrar/{id}")]
        public IActionResult Cadastrar(TransacaoModel model)
        {
            _service.Save(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            _service.Delete(id);
            return RedirectToAction("Index");
        }
    }
}