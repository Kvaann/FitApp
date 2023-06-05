using System;

namespace FitApp.Models
{
    public class BaseModel
    {
        public string? Title { get; set; }
        public string? Notes { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModificationDate { get; set; }
        public bool IsActive { get; set; }
    }
}
