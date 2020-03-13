using Senai.Gufi.WebApi.Domains;
using Senai.Gufi.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Gufi.WebApi.Repositories
{
    public class UsuariosRepository : IUsuariosRepository
    {
        GufiContext ctx = new GufiContext();

        public List<Usuario> Listar()
        {
            return ctx.Usuario.ToList();
        }
        public void Cadastrar(Usuario Usuarionovo)
        {
            ctx.Usuario.Add(Usuarionovo);

            ctx.SaveChanges();
        }
        public Usuario BuscarPorId(int id)
        {
            return ctx.Usuario.FirstOrDefault(te => te.IdUsuario == id);
        }
        public void Deletar(int id)
        {
            ctx.Usuario.Remove(BuscarPorId(id));

            ctx.SaveChanges();
        }

        public void Atualizar(int id, Usuario UsuarioAtualizado)
        {
            Usuario UsuarioBuscado = ctx.Usuario.Find(id);

            UsuarioBuscado.IdUsuario = UsuarioAtualizado.IdUsuario;
            UsuarioBuscado.NomeUsuario = UsuarioAtualizado.NomeUsuario;
            UsuarioBuscado.Email = UsuarioAtualizado.Email;
            UsuarioBuscado.Senha = UsuarioAtualizado.Senha;
            UsuarioBuscado.DataNascimento = UsuarioAtualizado.DataNascimento;

            ctx.Usuario.Update(UsuarioBuscado);

            ctx.SaveChanges();
        }
        public Usuario BuscarPorEmailSenha(string email,string senha)
        {
            return ctx.Usuario.FirstOrDefault(u => u.Email == email && u.Senha == senha);
        }
    }
}
