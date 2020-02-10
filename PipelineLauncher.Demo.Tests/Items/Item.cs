using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace PipelineLauncher.Demo.Tests.Items
{
    public class Item
    {
        public List<(int ProcessId, Type StageType)> ProcessedBy { get; }
        public int Index { get; }

        public Item(int index)
        {
            Index = index;
            ProcessedBy = new List<(int ProcessId, Type StageType)>();
        }

        public Item(int index, List<(int ProcessId, Type StageType)> processedBy)
        {
            Index = index;
            ProcessedBy = processedBy;
        }

        public void Process(Type stageType)
        {
            ProcessedBy.Add((Thread.CurrentThread.ManagedThreadId, stageType));
        }

        public override string ToString()
        {
            var values = ProcessedBy.Select(x => $"{x.StageType.Name} : {x.ProcessId}").ToArray();
            return $"{nameof(Item)}#{Index}: '{{{string.Join("} -> {", values)}}}';";
        }
    }
}
