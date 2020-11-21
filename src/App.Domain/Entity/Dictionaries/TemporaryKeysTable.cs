using System;
using System.ComponentModel.DataAnnotations;

namespace App.Domain.Entity.Dictionaries
{
    public class TemporaryKeysTable
    {
        public int Id { get; set; }

        public Guid SessionKey { get; set; }

        public int? ForeignId { get; set; }

        public Guid? ForeignGuid { get; set; }

        [MaxLength(25)]
        public string Number { get; set; }

        public TemporaryKeysTable() { }

        public TemporaryKeysTable(int id, Guid sessionKey)
        {
            SessionKey = sessionKey;
            ForeignId = id;
        }

        public TemporaryKeysTable(string number, Guid sessionKey)
        {
            SessionKey = sessionKey;
            Number = number;
        }

        public TemporaryKeysTable(Guid? foreignGuid, Guid sessionKey)
        {
            SessionKey = sessionKey;
            ForeignGuid = foreignGuid;
        }
    }
}
