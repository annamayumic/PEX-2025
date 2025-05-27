namespace KanbanApi.Models
{
    public class TaskModel
    {
        public int Id { get; set; }
        public string ClientName { get; set; }
        public string ServiceName { get; set; }
        public DateTime Date { get; set; }
        public decimal Price { get; set; }
        public string Billing { get; set; }
        public string Status { get; set; }
    }
}
