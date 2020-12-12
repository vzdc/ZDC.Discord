using System.ComponentModel.DataAnnotations;

namespace ZDC.Discord.Models
{
    public class ZdcSync
    {
        [Key] 
        public int Id { get; set; }
        public string Teamspeak { get; set; }
        public string Discord { get; set; }
    }
}