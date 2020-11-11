using System;
using System.Collections.Generic;
using System.Text;

namespace App.Models.Configuration
{
    /// <summary>
    /// Настройки логирования
    /// </summary>
    public class LoggingConfig
    {
        /// <summary>
        /// Путь к файлу логов Serilog
        /// </summary>
        public string SerilogLogFile { get; set; }
    }
}
