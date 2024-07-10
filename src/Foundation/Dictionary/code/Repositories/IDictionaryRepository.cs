using Wedia.Foundation.Dictionary.Models;
using Sitecore.Sites;

namespace Wedia.Foundation.Dictionary.Repositories
{
  public interface IDictionaryRepository
  {
    Models.Dictionary Get(SiteContext site);
  }
}