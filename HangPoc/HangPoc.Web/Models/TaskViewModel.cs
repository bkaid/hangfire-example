using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HangPoc.Web.Models {

    public class TaskViewModel {

        public Guid Id { get; set; }

        public DateTime CreatedUtc { get; set; }

        public DateTime ExpiresAtUtc { get; set; }

        public bool IsExpired { get; set; }
    }
}