using PipelineLauncher.Abstractions.PipelineRunner;
using PipelineLauncher.Demo.Tests.Tests;
using System.Collections.Generic;
using System.Linq;

namespace PipelineLauncher.Demo.Tests
{
    public static class PipelineTestExtensions
    {
        public static void ProcessAndPrintResults<TInput, TOutput>(
            this IAwaitablePipelineRunner<TInput, TOutput> pipelineRunner,
            IEnumerable<TInput> items,
            PipelineTestBase pipelineTest)
        {
            // Start timer
            pipelineTest.StartTimer();

            // Process items
            var result = pipelineRunner.Process(items).ToArray();

            // Print elapsed time and result
            pipelineTest.StopTimerAndPrintResult(result);
        }
    }
}
