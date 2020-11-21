using App.Domain.Abstraction.Models;
using App.Domain.Entity.Dictionaries.PretensionWork;
using System;

namespace App.Domain.Entity.EP
{
    /// <summary>
    /// События в исполнительном производстве
    /// </summary>
    public class EnforcementProceedingEvent : IEnforcementProceedingChildCollection, IIdentityEntity
    {

        public int Id { get; set; }

        public DateTime EventDate { get; set; }

        public int EnforcementProceedingId { get; set; }

        public EnforcementProceedingEventTypeEnum EnforcementProceedingEventTypeId { get; set; }

        #region Navigation 

        public virtual EnforcementProceeding EnforcementProceeding { get; set; }

        #endregion

        #region Implementation of IIdentityEntity

        public bool IsDeleted { get; set; }

        public int WorkerChangedBy { get; set; }

        public DateTime ChangeDate { get; set; }

        #endregion
    }
}
