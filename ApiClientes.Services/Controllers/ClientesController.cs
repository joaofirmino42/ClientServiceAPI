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
    public class ClientesController : ControllerBase
    {
        //atributo
        private readonly IUnitOfWork _unitOfWork;
        public ClientesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpPost]
        public IActionResult SalvarCliente(ClientePostRequest request)
        {
            try
            {
                //verificar se o Email informado já está cadastrado..
                if (_unitOfWork.ClienteRepository.ObterClientePorEmail
               (request.Email) != null)
                    //HTTP 422 -> UNPROCESSABLE ENTITY
                    return StatusCode(422,
                   new
                   {
                       message = "O E-mail informado já está cadastrado."
                   });

                Cliente cliente = new Cliente
                {
                    Email = request.Email,
                    Nome = request.Nome,

                };
                //gravar no banco de dados
                _unitOfWork.ClienteRepository.Inserir(cliente);
                //HTTP 201 -> SUCCESS CREATED
                return StatusCode(201, "Criado com sucesso!");

            }
            catch (Exception e)
            {

                //retornando status e mensagem de erro
                //HTTP 500 -> ERRO INTERNO DE SERVIDOR
                return StatusCode(500, e.Message);
            }
        }
        [HttpGet]
        public IActionResult listarclientes()
        {
            try
            {

                //listando os clientes
                var clientes = _unitOfWork.ClienteRepository.Consultar();
                
                //HTTP 201 -> SUCCESS CREATED
                return StatusCode(201, clientes);

            }
            catch (Exception e)
            {

                //retornando status e mensagem de erro
                //HTTP 500 -> ERRO INTERNO DE SERVIDOR
                return StatusCode(500, e.Message);
            }
        }
        [HttpDelete("{idCliente}")]
        public IActionResult DeletarCliente(int idCliente)
        {
            try
            {
                //pesquisando o cliente atraves do id..
                var cliente = _unitOfWork.ClienteRepository
               .ObterPorId(
                    idCliente);
                //verificando se o cliente não foi encontrado
                if (cliente == null)
                    //HTTP 422 -> UNPROCESSABLE ENTITY
                    return StatusCode(422, new
                    {
                        message = "Cliente não encontrado, verifique o ID informado."
                    });
                //excluindo
                _unitOfWork.ClienteRepository.Excluir(cliente);

                return StatusCode(200, "Excluido com sucesso!");

            }
            catch (Exception e)
            {

                //retornando status e mensagem de erro
                //HTTP 500 -> ERRO INTERNO DE SERVIDOR
                return StatusCode(500, e.Message);

            }
        }
        [HttpGet("{idCliente}")]
        public IActionResult ConsultarPorId(int idCliente)
        {
            try
            {
                //pesquisando a empresa atraves do id..
                var cliente = _unitOfWork.ClienteRepository
               .ObterPorId(
                    idCliente);
                //verificando se o cliente não foi encontrado
                if (cliente == null)
                    //HTTP 422 -> UNPROCESSABLE ENTITY
                    return StatusCode(422, new
                    {
                        message = "cliente não encontrado, verifique o ID informado."
                    });
               // cliente.Pedidos = _unitOfWork.PedidoRepository.ListarPedidoPorIdCliente(idCliente);
                return StatusCode(200, cliente);

            }
            catch (Exception e)
            {

                //retornando status e mensagem de erro
                //HTTP 500 -> ERRO INTERNO DE SERVIDOR
                return StatusCode(500, e.Message);

            }
        }
        [HttpPut]
        public IActionResult AtualizarCliente(ClientePutRequest request)
        {
            try
            {
                //pesquisando o cliente atraves do id..
                var cliente = _unitOfWork.ClienteRepository
               .ObterPorId(request.IdCliente);
                //verificando se a empresa não foi encontrada
                if (cliente == null)
                {
                    //HTTP 422 -> UNPROCESSABLE ENTITY
                    return StatusCode(422, new
                    {
                        message = "Cliente não encontrado,verifique o ID informado."
                    });
                }
                //atualizando os dados do Cliente
                cliente.Nome = request.Nome;
                cliente.Email=request.Email;
                _unitOfWork.ClienteRepository.Alterar(cliente);
                return StatusCode(200, "Cliente atualizado com sucesso!");
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
