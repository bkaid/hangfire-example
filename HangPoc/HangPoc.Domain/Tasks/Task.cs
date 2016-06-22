using System;
using System.ComponentModel.DataAnnotations;

namespace HangPoc.Domain.Tasks {

    public class Task {

        [Key]
        public Guid Id { get; set; }

        public DateTime CreatedUtc { get; set; }

        public DateTime ExpiresAtUtc { get; set; }

        public bool IsExpired { get; set; }
    }
}