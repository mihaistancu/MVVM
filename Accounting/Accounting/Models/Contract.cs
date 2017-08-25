namespace Accounting.Models
{
    public class Contract
    {
        public string Number { get; set; }
        public Provider Provider { get; set; }
        public Buyer Buyer { get; set; }
    }
}
