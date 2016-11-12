using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace statsmachine.Models
{
    public class UserViewModel
    {
        public string Id { get; set;  }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string avatar { get; set; }
        public string iconpath { get; set; }
        public string username { get; set; }
        public List<string> roles { get; set; }
    }
}