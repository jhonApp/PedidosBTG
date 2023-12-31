﻿using Microsoft.AspNetCore.Mvc;
using PedidosBTG.API.Models;
using PedidosBTG.Core.Service;
using PedidosBTG.Data.Repository;

namespace PedidosBTG.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        //private readonly IPedidoRepository _pedidoRepository;
        private readonly PedidoService _pedidoService;


        public PedidoController(PedidoService pedidoService)
        {
            //_pedidoRepository = pedidoRepository;
            _pedidoService = pedidoService;
        }

        [HttpGet("valor-total")]
        public ActionResult<List<PedidoInfo>> ObterValorTotal()
        {
            var pedidosComValorTotal = _pedidoService.ObterValorTotalPedido();
            return Ok(pedidosComValorTotal);
        }


        [HttpGet("quantidade-pedidos-por-cliente")]
        public ActionResult<List<PedidoInfo>> ObterQuantidadePedidosPorCliente()
        {
            var quantidadePedidos = _pedidoService.QuantidadePedidos();
            return Ok(quantidadePedidos);
        }

        [HttpGet("pedidos-por-cliente")]
        public ActionResult<List<PedidoInfo>> PedidosPorCliente()
        {
            var pedidosPorCliente = _pedidoService.PedidosPorCliente();
            return Ok(pedidosPorCliente);
        }
    }
}
