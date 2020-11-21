using App.Domain.Abstraction.Models;
using App.Domain.Entity.Dictionaries.PretensionWork;
using App.Domain.Entity.EP;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace App.Domain.Entity.JW
{
    /// <summary>
    /// Судебная работа
    /// </summary>
    public class JudicialWork : IIdentityEntity
    {
        public int Id { get; set; }

        #region Обращение в суд

        public JudicalWorkTypeEnum JudicalWorkTypeId { get; set; }

        /// <summary>
        /// Суд
        /// </summary>
        public int CourthouseId { get; set; }

        /// <summary>
        /// дата отправления
        /// </summary>
        public DateTime DepartureDate { get; set; }

        /// <summary>
        /// Период пени
        /// </summary>
        public DateTime? IndebtednessBeginFinePeriod { get; set; }

        public DateTime? IndebtednessEndFinePeriod { get; set; }

        /// <summary>
        /// Сумма задолженности
        /// </summary>
        [DefaultValue(0)]
        public decimal IndebtednessSum { get; set; }

        /// <summary>
        /// Пеня по задолженности
        /// </summary>
        [DefaultValue(0)]
        public decimal IndebtednessFine { get; set; }

        /// <summary>
        /// Гос пошлина по задолженности
        /// </summary>
        [DefaultValue(0)]
        public decimal IndebtednessStateDuty { get; set; }

        #endregion

        #region Решение

        /// <summary>
        /// Дата вынесения решения
        /// </summary>
        public DateTime? DecisionDate { get; set; }

        public JudicalDecisionTypeEnum? JudicalDecisionTypeId { get; set; }

        /// <summary>
        /// Взысканая сумма
        /// </summary>
        [DefaultValue(0)]
        public decimal CollectedSum { get; set; }

        /// <summary>
        /// Взысканая сумма пени
        /// </summary>
        [DefaultValue(0)]
        public decimal CollectedFine { get; set; }

        /// <summary>
        /// Взысканая гос пошлина
        /// </summary>
        [DefaultValue(0)]
        public decimal CollectedStateDuty { get; set; }



        #endregion


        /// <summary>
        /// Дата возврата из налоговой
        /// </summary>
        public DateTime? TaxReturnDate { get; set; }

        /// <summary>
        /// Сумма из налоговой
        /// </summary>
        [DefaultValue(0)]
        public decimal TaxSum { get; set; }

        /// <summary>
        /// Возврат из госбюджета
        /// </summary>
        [DefaultValue(0)]
        public decimal StateBudgetReturnedSum { get; set; }

        /// <summary>
        /// добровольное возмещение суммы задолженности
        /// </summary>
        public decimal VoluntaryPaymentSum { get; set; }

        /// <summary>
        /// Добровольное возмещение Пени
        /// </summary>
        public decimal VoluntaryPaymentFine { get; set; }

        /// <summary>
        /// добровольное возмещение гос пошлины
        /// </summary>
        public decimal VoluntaryPaymentStateDuty { get; set; }

        #region Поля для формирования искового заявления/ заявления на выдачу судебного приказа
        /// <summary>
        /// Государственная пошлина за подачу заявления на выдачу судебного приказа
        /// </summary>
        public decimal CourtOrderStateDuty { get; set; }
        #endregion

        /// <summary>
        /// Дата отмены
        /// </summary>
        public DateTime? CancellationDate { get; set; }

        /// <summary>
        /// Исполнитель
        /// </summary>
        public int PhysicalPersonId { get; set; }

        /// <summary>
        /// Номер дела
        /// </summary>
        [MaxLength(20)]
        public string CaseNumber { get; set; }

        public JudicalWorkExclusionReasonEnum? JudicalWorkExclusionReasonId { get; set; }

        /// <summary>
        /// Порядковый номер дела
        /// </summary>
        [MaxLength(20)]
        public string SerialCaseNumber { get; set; }

        /// <summary>
        /// Период задолженности (начало)
        /// </summary>
        public DateTime IndebtednessBeginDate { get; set; }

        /// <summary>
        /// Период задолженности (окончание)
        /// </summary>
        public DateTime IndebtednessEndDate { get; set; }

        public int? RefinancingRateId { get; set; }

        public int? OwnerLegalEntityId { get; set; }

        public int? OwnerPhysicalPersonId { get; set; }


        #region Navigation Property

        public virtual Courthouse Courthouse { get; set; }

        public virtual ICollection<JudicialWorkPremiseAccount> JudicialWorkPremiseAccounts { get; set; }

        public virtual ICollection<EnforcementDocument> EnforcementDocuments { get; set; }
        #endregion

        #region Implementation of IIdentityEntity

        public bool IsDeleted { get; set; }

        public int WorkerChangedBy { get; set; }

        public DateTime ChangeDate { get; set; }

        #endregion


        public Guid? OwnerPhysicalPersonBillingId { get; set; }
    }
}
