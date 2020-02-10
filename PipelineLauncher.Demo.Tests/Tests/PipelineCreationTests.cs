using PipelineLauncher.Abstractions.Stages;
using PipelineLauncher.Demo.Tests.Fakes;
using System;
using Xunit;

namespace PipelineLauncher.Demo.Tests
{
    public class PipelineCreationTests 
    {
        private IPipelineCreator _pipelineCreator;
            
        [Fact]
        public void Pipeline_Creation_WithOverloads()
        {
            _pipelineCreator = new PipelineCreator();

            _pipelineCreator = new PipelineCreator(new StageServiceFake());

            _pipelineCreator = new PipelineCreator(x => (IStage)Activator.CreateInstance(x));
        }
    }
}
