namespace App.Models.Command.Base
{
    /// <summary>
    /// Базовый класс комманд на получение списка элементов
    /// </summary>
    public class BaseGetListCommand
    {
        /// <summary>
        ///Число(порядковый номер), с которого нужно брать элементы
        /// </summary>
        public int From { get; set; }

        /// <summary>
        /// Число(порядковый номер), по который нужно брать элементы
        /// </summary>
        public int To { get; set; }
    }
}
