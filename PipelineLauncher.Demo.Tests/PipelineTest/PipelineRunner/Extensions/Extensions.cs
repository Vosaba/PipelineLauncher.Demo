using PipelineLauncher.Demo.Tests.Items;
using PipelineLauncher.PipelineSetup;

namespace PipelineLauncher.Demo.Tests.PipelineTest.PipelineRunner.Extensions
{
    public static class Extensions
    {
        public static IPipelineSetupSource<int> GetHashCode(this IPipelineSetupSource<Item> pipelineSetup, int uniqPostfix = 0)
        {
            return pipelineSetup.Stage(x => x.GetHashCode() + uniqPostfix);
        }

        public static IPipelineSetup<TInput, string> GetString<TInput>(this IPipelineSetup<TInput, int> pipelineSetup, string uniqPrefix, string uniqPostfix)
        {
            return pipelineSetup.Stage(x => $"{uniqPrefix}_{x}_{uniqPostfix}");
        }

        public static IPipelineSetup<TInput, TOutput> DoNothing<TInput, TOutput>(this IPipelineSetup<TInput, TOutput> pipelineSetup)
        {
            return pipelineSetup.Stage(x => x);
        }
    }
}
