using System.Text.Json.Serialization;

namespace DesafioCodeCon.Models
{
    public class Projeto
    {
        [JsonPropertyName("nome")]
        public string Nome { get; set; }

        [JsonPropertyName("concluido")]
        public bool Concluido { get; set; }
    }
}
