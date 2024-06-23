namespace ReportMicroservice.API.Events
{
    public class ReportRequestedEvent
    {
        public string SerialNo { get; set; }
        public string ReportId { get; set; }
    }
}
