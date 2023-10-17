using System.ComponentModel.DataAnnotations;
namespace ApiClientes.Services.Requests
{
    public class PedidoPostRequest
    {
        [Required(ErrorMessage = "Informe o nome do pedido")]
        public string Nome { get; set; }
       

        [Required(ErrorMessage = "Informe o valor do pedido")]
        public decimal Valor { get; set; }
        [Required(ErrorMessage = "Informe o número do pedido")]
        public int NumeroPedido { get; set; }
        [Required(ErrorMessage = "Informe o id do cliente")]
        public int IdCliente { get; set; }
    }
}
