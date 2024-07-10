using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sitecore.Data.Items;
using Wedia.Feature.Glossary.Models;

namespace Wedia.Feature.Glossary.Repositories
{
  public interface IGlossaryRepository
  {
    IEnumerable<GlossaryGroup> GetGroups(Item contextItem);
  }
}
