using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BLL.DTO
{
    public class VoteDTO
    {
        public int Id { get; set; }
        [Required]
        public string VoteDescription { get; set; }
        [Required]
        public int Percentage { get; set; }
        [Required]
        public int VoteChoose { get; set; }
        [Required]
        public int VoteStatus { get; set; }
    }
}
