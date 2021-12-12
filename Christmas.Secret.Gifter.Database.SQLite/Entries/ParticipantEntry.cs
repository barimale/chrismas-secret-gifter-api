﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Christmas.Secret.Gifter.Database.SQLite.Entries
{
    public class ParticipantEntry
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public int OrderId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public IEnumerable<int> ExcludedOrderIds { get; set; }

        public int ParentId { get; set; }
        public EventEntry Parent { get; set; }
    }
}
