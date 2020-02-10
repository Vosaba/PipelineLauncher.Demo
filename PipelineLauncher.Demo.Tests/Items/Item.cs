using System.Collections.Generic;
using System.Linq;

namespace PipelineLauncher.Demo.Tests.Items
{
    public class Item
    {
        private readonly List<(int ProcessId, string StageName)> _processedBy;
        public int Index { get; }

        public Item(int index)
        {
            Index = index;
            _processedBy = new List<(int ProcessId, string StageName)>();
        }

        public Item(int index, List<(int ProcessId, string StageName)> processedBy)
        {
            Index = index;
            _processedBy = processedBy;
        }

        public void Process(int processId, string stageName)
        {
            _processedBy.Add((processId, stageName));
        }

        public override string ToString()
        {
            var values = _processedBy.Select(x => $"{x.StageName}:{x.ProcessId}").ToArray();
            return $"{nameof(Item)}#{Index}: '{{{string.Join("} -> {", values)}}}';";
        }
    }
}
