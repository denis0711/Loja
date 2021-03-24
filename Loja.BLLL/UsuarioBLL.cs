using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Loja.DAL;
using Loja.DTO;

namespace Loja.BLLL
{
    public class UsuarioBLL
    {
        /*Metodo cargaUsuario, retorna uma lista de objetos usuario DTO 
         (composto por varios atributos), vai ate o BD e busca todos os usuarios
        Usamos o try e catch caso de algum erro, retorna para a camada View
        Executar o metodo cargaUsuario(Sera cirado na DAL)*/

        public IList<usuario_DTO> cargaUsario()
        {
            try
            {
                return new UsuarioDAL().cargaUsuario();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int insereUsuario(usuario_DTO USU)
        {
            /*Insere usuario sera criado na DAL*/
            try
            {
                return new UsuarioDAL().insereUsuario(USU);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int editaUsuario(usuario_DTO USU)
        {
            try
            {
                return new UsuarioDAL().editaUsuario(USU);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public int deletaUsuario (usuario_DTO USU)
        {
            try
            {
                return new UsuarioDAL().deletaUsuario(USU);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
