using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TestCase.Models.DatabaseModels;

/// <summary>
/// Модель Базы данных для таблицы CodeProcess
/// </summary>
[Table("CodeProcess")]
public partial class CodeProcess
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [StringLength(50)]
    public string? CodeName { get; set; }

    [InverseProperty("Code")]
    public virtual ICollection<BuisnessProcess> BuisnessProcesses { get; } = new List<BuisnessProcess>();
}
