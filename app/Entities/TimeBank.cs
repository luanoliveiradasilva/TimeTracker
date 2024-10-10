using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace app.Entities;

[Table("timebank")]
public class TimeBank
{
    
    [Key]
    [Column("timebankId")]
    public int TimebankId { get; set; }
    
    [Column("dateTimeBank")]
    public string TimeData { get; set; }
    
    [Column("startTimebank")]
    public string StartTime { get; set; }
    
    [Column("break")]
    public string BreakTime { get; set; }
    
    [Column("clockin")]
    public string Clockin { get; set; }
    
    [Column("clockout")]
    public string Clockout { get; set; }
    
    [Column("description")]
    public string Description { get; set; }
    
}