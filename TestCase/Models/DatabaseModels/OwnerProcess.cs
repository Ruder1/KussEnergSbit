using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TestCase.Models.DatabaseModels;

/// <summary>
/// Модель Базы данных для таблицы OwnerProcess
/// </summary>
[Table("OwnerProcess")]
public partial class OwnerProcess
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    public string? OwnerName { get; set; }

    [InverseProperty("Owner")]
    public virtual ICollection<BuisnessProcess> BuisnessProcesses { get; } = new List<BuisnessProcess>();
}
