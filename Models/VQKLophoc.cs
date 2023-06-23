using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace VuQuangKhai0323.Models;
public class VQKLophoc 
{
    [Key]

    public string VQKTenlop {get;set;}
    
    public string VQKMalop {get; set;}
    [ForeignKey("VQKMalop")]
    public VQKSinhvien? VQKSinhvien {get;set;}

}