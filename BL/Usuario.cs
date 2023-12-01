using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Usuario
    {
        public static ML.Result GetUserName(string UserName, string Password)
        {

            ML.Result result = new ML.Result();
            try
            {
                using(DL.MarzanEntities context = new DL.MarzanEntities())
                {
                    var query = context.GetUserName(UserName, Password).FirstOrDefault();
                    result.Object= new List<object>();
                    if(query != null)
                    {
                        ML.Usuario usuario = new ML.Usuario();
                        usuario.IdUsuario = query.IdUsuario;
                        usuario.UserName = query.UserName;
                        usuario.Password = query.Password;

                        result.Object = usuario;
                        result.Correct = true;
                    }
                }

            }catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessaage = ex.Message;

            }
            return result;
        }
    }
}
