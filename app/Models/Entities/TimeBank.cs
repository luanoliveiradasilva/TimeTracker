using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace app.Models.Datas;

[Table("timebank")]
public class TimeBank
{
    
    [Key]
    [Column("Id")]
    public int TimebankId { get; set; }
    
    [Column("Data")]
    public string TimeData { get; set; }
    
    [Column("start")]
    public string StartTime { get; set; }
    
    [Column("break")]
    public string BreakTime { get; set; }
    
    [Column("clockin")]
    public string Clockin { get; set; }
    
    [Column("clockout")]
    public string Clockout { get; set; }
    
}