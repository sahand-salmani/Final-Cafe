using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Infrastructure.Partners.ViewModels
{
    public class GetPartnersVm
    {
        public int Id { get; set; }
        [Required, MaxLength(255)]
        public string Name { get; set; }
        [MaxLength(2080)]
        public string Note { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }
        [DataType(DataType.Date)]
        public DateTime StartsAt { get; set; }
        [DataType(DataType.Date)]
        public DateTime EndsAt { get; set; }
    }
}
