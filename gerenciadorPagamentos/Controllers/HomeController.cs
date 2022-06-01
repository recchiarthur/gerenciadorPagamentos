using gerenciadorPagamentos.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace gerenciadorPagamentos.Controllers
{
    public class HomeController : Controller
    {
        private readonly PagamentoContext _context;

        public HomeController(PagamentoContext context)
        {
            _context = context;
        }
        public IActionResult Editar(int id)
        {
            Pagamento pagamento = new Pagamento();
            pagamento = _context.Pagamento.FirstOrDefault(a => a.Id == id);

            if (pagamento.Id == 0)
            {
                return View("PagamentoNaoEncontrado");
            }

            return View("Cadastrar", pagamento);
        }
        
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Cadastrar()
        {
            return View();
        }

        public IActionResult Listar()
        {
            return View("Listar", _context.Pagamento.ToList());
        }

        public IActionResult Salvar(Pagamento pagamento)
        {
            Pagamento pgmnt = new Pagamento();
            pgmnt = _context.Pagamento.FirstOrDefault(a => a.Id == pagamento.Id);
            Pagamento verificaCodBarras = _context.Pagamento.FirstOrDefault(a => a.codigo_barras == pagamento.codigo_barras);
            Pagamento verificaDescricao = _context.Pagamento.FirstOrDefault(a => a.descricao == pagamento.descricao);
            if(verificaDescricao != null)
            {
                return Content("ERRO");
            }
            if (verificaCodBarras != null)
            {
                return View("CodigoExistente");
            }
            if (pgmnt == null)
            {
                _context.Pagamento.Add(pagamento);
                _context.SaveChanges();
            }
            else
            {
                _context.Entry(pgmnt).CurrentValues.SetValues(pgmnt);
                _context.SaveChanges();
            }

            return RedirectToAction("Listar");
        }
        public IActionResult Excluir(int id)
        {
            Pagamento pagamento = _context.Pagamento.FirstOrDefault(a => a.Id == id);

            _context.Pagamento.Remove(pagamento);
            _context.SaveChanges();

            return RedirectToAction("Listar");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}