using System.Collections.Generic;
using PipelineLauncher.Demo.Tests.Items;
using PipelineLauncher.Stages;

namespace PipelineLauncher.Demo.Tests.Stages.Bulk
{
    public class BulkStage : BulkStage<Item>
    {
        public override IEnumerable<Item> Execute(Item[] items)
        {
            foreach (var item in items)
            {
                item.Process(GetType());

                yield return item;
            }
        }
    }

    public class BulkStage_1 : BulkStage
    {
    }

    public class BulkStage_2 : BulkStage
    {
    }

    public class BulkStage_3 : BulkStage
    {
    }

    public class BulkStage_4 : BulkStage
    {
    }

    public class BulkStage_5 : BulkStage
    {
    }

    public class BulkStage_6 : BulkStage
    {
    }

    public class BulkStage_7 : BulkStage
    {
    }

    public class BulkStage_8 : BulkStage
    {
    }
}
