using App.Domain.Abstraction.Models;
using App.Domain.Entity.Dictionaries.PretensionWork;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace App.Domain.Entity.EP
{

    /// <summary>
    /// Исполнительное производство
    /// </summary>
    public class EnforcementProceeding : IIdentityEntity
    {
        public int Id { get; set; }

        #region Исполнительное производство
        /// <summary>
        /// Дата направления приставам
        /// </summary>
        public DateTime SendingDate { get; set; }

        /// <summary>
        /// Служба судебных приставов
        /// </summary>
        public int BailiffServiceId { get; set; }

        /// <summary>
        /// Дата возбуждения исполнительного производства
        /// </summary>
        public DateTime? EnforcementProceedingExicationDate { get; set; }

        /// <summary>
        /// Дата окончания исполнительного производства
        /// </summary>
        public DateTime? EnforcementProceedingEndDate { get; set; }

        /// <summary>
        /// № исполнительного производства
        /// </summary>
        [MaxLength(20)]
        public string EnforcementProceedingNumber { get; set; }

        /// <summary>
        /// Вид требования
        /// </summary>
        public EnforcementProceedingRequirementTypeEnum EnforcementProceedingRequirementTypeId { get; set; }

        /// <summary>
        /// Сумма задолженности
        /// </summary>
        public decimal IndebtednessSum { get; set; }

        /// <summary>
        /// Сумма пени
        /// </summary>
        public decimal FineSum { get; set; }

        /// <summary>
        /// Сумма Госпошлины
        /// </summary>
        public decimal StateDutySum { get; set; }

        /// <summary>
        /// Причина окончания
        /// </summary>
        public int? EnforcementProceedingReasonEndingId { get; set; }

        /// <summary>
        /// Основание окончания
        /// </summary>
        public string BasisEnding { get; set; }

        #endregion

        public int EnforcementDocumentId { get; set; }



        #region Navigation Properies

        public virtual BailiffService BailiffService { get; set; }

        public virtual EnforcementProceedingReasonEnding EnforcementProceedingReasonEnding { get; set; }

        public virtual EnforcementDocument EnforcementDocument { get; set; }

        public virtual ICollection<EnforcementProceedingBailiffComplain> EnforcementProceedingBailiffComplains { get; set; }

        public virtual ICollection<EnforcementProceedingEvent> EnforcementProceedingEvents { get; set; }

        public virtual ICollection<EnforcementProceedingPenalties> EnforcementProceedingPenalties { get; set; }

        #endregion


        #region Implementation of IIdentityEntity

        public bool IsDeleted { get; set; }

        public int WorkerChangedBy { get; set; }

        public DateTime ChangeDate { get; set; }

        #endregion
    }
}
