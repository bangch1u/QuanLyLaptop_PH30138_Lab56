using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace QuanLyLaptop_PH30138.DomainClass;

[Table("Hang")]
public partial class Hang
{
    [Key]
    [Column("maHang")]
    public int MaHang { get; set; }

    [Column("tenHang")]
    [StringLength(50)]
    public string? TenHang { get; set; }
}
