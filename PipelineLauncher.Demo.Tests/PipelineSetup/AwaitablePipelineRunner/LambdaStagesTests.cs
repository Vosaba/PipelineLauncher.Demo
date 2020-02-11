using System.Collections.Generic;
using System.Linq;
using PipelineLauncher.Demo.Tests.Items;
using PipelineLauncher.Demo.Tests.Stages.Bulk;
using PipelineLauncher.Demo.Tests.Stages.Single;
using Xunit;
using Xunit.Abstractions;

namespace PipelineLauncher.Demo.Tests.PipelineSetup.AwaitablePipelineRunner
{
    public class LambdaStagesTests : PipelineTestBase
    {
        public LambdaStagesTests(ITestOutputHelper output) : base(output) { }

        [Fact]
        public void Multiple_Mixed_Stages()
        {
            // Test input 6 items
            List<Item> items = MakeItemsInput(6);

            // Configure stages
            var pipelineSetup = PipelineCreator
                .Stage(new Stage())
                .BulkStage(new BulkStage_1())
                .Stage(new Stage_2())
                .BulkStage(new BulkStage_3());

            // Make pipeline from stageSetup
            var pipelineRunner = pipelineSetup.CreateAwaitable();

            // Process items and print result
            (this, pipelineRunner).ProcessAndPrintResults(items);
        }
    }
}
