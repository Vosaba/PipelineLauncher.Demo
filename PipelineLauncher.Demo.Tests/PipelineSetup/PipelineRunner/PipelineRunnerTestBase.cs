using PipelineLauncher.Demo.Tests.Items;
using Xunit.Abstractions;

namespace PipelineLauncher.Demo.Tests.PipelineSetup.PipelineRunner
{
    public class PipelineRunnerTestBase: PipelineTestBase
    {
        protected int DefaultLastItemIndex = 5;
        protected int DefaultItemsProcessedCount = 6;

        public PipelineRunnerTestBase(ITestOutputHelper output) : base(output) { }

        protected bool StopExecutionCondtitionByTotalProcessed(ref int totalProcessedCout)
        {
            return ++totalProcessedCout == DefaultItemsProcessedCount;
        }

        protected bool StopExecutionCondtitionByLastIndex<TOuput>(TOuput item) where TOuput : Item
        {
            return item.Index == DefaultLastItemIndex;
        }
    }
}
