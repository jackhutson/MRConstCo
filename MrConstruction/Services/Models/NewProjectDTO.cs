using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MrConstruction.Services.Models {
    public class NewProjectDTO {
        public string Title { get; set; }
        public string Description { get; set; }
        public ClientDTO Client { get; set; }
        public decimal Budget { get; set; }
        public DateTime EstStart { get; set; }
        public DateTime EstCompleted { get; set; }
    }
}