using PipelineLauncher.Abstractions.PipelineStage.Configurations;
using PipelineLauncher.Demo.Tests.Items;
using PipelineLauncher.Stages;
using System.Collections.Generic;

namespace PipelineLauncher.Demo.Tests.Stages.Single
{
    public class BulkStage_Configuration : BulkStage<Item>
    {
        public override IEnumerable<Item> Execute(IEnumerable<Item> items)
        {
            foreach (var item in items)
            {
                item.Process(GetType());
            }

            return items;
        }

        public override BulkStageConfiguration Configuration 
            => new BulkStageConfiguration 
            {
                BatchItemsCount = 5,
                BatchItemsTimeOut = 1000
            };
    }
}
