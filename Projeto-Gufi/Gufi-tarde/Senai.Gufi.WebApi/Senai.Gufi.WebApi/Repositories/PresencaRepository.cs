using Senai.Gufi.WebApi.Domains;
using Senai.Gufi.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Gufi.WebApi.Repositories
{
    public class PresencaRepository : IPresencaRepository
    {
        GufiContext ctx = new GufiContext();

        public List<Presenca> Listar()
        {

            return ctx.Presenca.ToList();
        }
        public void Cadastrar(Presenca Presencanovo)
        {
            ctx.Presenca.Add(Presencanovo);

            ctx.SaveChanges();
        }
        public Presenca BuscarPorId(int id)
        {
            return ctx.Presenca.FirstOrDefault(te => te.IdPresenca == id);
        }
        public void Deletar(int id)
        {
            ctx.Presenca.Remove(BuscarPorId(id));

            ctx.SaveChanges();
        }

        public void Atualizar(int id, Presenca PresencaAtulizada)
        {
            Presenca PresencaBuscada = ctx.Presenca.Find(id);

            PresencaBuscada.IdPresenca = PresencaAtulizada.IdPresenca;

            PresencaBuscada.Situacao = PresencaAtulizada.Situacao;

            ctx.Presenca.Update(PresencaBuscada);

            ctx.SaveChanges();
        }

    }
}
