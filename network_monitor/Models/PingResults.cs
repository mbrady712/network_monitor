using System.ComponentModel.DataAnnotations;

namespace network_monitor.Models
{
    public class PingResults
    {
        [Required(ErrorMessage = "The address field is required.")]
        [RegularExpression(@"^(?:(?:[a-zA-Z0-9-]+\.)+[a-zA-Z]{2,}|(?:\d{1,3}\.){3}\d{1,3})$", ErrorMessage = "Invalid IP address or hostname.")]
        public string Address { get; set; }
        public long RoundTripTime { get; set; }
        public string Status { get; set; }
    }
}