using EasyProjectG.Models;
using EasyProjectG.ViewModel;
using System.Linq;
using System.Web.Mvc;

namespace EasyProjectG.Controllers
{
    public class GerenciaUsuariosController : Controller
    {
        private ApplicationDbContext context;

        public GerenciaUsuariosController()
        {
            context = new ApplicationDbContext();
        }

        public ActionResult UsuariosComPerfils()
        {
            var usuariosComPerfis = (from user in context.Users
                                  select new
                                  {
                                      UserId = user.Id,
                                      Username = user.UserName,
                                      Email = user.Email,
                                      RoleNames = (from userRole in user.Roles
                                                   join role in context.Roles on userRole.RoleId
                                                   equals role.Id
                                                   select role.Name).ToList()
                                  }).ToList().Select(p => new UsersInRoleViewModel()

                                  {
                                      UserId = p.UserId,
                                      Username = p.Username,
                                      Email = p.Email,
                                      Role = string.Join(",", p.RoleNames)
                                  });


            return View(usuariosComPerfis);
        }
    }
}