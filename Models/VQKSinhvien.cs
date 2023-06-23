using System.ComponentModel.DataAnnotations;
namespace VuQuangKhai0323.Models;
public class VQKSinhvien 
{
    [Key]
    public string VQKMasinhvien {get;set;}
    public string VQKHoten{get;set;}
    public string VQKMalop {get;set;}
}