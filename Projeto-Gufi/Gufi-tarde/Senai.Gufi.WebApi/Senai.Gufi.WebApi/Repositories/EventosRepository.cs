using Senai.Gufi.WebApi.Domains;
using Senai.Gufi.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Gufi.WebApi.Repositories
{
     public class  EventosRepository : IEventosRepository
    {
        GufiContext ctx = new GufiContext();

        public List<Evento> Listar()
        {

            return ctx.Evento.ToList();
        }
        public void Cadastrar(Evento Eventonovo)
        {
            ctx.Evento.Add(Eventonovo);

            ctx.SaveChanges();
        }
        public Evento BuscarPorId(int id)
        {
            return ctx.Evento.FirstOrDefault(te => te.IdEvento == id);
        }
        public void Deletar(int id)
        {
            ctx.Evento.Remove(BuscarPorId(id));

            ctx.SaveChanges();
        }

        public void Atualizar(int id, Evento EventoAtualizado)
        {
            Evento EventoBuscado = ctx.Evento.Find(id);

            EventoBuscado.IdEvento = EventoAtualizado.IdEvento;

            ctx.Evento.Update(EventoBuscado);

            ctx.SaveChanges();
        }
        
    }
}
