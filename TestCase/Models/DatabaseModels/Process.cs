using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TestCase.Models.DatabaseModels;

[Table("Process")]
public partial class Process
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    public string ProcessName { get; set; } = null!;

    [InverseProperty("Process")]
    public virtual ICollection<BuisnessProcess> BuisnessProcesses { get; } = new List<BuisnessProcess>();
}
