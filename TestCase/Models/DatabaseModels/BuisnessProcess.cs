using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TestCase.Models.DatabaseModels;

/// <summary>
/// Модель Базы данных для таблицы BuisnessProcess
/// </summary>
[Table("BuisnessProcess")]
public partial class BuisnessProcess
{
    [Key]
    public int Id { get; set; }

    public int CodeId { get; set; }

    public int ProcessId { get; set; }

    public int OwnerId { get; set; }

    [ForeignKey("CodeId")]
    [InverseProperty("BuisnessProcesses")]
    public virtual CodeProcess Code { get; set; } = null!;

    [ForeignKey("OwnerId")]
    [InverseProperty("BuisnessProcesses")]
    public virtual OwnerProcess Owner { get; set; } = null!;

    [ForeignKey("ProcessId")]
    [InverseProperty("BuisnessProcesses")]
    public virtual Process Process { get; set; } = null!;
}
