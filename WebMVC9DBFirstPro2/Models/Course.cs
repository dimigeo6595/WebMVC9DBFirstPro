using System;
using System.Collections.Generic;

namespace WebMVC9DBFirstPro2.Models;

public partial class Course
{
    public int Id { get; set; }

    public string Description { get; set; } = null!;

    public int? TeacherId { get; set; }

    public virtual Teacher? Teacher { get; set; }

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
