using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SchoolSAEP.Models;
using SchoolSAEP.ViewModels;

namespace SchoolSAEP.Controllers
{
    public class ProfessorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        private readonly SignInManager<Professor> _signInManager;
        private readonly UserManager<Professor> _userManager;

        public ProfessorController(SignInManager<Professor> signInManager)
        {
            _signInManager = signInManager;
        }
        public ProfessorController(UserManager<Professor> userManager)
        {
            _userManager = userManager;
        }

        // Action para exibir a tela de login
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // Action para processar o login
        [HttpPost]
        public async Task<IActionResult> Login(ProfessorViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home"); // Redirecionar para a tela principal do professor
                }

                ModelState.AddModelError(string.Empty, "Login inválido");
            }

            return View(model);
        }

        // Action para fazer logout
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Auth"); // Redirecionar para a tela de login
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(ProfessorViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new Professor { UserName = model.Email, Email = model.Email, Nome = model.Nome };
                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("TelaPrincipalProfessor", "NomeDoController"); // Redirecionar para a tela principal do professor
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View(model);
        }
    }
}
