﻿using Application.DTO;
using Application.Services;
using Application.Services.Interfaces;
using Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipeController : BaseApiController
    {
        private readonly IEquipeService _equipeService;

        public EquipeController(IEquipeService equipeService)
        {
            _equipeService = equipeService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<EquipeViewModel>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ListarEquipes()
        {
            var result = await _equipeService.ListarEquipes();

            return ResultadoRetorno(result);
        }

        [Route("{id}")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EquipeViewModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ObterEquipePorId(long id)
        {
            var result = await _equipeService.ObterEquipePorId(id);

            return ResultadoRetorno(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CadastraEquipe(CriarEquipeDTO equipeDto)
        {
            var result = await _equipeService.CriarEquipe(equipeDto);

            return ResultadoRetorno(result);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AtualizaEquipe(AtualizaEquipeDTO equipeDto)
        {
            var result = await _equipeService.AtualizaEquipe(equipeDto);

            return ResultadoRetorno(result);
        }

        [HttpPut("ingressar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> IngressarEquipe(IngressarEquipeDTO ingressoDto)
        {
            var result = await _equipeService.IngressarEquipe(ingressoDto);

            return ResultadoRetorno(result);
        }

        [Route("{id}")]
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeletarEquipe(long id)
        {
            var result = await _equipeService.DeletarEquipe(id);

            return ResultadoRetorno(result);
        }
    }
}
