//IMPORTA AS BIBLIOTECAS QUE SERÃO UTILIZADAS NO PROJETO
using Microsoft.AspNetCore.Mvc;
using ProjetoLoja2.Models;
using ProjetoLoja2DSA.Repositorio;

//DEFINE O NOME E ONDE A CLASSE USUARIOCONTROLLER ESTA LOCALIZADA
// NAMESPACE AJUDA A ORGANIZAR O CODIGO E EVITAR CONFLITOS.
namespace ProjetoLoja2DSA.Controllers
{
    //CLASSE USUARIOCONTROLLER QUE ESTA HERDANDO DA CLASSE PAI CONTROLLER
    public class usuariocontroller : Controller
    {
        //DECLARA A VARIAVEL PRIVADA E SOMENTE LEITURA DO TIPO USUARIOREPOSITORIO
        //INSTANCIA O _usuarioController PARA SER ATRIBUIDO NO CONSTRUTOR E INTERAGIR COM O DADOS 
        private readonly usuariorepositorio _usuarioRepositorio;

        //DEFINE O CONRDTRUTOR DA CLASSE USUARIOCONTROLLER 
        //RECEBE A INSTANCIA DE USUARIOREPOSITORIO  COM PARAMETROS
        public usuariocontroller(usuariorepositorio usuarioRepositorio)
        {
            // O CONSTRUTOR É CHAMADO QUANDO UMA NOVA INSTANCIA É CRIADA
            usuarioRepositorio = usuarioRepositorio;
        }


        //INTERFACE QUE REPRESENTA O RESULTADO DA PÁGINA 

        //pega os dados do servidor(banco)
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        //requisição para enviar os dados para o servidor
        [HttpPost]
        public IActionResult Login(string email, string senha)
        {
            var usuario = _usuarioRepositorio.ObterUsuario(email);

            if (usuario != null && usuario.senha == senha)
            {
                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("", "Email / senha Inválidos");


            //RETORNA A PAGINA INDEX
            return View();
        }
        // CADASTRO

        public IActionResult Cadastro()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastro(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _usuarioRepositorio.AdicionarUsuario(usuario);
                return RedirectToAction("Login");
            }

            return View();
        }
    }
}
