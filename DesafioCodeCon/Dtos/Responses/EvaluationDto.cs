using System.Net;

namespace DesafioCodeCon.Dtos.Responses
{
    public class EvaluationDto
    {
        public string EndPoint { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public int TimeMs { get; set; }
        public bool ValidResponse { get; set; }
    }
}
