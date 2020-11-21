using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.Abstraction.Models
{
    public interface IIsDeletedSupport
    {
        bool IsDeleted { get; set; }
    }
}
