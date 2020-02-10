using PipelineLauncher.Demo.Tests.Items;
using PipelineLauncher.Demo.Tests.Stages.Single;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace PipelineLauncher.Demo.Tests.Tests
{
    public class PipelineRunnerTests : PipelineTestBase
    {
        public PipelineRunnerTests(ITestOutputHelper output) : base(output) { }

        [Fact]
        public void Single_Stage()
        {
            // Test input 6 items
            List<Item> items = MakeItemsInput(6);

            // Configure stages
            var pipelineSetup = PipelineCreator
                    .Stage(new Stage());

            // Make pipeline from stageSetup
            var pipelineRunner = pipelineSetup.CreateAwaitable();

            // Start timer
            StartTimer();

            // Process items
            var result = pipelineRunner.Process(items).ToArray();

            // Print elapsed time and result
            StopTimerAndPrintResult(result);
        }

        [Fact]
        public void Multiple_Stages()
        {
            // Test input 6 items
            List<Item> items = MakeItemsInput(6);

            // Configure stages
            var pipelineSetup = PipelineCreator
                    .Stage(new Stage())
                    .Stage(new Stage_1())
                    .Stage(new Stage_2())
                    .Stage(new Stage_3());

            // Make pipeline from stageSetup
            var pipelineRunner = pipelineSetup.CreateAwaitable();

            // Process items and print result
            pipelineRunner.ProcessAndPrintResults(items, this);
        }

    }
}
