using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wedia.Feature.Identity.Models;

namespace Wedia.Feature.Identity.Services
{
  public interface INewsletterService
  {
    NewsletterFormViewModel GetFormViewModel();
    NewsletterFormResponse Register(NewsletterDto email);
  }
}
