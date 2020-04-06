using System;

namespace App.Database
{
    interface ITimeStamped
    {
        DateTime CreatedAt { get; set; }

        DateTime UpdatedAt { get; set; }
    }
}
