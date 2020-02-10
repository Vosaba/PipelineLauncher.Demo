﻿using System.Collections.Generic;
using PipelineLauncher.Demo.Tests.Items;
using PipelineLauncher.Stages;

namespace PipelineLauncher.Demo.Tests.Stages.Single
{
    public class BulkStage : BulkStage<Item>
    {
        public override IEnumerable<Item> Execute(IEnumerable<Item> items)
        {
            foreach (var item in items)
            {
                item.Process(GetType());

                yield return item;
            }
        }
    }

    public class BulkStage_1 : BulkStage<Item>
    {
        public override IEnumerable<Item> Execute(IEnumerable<Item> items)
        {
            foreach (var item in items)
            {
                item.Process(GetType());

                yield return item;
            }
        }
    }

    public class BulkStage_2 : BulkStage<Item>
    {
        public override IEnumerable<Item> Execute(IEnumerable<Item> items)
        {
            foreach (var item in items)
            {
                item.Process(GetType());

                yield return item;
            }
        }
    }

    public class BulkStage_3 : BulkStage<Item>
    {
        public override IEnumerable<Item> Execute(IEnumerable<Item> items)
        {
            foreach (var item in items)
            {
                item.Process(GetType());

                yield return item;
            }
        }
    }
}
