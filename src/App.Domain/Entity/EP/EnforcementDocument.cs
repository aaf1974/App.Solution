using App.Domain.Abstraction.Models;
using App.Domain.Entity.Dictionaries.PretensionWork;
using App.Domain.Entity.JW;
using System;

namespace App.Domain.Entity.EP
{
    /// <summary>
    /// Исполнительный документ
    /// </summary>
    public class EnforcementDocument : IIdentityEntity
    {
        public int Id { get; set; }

        /// <summary>
        /// Дата исполнительного документа
        /// </summary>
        public DateTime ExecutiveDocumentData { get; set; }

        /// <summary>
        /// Номер исполнительного документа
        /// </summary>
        public string ExecutiveDocumentNumber { get; set; }

        /// <summary>
        /// Дата получения исполнительного документа
        /// </summary>
        public DateTime? ExecutiveDocumentRecevingDate { get; set; }

        /// <summary>
        /// Вид исполнительного документа
        /// </summary>
        public ExecutiveDocumentTypeEnum ExecutiveDocumentTypeId { get; set; }

        /// <summary>
        /// Судебная работа
        /// </summary>
        public int JudicialWorkId { get; set; }

        #region Navigation Properies

        public virtual JudicialWork JudicialWork { get; set; }
        #endregion

        #region Implementation of IIdentityEntity

        public bool IsDeleted { get; set; }

        public int WorkerChangedBy { get; set; }

        public DateTime ChangeDate { get; set; }

        #endregion
    }
}
