using ApiClientes.Infra.Data.Entities;
using ApiClientes.Infra.Data.Interfaces;
using ApiClientes.Services.Requests;
//using ApiClientes.Services.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiClientes.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidosController : ControllerBase
    {
        //atributo
        private readonly IUnitOfWork _unitOfWork;
        public PedidosController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpPost]
        public IActionResult SalvarPedido(PedidoPostRequest request)
        {
            try
            {
                // pesquisando o cliente atraves do id..
                 var cliente = _unitOfWork.ClienteRepository.ObterPorId(request.IdCliente);
                //verificando se o cliente não foi encontrado
                if (cliente == null)
                    //HTTP 422 -> UNPROCESSABLE ENTITY
                    return StatusCode(422, new
                    {
                        message = "Cliente não encontrado, verifique o ID informado."
                    });
             
                var pedido = new Pedido
                {
                    IdCliente=request.IdCliente,
                    DataCriacao=DateTime.Now,
                    NumeroPedido=request.NumeroPedido,
                    
                };
                //gravar no banco de dados
                 _unitOfWork.PedidoRepository.Inserir(pedido);
                var id = pedido.IdPedido;
                var ItemPedido = new ItemPedido
                {
                    Nome = request.Nome,
                    Valor = request.Valor,
                    IdPedido =id

                };
                //gravar no banco de dados
                _unitOfWork.ItemPedidoRepository.Inserir(ItemPedido);
                //HTTP 201 -> SUCCESS CREATED
                return StatusCode(201, "Pedido salvo com sucesso!");
            }
            catch (Exception e)
            {

                //retornando status e mensagem de erro
                //HTTP 500 -> ERRO INTERNO DE SERVIDOR
                return StatusCode(500, e.Message);
            }
        }
        [HttpGet]
        public IActionResult listarPedidos()
        {
            try
            {

                //listando os pedidos
                var pedidos = _unitOfWork.PedidoRepository.Consultar();
                //HTTP 201 -> SUCCESS CREATED
                return StatusCode(201, pedidos);

            }
            catch (Exception e)
            {

                //retornando status e mensagem de erro
                //HTTP 500 -> ERRO INTERNO DE SERVIDOR
                return StatusCode(500, e.Message);
            }
        }
        
        [HttpGet("{idPedido}")]
        public IActionResult ConsultarPorId(int idPedido)
        {
            try
            {
                
                //pesquisandoo pedido atraves do id..
                var pedido = _unitOfWork.PedidoRepository
               .ObterPorId(
                    idPedido);
                //verificando se o pedido não foi encontrado
                if (pedido == null)
                    //HTTP 422 -> UNPROCESSABLE ENTITY
                    return StatusCode(422, new
                    {
                        message = "pedido não encontrado, verifique o ID informado."
                    });


                return StatusCode(200, pedido);

            }
            catch (Exception e)
            {

                //retornando status e mensagem de erro
                //HTTP 500 -> ERRO INTERNO DE SERVIDOR
                return StatusCode(500, e.Message);

            }
        }
        [HttpDelete("{idPedido}")]
        public IActionResult DeletarPedido(int idPedido)
        {
            try
            {
                //listado os itens do pedido
                var listaItemPedido = _unitOfWork.ItemPedidoRepository
              .ListarItemPedidoPorIdPedido(
                   idPedido);
                foreach (var item in listaItemPedido)
                {
                    _unitOfWork.ItemPedidoRepository.Excluir(item);
                }
                //pesquisando o pedido atraves do id..
                var pedido = _unitOfWork.PedidoRepository
               .ObterPorId(
                    idPedido);
                //verificando se o pedido não foi encontrado
                if (pedido == null)
                    //HTTP 422 -> UNPROCESSABLE ENTITY
                    return StatusCode(422, new
                    {
                        message = "Pedido não encontrado, verifique o ID informado."
                    });
                //excluindo
                _unitOfWork.PedidoRepository.Excluir(pedido);

                return StatusCode(200, "Excluido com sucesso!");

            }
            catch (Exception e)
            {

                //retornando status e mensagem de erro
                //HTTP 500 -> ERRO INTERNO DE SERVIDOR
                return StatusCode(500, e.Message);

            }
        }

    }
}
