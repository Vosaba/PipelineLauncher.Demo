using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using PipelineLauncher.Demo.Tests.Items;
using Xunit.Abstractions;

namespace PipelineLauncher.Demo.Tests.PipelineSetup
{
    public abstract class PipelineTestBase
    {
        private const string Separator = "--------------------";
        private readonly ITestOutputHelper _output;
        private readonly Stopwatch _stopWatch = new Stopwatch();

        protected virtual IPipelineCreator PipelineCreator { get; } = new PipelineCreator();

        protected PipelineTestBase(ITestOutputHelper output)
        {
            _output = output;
        }

        protected List<Item> MakeItemsInput(int count)
            => MakeInput(count, index => new Item(index));

        protected List<int> MakeNumbersInput(int count)
        => MakeInput(count, index => index);

        protected List<TInput> MakeInput<TInput>(int count, Func<int, TInput> itemInitializer)
        {
            var input = new List<TInput>();

            for (int i = 0; i < count; i++)
            {
                input.Add(itemInitializer(i));
            }

            return input;
        }
        
        public void StartTimer()
        {
            _stopWatch.Reset();
            _stopWatch.Start();
        }

        public long StopTimerAndReturnElapsed()
        {
            _stopWatch.Stop();
            return _stopWatch.ElapsedMilliseconds;
        }

        public void StopTimerAndPrintResult(IEnumerable items)
        {
            StopTimerAndPrintElapsedTime();

            foreach (var item in items)
            {
                WriteLine(item);
            }

            WriteSeparator();
        }

        public void PrintProcessed(object item)
        {
            WriteLine(item);
        }

        public void StopTimerAndPrintElapsedTime()
        {
            var elapsedMilliseconds = StopTimerAndReturnElapsed();

            WriteSeparator();
            WriteLine($"Total elapsed milliseconds: {elapsedMilliseconds}");
            WriteSeparator();
        }

        private void WriteSeparator() => WriteLine(Separator);
        private void WriteLine(object value) => WriteLine(value.ToString());
        private void WriteLine(string value) => _output.WriteLine(value);
    }
}
