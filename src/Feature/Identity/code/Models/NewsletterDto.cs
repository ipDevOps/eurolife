using System.ComponentModel.DataAnnotations;
using createsend_dotnet;

namespace Wedia.Feature.Identity.Models
{
  public class NewsletterDto
  {
    [Required]
    [EmailAddress]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }
    [Required]
    [EnumDataType(typeof(ConsentToTrack))]
    public ConsentToTrack Consent { get; set; }
  }
}