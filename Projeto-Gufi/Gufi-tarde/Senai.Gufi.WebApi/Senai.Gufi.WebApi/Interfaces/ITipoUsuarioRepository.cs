using Senai.Gufi.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Gufi.WebApi.Interfaces
{
    interface ITipoUsuarioRepository
    {
        List<TipoUsuario> Listar();

        void Cadastrar(TipoUsuario TipoUsuarionovo);

        void Atualizar(int id, TipoUsuario usuariotipoAtualizado);

        void Deletar(int id);

        TipoUsuario BuscarPorId(int id);
    }
}
