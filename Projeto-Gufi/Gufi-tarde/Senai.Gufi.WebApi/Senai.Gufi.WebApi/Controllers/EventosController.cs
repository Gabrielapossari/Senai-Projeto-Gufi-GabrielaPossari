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
    public class EventosController : ControllerBase
    {
        private IEventosRepository _eventoRepository;

        public EventosController()
        {
            _eventoRepository = new EventosRepository();
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_eventoRepository.Listar());
        }
        [HttpPost]
        public IActionResult Post(Evento Eventonovo)
        {
            _eventoRepository.Cadastrar(Eventonovo);
            return StatusCode(201);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return StatusCode(200, _eventoRepository.BuscarPorId(id));
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Evento EventoAtualizado)
        {
            Evento EventoBuscado = _eventoRepository.BuscarPorId(id);

            if (EventoBuscado != null)
            {
                try
                {
                    _eventoRepository.Atualizar(id,EventoAtualizado);

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
            Evento EventoBuscado = _eventoRepository.BuscarPorId(id);

            if (EventoBuscado == null)
            {
                return NotFound();
            }

            _eventoRepository.Deletar(id);

            return StatusCode(202);
        }


    }
}