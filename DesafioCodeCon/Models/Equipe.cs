using System.Text.Json.Serialization;

namespace DesafioCodeCon.Models
{
    public class Equipe
    {
        [JsonPropertyName("nome")]
        public string Nome { get; set; }

        [JsonPropertyName("lider")]
        public bool Lider { get; set; }

        [JsonPropertyName("projetos")]
        public List<Projeto> Projetos { get; set; }

    }
}
