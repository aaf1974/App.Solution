using App.Domain.Abstraction.Models;
using System;
using System.Collections.Generic;

namespace App.Domain.Entity.EP
{
    /// <summary>
    /// Причины окончаний исполнительного производства
    /// </summary>
    public class EnforcementProceedingReasonEnding : IIdentityEntity
    {
        public int Id { get; set; }

        public string NoteNumber { get; set; }

        public string NoteText { get; set; }

        #region Navigation
        public virtual ICollection<EnforcementProceeding> EnforcementProceedings { get; set; }

        #endregion


        #region Implementation of IIdentityEntity

        public bool IsDeleted { get; set; }

        public int WorkerChangedBy { get; set; }

        public DateTime ChangeDate { get; set; }

        #endregion
    }
}
