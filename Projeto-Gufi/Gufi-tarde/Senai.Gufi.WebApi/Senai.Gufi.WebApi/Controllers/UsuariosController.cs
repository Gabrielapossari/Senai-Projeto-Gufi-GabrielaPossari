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
    public class UsuariosController : ControllerBase
    {
        private IUsuariosRepository _usuariosRepository;

        public UsuariosController()
        {
            _usuariosRepository = new UsuariosRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_usuariosRepository.Listar());
        }
        [HttpPost]
        public IActionResult Post(Usuario Usuarionovo)
        {
            _usuariosRepository.Cadastrar(Usuarionovo);
            return StatusCode(201);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return StatusCode(200, _usuariosRepository.BuscarPorId(id));
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Usuario UsuarioAtualizado)
        {
            Usuario UsuarioBuscado = _usuariosRepository.BuscarPorId(id);

            if (UsuarioBuscado != null)
            {
                try
                {
                    _usuariosRepository.Atualizar(id, UsuarioAtualizado);

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
            Usuario UsuarioBuscado = _usuariosRepository.BuscarPorId(id);

            if (UsuarioBuscado == null)
            {
                return NotFound();
            }

            _usuariosRepository.Deletar(id);

            return StatusCode(202);
        }
    }
 
}