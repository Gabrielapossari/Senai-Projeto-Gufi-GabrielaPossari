using Senai.Gufi.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Gufi.WebApi.Interfaces
{
    interface IUsuariosRepository
    {
        List<Usuario> Listar();

        void Cadastrar(Usuario Usuarionovo);

        void Atualizar(int id,Usuario Usuarionovo);

        void Deletar(int id);

        Usuario BuscarPorId(int id);

        Usuario BuscarPorEmailSenha(string email, string senha);
        Usuario BuscarPorEmailSenha(object email, object senha);
    }
   
}
