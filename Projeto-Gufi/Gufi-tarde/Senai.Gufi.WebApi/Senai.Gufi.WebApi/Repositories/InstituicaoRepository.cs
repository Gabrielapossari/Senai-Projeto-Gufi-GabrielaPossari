using Senai.Gufi.WebApi.Domains;
using Senai.Gufi.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Gufi.WebApi.Repositories
{
    public class InstituicaoRepository : IInstituicaoRepository
    {
        GufiContext ctx = new GufiContext();

        public List<Instituicao> Listar()
        {

            return ctx.Instituicao.ToList();
        }
        public void Cadastrar(Instituicao Instituicaonova)
        {
            ctx.Instituicao.Add(Instituicaonova);

            ctx.SaveChanges();
        }
        public Instituicao BuscarPorId(int id)
        {
            return ctx.Instituicao.FirstOrDefault(te => te.IdInstituicao == id);
        }
        public void Deletar(int id)
        {
            ctx.Instituicao.Remove(BuscarPorId(id));

            ctx.SaveChanges();
        }

        public void Atualizar(int id, Instituicao  InstituicaoAtualizada)
        {
            Instituicao InstituicaoBuscada = ctx.Instituicao.Find(id);

            InstituicaoBuscada.IdInstituicao = InstituicaoAtualizada.IdInstituicao;
            InstituicaoBuscada.Cnpj = InstituicaoAtualizada.Cnpj;
            InstituicaoBuscada.NomeFantasia = InstituicaoAtualizada.NomeFantasia;
            InstituicaoBuscada.Endereco = InstituicaoAtualizada.Endereco;


            ctx.Instituicao.Update(InstituicaoBuscada);

            ctx.SaveChanges();
        }

    }
}
