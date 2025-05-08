using System.Net;

namespace DesafioCodeCon.Dtos.Responses
{
    public class EvaluationDto
    {
        public HttpStatusCode StatusCode { get; set; }
        public int TimeMs { get; set; }
        public bool ValidResponse { get; set; }
    }
}
