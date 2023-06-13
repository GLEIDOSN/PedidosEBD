namespace Pedidos.Domain.Dtos
{
    public sealed class NovoUsuarioDto
    {
        public string NomeUsuario { get; set; }

        public string Password { get; set; }

        public string RePassword { get; set; }
    }
}
