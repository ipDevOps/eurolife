using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wedia.Feature.Language.Repositories
{
  using Wedia.Feature.Language.Models;

  public interface ILanguageRepository
  {
    Language GetActive();
    IEnumerable<Language> GetSupportedLanguages();
  }
}
