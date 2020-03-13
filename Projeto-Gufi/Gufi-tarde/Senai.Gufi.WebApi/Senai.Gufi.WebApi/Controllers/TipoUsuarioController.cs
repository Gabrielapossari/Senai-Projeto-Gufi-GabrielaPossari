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
    public class TipoUsuarioController : ControllerBase
    {
        private ITipoUsuarioRepository _tipousuarioRepository;

        public TipoUsuarioController()
        {
            _tipousuarioRepository = new TipoUsuarioRepository();
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return StatusCode(200, _tipousuarioRepository.BuscarPorId(id));
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_tipousuarioRepository.Listar());
        }
        [HttpPost]
        public IActionResult Post(TipoUsuario TipoUsuarionovo)
        {
            _tipousuarioRepository.Cadastrar(TipoUsuarionovo);
            return StatusCode(201);
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, TipoUsuario UsuarioTipoAtualizado)
        {
            TipoUsuario UsuarioTipoBuscado = _tipousuarioRepository.BuscarPorId(id);

            if (UsuarioTipoBuscado != null)
            {
                try
                {
                    _tipousuarioRepository.Atualizar(id, UsuarioTipoAtualizado);

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
            TipoUsuario UsuarioTipoBuscado = _tipousuarioRepository.BuscarPorId(id);

            if (UsuarioTipoBuscado == null)
            {
                return NotFound();
            }

            _tipousuarioRepository.Deletar(id);

            return StatusCode(202);
        }
    }
}