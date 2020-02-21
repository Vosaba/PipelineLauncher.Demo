using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PipelineLauncher.Demo.Tests.Extensions;
using PipelineLauncher.Demo.Tests.Items;
using PipelineLauncher.Demo.Tests.Stages.Bulk;
using PipelineLauncher.Demo.Tests.Stages.Single;
using PipelineLauncher.Extensions;
using Xunit;
using Xunit.Abstractions;

namespace PipelineLauncher.Demo.Tests.PipelineTest.PipelineRunner.Extensions
{
    public class ExtensionsStagesTests : PipelineTestBase
    {
        public ExtensionsStagesTests(ITestOutputHelper output) : base(output) { }

        [Fact]
        public void PipelineExtensions_Stages()
        {
            // Test input 6 items
            List<Item> items = MakeItemsInput(6);

            // Configure stages
            var pipelineSetup = PipelineCreator
                .Stage<Stage_1, Item>()
                .BulkStage<BulkStage_1>()
                .DoNothing()
                .Stage(new Stage_3())
                .ExtensionContext(extension => extension.GetHashCode(1995))
                .GetString("19", "95");


            // Make pipeline from stageSetup
            var pipelineRunner = pipelineSetup.CreateAwaitable();

            // Process items and print result
            (this, pipelineRunner).ProcessAndPrintResults(items);
        }
    }
}
