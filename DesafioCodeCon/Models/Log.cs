using System.Text.Json.Serialization;

namespace DesafioCodeCon.Models
{
    public class Log
    {
        [JsonPropertyName("data")]
        public DateTime Data {  get; set; }

        [JsonPropertyName("acao")]
        public string Acao { get; set; }
    }
}
