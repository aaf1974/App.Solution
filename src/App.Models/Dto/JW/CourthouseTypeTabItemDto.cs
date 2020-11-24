namespace App.Models.Dto.JW
{
    /// <summary>
    /// Элемент табличного представления видов судов
    /// </summary>
    public class CourthouseTypeTabItemDto
    {
        public int Id { get; set; }

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
