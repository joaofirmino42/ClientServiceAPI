using System.ComponentModel.DataAnnotations;
namespace ApiClientes.Services.Requests
{
    // <summary>
    /// Modelagem da requisição de cadastro de cliente
    /// </summary>
    public class ClientePostRequest
    {

        [Required(ErrorMessage = "Informe o nome")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Informe o email"),EmailAddress]
        public string Email { get; set; }
    }
}
