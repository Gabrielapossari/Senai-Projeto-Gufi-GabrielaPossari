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
    public class PresencaController : ControllerBase
    {
        private IPresencaRepository _presencarepository;

        public PresencaController()
        {
            _presencarepository = new PresencaRepository();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return StatusCode(200, _presencarepository.BuscarPorId(id));
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_presencarepository.Listar());
        }
        [HttpPost]
        public IActionResult Post(Presenca Presencaonova)
        {
            _presencarepository.Cadastrar(Presencaonova);
            return StatusCode(201);
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, Presenca PresencaAtualizada)
        {
            Presenca PresencaBuscada = _presencarepository.BuscarPorId(id);

            if (PresencaBuscada != null)
            {
                try
                {
                    _presencarepository.Atualizar(id, PresencaAtualizada);

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
            Presenca PreseencaBuscado = _presencarepository.BuscarPorId(id);

            if (PreseencaBuscado == null)
            {
                return NotFound();
            }

            _presencarepository.Deletar(id);

            return StatusCode(202);




        }
    }
}
    