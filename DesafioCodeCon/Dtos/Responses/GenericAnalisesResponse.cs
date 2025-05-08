namespace DesafioCodeCon.Dtos.Responses
{
    public class GenericAnalisesResponse<T>
    {
        public int ExecutionTimeMs { get; set; }
        public DateTime TimeStamp { get; set; }
        public T Data { get; set; }
    }
}
