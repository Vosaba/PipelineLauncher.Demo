﻿using PipelineLauncher.Demo.Tests.Extensions;
using PipelineLauncher.Demo.Tests.Items;
using PipelineLauncher.Demo.Tests.Stages.Single;
using PipelineLauncher.Exceptions;
using System;
using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;

namespace PipelineLauncher.Demo.Tests.PipelineTest.PipelineRunner
{

    public class FeatureStagesTests : PipelineTestBase
    {
        public FeatureStagesTests(ITestOutputHelper output) : base(output) { }

        [Fact]
        public void Feature_Exception_Retry_Awaitable_Stages_WrongConfiguration()
        {
            // Test input 6 items
            List<Item> items = MakeItemsInput(6);

            // Configure stages
            var pipelineSetup = PipelineCreator
                .Stage<Stage, Item>()
                .Stage(item =>
                {
                    item.Process(GetType());

                    if (item.Index == 2)
                    {
                        throw new Exception($"{item.Name} throw exception");
                    }

                    return item;
                })
                .Stage<Stage_1>();

            // Make pipeline from stageSetup
            var pipelineRunner = pipelineSetup.CreateAwaitable();

            pipelineRunner.ExceptionItemsReceivedEvent += (args) =>
            {
                var item = args.Items[0];

                WriteSeparator();
                WriteLine($"{item} with exception {args.Exception.Message}");
                WriteSeparator();

                Assert.Throws<PipelineUsageException>(() => args.Retry());
            };

            // Process items and print result
            (this, pipelineRunner).ProcessAndPrintResults(items);
        }

        [Fact]
        public void Feature_Exception_Retry_Awaitable_Stages()
        {
            // Test input 6 items
            List<Item> items = MakeItemsInput(6);

            // Error occurred count
            var errorsCount = 0;

            // Configure stages
            var pipelineSetup = PipelineCreator
                .Stage<Stage, Item>()
                .Stage(item =>
                {
                    item.Process(GetType());

                    if (item.Index == 2 && errorsCount++ < 1)
                    {
                        throw new Exception($"{item.Name} throw exception: #'{errorsCount}'");
                    }

                    return item;
                })
                .Stage<Stage_1>();

            // Make pipeline from stageSetup
            var pipelineRunner = pipelineSetup.CreateAwaitable();

            pipelineRunner.ExceptionItemsReceivedEvent += (args) =>
            {
                var item = args.Items[0];

                WriteSeparator();
                WriteLine($"{item} with exception {args.Exception.Message}");
                WriteSeparator();
            };

            // Process items and print result
            (this, pipelineRunner).ProcessAndPrintResults(items);
        }
    }
}
;