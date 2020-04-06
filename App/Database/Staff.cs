using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Database
{
    public class Staff : ITimeStamped
    {
        public int StaffId { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(64)]
        public string FirstName { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(64)]
        public string LastName { get; set; }

        public Staff Manager { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public virtual string FullName => $"{FirstName} {LastName}";
    }
}
