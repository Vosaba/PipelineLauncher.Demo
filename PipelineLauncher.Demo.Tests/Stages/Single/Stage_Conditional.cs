﻿using PipelineLauncher.Abstractions.Stages;
using PipelineLauncher.Demo.Tests.Items;
using PipelineLauncher.Stages;

namespace PipelineLauncher.Demo.Tests.Stages.Single
{
    public class Stage_Conditional : Stage<Item>, IConditionalStage<Item>
    {
        public override Item Execute(Item item)
        {
            item.Process(GetType());

            return item;
        }

        public bool Predicate(Item input)
        {
            return true;
        }
    }
}
