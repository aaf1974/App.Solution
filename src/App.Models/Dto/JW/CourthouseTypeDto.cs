using App.Models.Command.Base;

namespace App.Models.Dto.JW
{
    /// <summary>
    /// Вид суда
    /// </summary>
    public class CourthouseTypeDto : BaseItemDto
    {
        /// <summary>
        /// Наименование типа
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Код типа
        /// </summary>
        public string Code { get; set; }
    }
}
