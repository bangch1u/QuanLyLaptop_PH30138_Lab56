using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace QuanLyLaptop_PH30138.DomainClass;

[Table("Laptop")]
public partial class Laptop
{
    [Key]
    [Column("guidID")]
    public Guid GuidId { get; set; }

    [Column("maLaptop")]
    [StringLength(10)]
    public string? MaLaptop { get; set; }

    [Column("tenLaptop")]
    [StringLength(50)]
    public string? TenLaptop { get; set; }

    [Column("hang")]
    [StringLength(50)]
    public string? Hang { get; set; }

    [Column("noiSanXuat")]
    [StringLength(50)]
    public string? NoiSanXuat { get; set; }

    [Column("giaNiemYet")]
    public double? GiaNiemYet { get; set; }

    [Column("chietKhau")]
    public int? ChietKhau { get; set; }
}
