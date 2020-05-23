namespace DabRadio.RadioFunctions.DabSearch
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using MediatR;

    public class GetDabProgramsRequestHandler : IAsyncRequestHandler<GetDabProgramsRequest, IEnumerable<IProgramInfoDto>>
    {
        private readonly IDabCommandDispatcher commandDispatcher;

        public GetDabProgramsRequestHandler(IDabCommandDispatcher commandDispatcher)
        {
            this.commandDispatcher = commandDispatcher;
        }

        public Task<IEnumerable<IProgramInfoDto>> Handle(GetDabProgramsRequest message)
        {
            return Task.Run(
                () =>
                    {
                        var allPrograms = this.commandDispatcher.GetAllPrograms();

                        var programInfos = new List<IProgramInfoDto>();

                        for (uint i = 0; i < allPrograms; i++)
                        {
                            var programName = this.commandDispatcher.ProgramName(i);

                            var programInfoDtoWithoutProgramName = this.commandDispatcher.ProgramInfo(i);

                            var programInfoDtoWithProgramName = programInfoDtoWithoutProgramName.Clone(programName: programName);

                            programInfos.Add(programInfoDtoWithProgramName);
                        }

                        return programInfos.AsEnumerable();
                    });
        }
    }
}