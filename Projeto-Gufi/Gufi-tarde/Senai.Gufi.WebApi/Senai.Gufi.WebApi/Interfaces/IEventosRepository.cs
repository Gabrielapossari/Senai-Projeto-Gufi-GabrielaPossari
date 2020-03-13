using Senai.Gufi.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Gufi.WebApi.Interfaces
{
    interface IEventosRepository
    {
        List<Evento> Listar();

        void Cadastrar(Evento Eventonovo);

        void Atualizar(int id, Evento Eventonovo);

        void Deletar(int id);

        Evento BuscarPorId(int id);
    }
}
