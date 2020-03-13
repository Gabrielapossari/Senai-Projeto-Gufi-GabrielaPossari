using Senai.Gufi.WebApi.Domains;
using Senai.Gufi.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Gufi.WebApi.Repositories
{
    public class  TipoUsuarioRepository  : ITipoUsuarioRepository
    {
        GufiContext ctx = new GufiContext();

        public void Atualizar (int id, TipoUsuario usuariotipoAtualizado)
        {
            TipoUsuario UsuarioTipoBuscado = ctx.TipoUsuario.Find(id);

            UsuarioTipoBuscado.IdTipoUsuario = usuariotipoAtualizado.IdTipoUsuario;

            ctx.TipoUsuario.Update(UsuarioTipoBuscado);

            ctx.SaveChanges();
        }

        public TipoUsuario BuscarPorId(int id)
        {
            return ctx.TipoUsuario.FirstOrDefault(te => te.IdTipoUsuario == id);
        }

        public void Cadastrar(TipoUsuario TipoUsuarionovo)
        {
            ctx.TipoUsuario.Add(TipoUsuarionovo);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            ctx.TipoUsuario.Remove(BuscarPorId(id));

            ctx.SaveChanges();
        }

        public List<TipoUsuario> Listar()
        {
            return ctx.TipoUsuario.ToList();
        }

    }
}
