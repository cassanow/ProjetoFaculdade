using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using ProjetoFaculdade.DTO;
using ProjetoFaculdade.Interface;
using ProjetoFaculdade.Mapper;
using ProjetoFaculdade.Models;

namespace ProjetoFaculdade.Controllers;

public class UsuarioController : Controller
{
    private readonly IUsuarioRepository _usuarioRepository;

    public UsuarioController(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }
    
    [HttpGet]
    public IActionResult Registrar()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Registrar(Usuario usuario)
    {

        if (User.Identity.IsAuthenticated)
        {
            return RedirectToAction("ObterUsuarios", "Home");
        }

        if (ModelState.IsValid && !await _usuarioRepository.UsuarioExiste(usuario.Email))
        {
            await _usuarioRepository.Registrar(usuario);
            return RedirectToAction("ObterUsuarios", "Home");
        }

        if (await _usuarioRepository.UsuarioExiste(usuario.Email))
        {
            ModelState.AddModelError(string.Empty, "Email já cadastrado!");
        }
        
        return View(usuario);
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(LoginDTO dto)
    {
        var usuario = await _usuarioRepository.ObterUsuario(dto.Email);

        if (User.Identity.IsAuthenticated)
        {
            return RedirectToAction("ObterUsuarios", "Home");
        }

        if (ModelState.IsValid && usuario != null && usuario.Email == dto.Email && usuario.Senha == dto.Senha)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, usuario.Email),
                new Claim(ClaimTypes.Role, "Usuario")
            };
            
            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            
            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity));
            
            return RedirectToAction("ObterUsuarios", "Home");
        }

        ModelState.AddModelError(string.Empty, "Usuário ou senha incorretos");
        return View(usuario);
    }

    [HttpPost]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return RedirectToAction("Login", "Usuario");
    }
}