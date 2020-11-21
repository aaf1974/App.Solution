using App.Domain.Abstraction.Models;
using System;
using System.Collections.Generic;

namespace App.Domain.Entity.JW
{
    public class Courthouse : IIdentityEntity
    {
        public int Id { get; set; }

        public string ShortName { get; set; }

        public string PostAdress { get; set; }

        public int? CourthouseTypeId { get; set; }


        #region Navigation
        
        public virtual CourthouseType CourthouseType { get; set; }

        public ICollection<JudicialWork> JudicalWorks { get; set; } 

        #endregion


        #region Implementation of IIdentityEntity

        public bool IsDeleted { get; set; }

        public int WorkerChangedBy { get; set; }

        public DateTime ChangeDate { get; set; }

        #endregion
    }
}
