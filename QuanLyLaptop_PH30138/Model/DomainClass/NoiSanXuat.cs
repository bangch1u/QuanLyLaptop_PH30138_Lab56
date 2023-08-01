using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace QuanLyLaptop_PH30138.DomainClass;

[Table("NoiSanXuat")]
public partial class NoiSanXuat
{
    [Key]
    [Column("maNSX")]
    public int MaNsx { get; set; }

    [Column("tenNSX")]
    [StringLength(50)]
    public string? TenNsx { get; set; }
}
