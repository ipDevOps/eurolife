using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wedia.Feature.Identity.Models
{
  public class NewsletterFormViewModel
  {
    public string TexboxLabel { get; set; }
    public string FormUrl { get; set; }
    public string ButtonLabel { get; set; }
    public string CheckboxLabel { get; set; }
    public string EmailError { get; set; }
    public string SuccessSubscribed { get; set; }
  }
}