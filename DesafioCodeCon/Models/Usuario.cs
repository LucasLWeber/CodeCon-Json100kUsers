using System.Text.Json.Serialization;

namespace DesafioCodeCon.Models
{
    public class Usuario
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("nome")]
        public string Nome { get; set; }

        [JsonPropertyName("idade")]
        public int Idade { get; set; }

        [JsonPropertyName("score")]
        public int Score {  get; set; }

        [JsonPropertyName("pais")]
        public string Pais { get; set; }

        [JsonPropertyName("equipe")]
        public Equipe Equipe { get; set; }

        [JsonPropertyName("logs")]
        public List<Log> Logs { get; set; }
    }
}
