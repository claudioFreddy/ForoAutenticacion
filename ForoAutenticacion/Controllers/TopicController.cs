using ForoAutenticacion.Data;
using ForoAutenticacion.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class TopicController : Controller
{
    private readonly AppDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;

    public TopicController(AppDbContext context, UserManager<ApplicationUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    public async Task<IActionResult> Index()
    {
        var temas = await _context.Topics.ToListAsync();
        return View(temas);
    }

    public async Task<IActionResult> Details(int id)
    {
        var tema = await _context.Topics
            .Include(t => t.Respuestas)
            .FirstOrDefaultAsync(t => t.Id == id);

        if (tema == null)
            return NotFound();

        return View(tema);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AgregarRespuesta(int topicId, string contenido)
    {
        var usuario = await _userManager.GetUserAsync(User);

        var respuesta = new Respuesta
        {
            TopicId = topicId,
            Contenido = contenido,
            AutorEmail = usuario?.Email
        };

        _context.Respuestas.Add(respuesta);
        await _context.SaveChangesAsync();

        return RedirectToAction("Details", new { id = topicId });
    }

    [Authorize]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize]
    public async Task<IActionResult> Create(Topic topic)
    {
        if (ModelState.IsValid)
        {
            topic.AutorEmail = User.Identity.Name;
            topic.FechaCreacion = DateTime.Now;

            _context.Add(topic);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(topic);
    }

}

/*using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ForoAutenticacion.Controllers
{
    public class TopicController : Controller
    {
        // GET: TopicController
        public ActionResult Index()
        {
            return View();
        }

        // GET: TopicController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TopicController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TopicController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: TopicController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TopicController/Edit/5
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

        // GET: TopicController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TopicController/Delete/5
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
*/