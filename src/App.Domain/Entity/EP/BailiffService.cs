using App.Domain.Abstraction.Models;
using System;
using System.Collections.Generic;

namespace App.Domain.Entity.EP
{
    /// <summary>
    /// служба судебных приставов
    /// </summary>
    public class BailiffService : IIdentityEntity
    {
        public int Id { get; set; }

        public string ShortName { get; set; }

        public string Adress { get; set; }

        public virtual ICollection<EnforcementProceeding> EnforcementProceedings { get; set; }


        #region Implementation of IIdentityEntity

        public bool IsDeleted { get; set; }

        public int WorkerChangedBy { get; set; }

        public DateTime ChangeDate { get; set; }

        #endregion
    }
}
