using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EventManager.Models
{
  
    [MetadataType(typeof(EventMetadata))]
    public partial class Event
    {

    }

    public class EventMetadata
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide name")]
        public string Name { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide location")]
        public string Location { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide start date")]
        public string StartDate { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide time")]
        public string StartDateTime { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide end date")]
        public string EndDate { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide time")]
        public string EndDateTime { get; set; }
    }



}