using System.Collections.Generic;
using System.Linq;
using System.Threading;
using PipelineLauncher.Demo.Tests.Items;
using PipelineLauncher.Stages;

namespace PipelineLauncher.Demo.Tests.Stages.Single
{
    public class BulkStage_Item_To_Object : BulkStage<Item, object>
    {
        public override IEnumerable<object> Execute(IEnumerable<Item> items)
        {
            foreach (var item in items)
            {
                item.Process(GetType());
            }

            return items.Cast<object>();
        }
    }
}
