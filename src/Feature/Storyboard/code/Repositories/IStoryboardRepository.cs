using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sitecore.Data.Items;

namespace Wedia.Feature.Storyboard.Repositories
{
    public interface IStoryboardRepository
    {
        IEnumerable<Item> Get(Item contextItem);
    }
}
