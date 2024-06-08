using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using TLA_SalseForeCast.Models;

namespace TLA_SalseForeCast.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly M_db _User;
        public UserController(M_db UserPermission)
        {
            _User = UserPermission;
        }
        [HttpGet]   
        public async Task<ActionResult<IEnumerable<UserModel>>> GetUser(string txt_email,string txt_password, string txt_selected)
        {
            if (_User.UserPermission == null)
            {
                return NotFound();
            }
            //var user = await _User.UserPermission.FindAsync(txt_email);
            var user = await _User.UserPermission.Where(a => a.Email == txt_email && a.Pass_id == txt_password).ToListAsync();
            if (user.Count==0) {
                return NotFound();
            }
            
            return await _User.UserPermission.ToListAsync();
        }
    }
}
