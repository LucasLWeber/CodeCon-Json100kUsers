namespace DesafioCodeCon.Dtos.Responses
{
    public class TeamInsightsDto
    {
        public string Nome { get; set; }
        public int TotalMembros { get; set; }
        public int Lideres { get; set; }
        public int ProjetosConcluidos { get; set; }
        public double PctAtivo { get; set; }
    }
}
