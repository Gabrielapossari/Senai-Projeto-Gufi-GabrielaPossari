using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Gufi.WebApi.Domains;
using Senai.Gufi.WebApi.Interfaces;
using Senai.Gufi.WebApi.Repositories;

namespace Senai.Gufi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstituicaoController : ControllerBase
    {
        private IInstituicaoRepository _instituicaoRepository;

        public InstituicaoController()
        {
            _instituicaoRepository = new InstituicaoRepository();
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_instituicaoRepository.Listar());
        }
        [HttpPost]
        public IActionResult Post(Instituicao Instituicaonova)
        {
            _instituicaoRepository.Cadastrar(Instituicaonova);
            return StatusCode(201);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return StatusCode(200, _instituicaoRepository.BuscarPorId(id));
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id,Instituicao InstituicaoAtualizada)
        {
           Instituicao InstituicaoBuscada = _instituicaoRepository.BuscarPorId(id);

            if (InstituicaoBuscada != null)
            {
                try
                {
                    _instituicaoRepository.Atualizar(id, InstituicaoAtualizada);

                    return StatusCode(200);
                }
                catch (Exception erro)
                {
                    return BadRequest(erro);
                }
            }

            return StatusCode(404);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Instituicao InstituicaoBuscada = _instituicaoRepository.BuscarPorId(id);

            if (InstituicaoBuscada == null)
            {
                return NotFound();
            }

            _instituicaoRepository.Deletar(id);

            return StatusCode(202);
        }
    }
}