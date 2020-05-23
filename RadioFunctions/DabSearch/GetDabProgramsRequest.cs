namespace DabRadio.RadioFunctions.DabSearch
{
    using System.Collections.Generic;

    using MediatR;

    public class GetDabProgramsRequest : IAsyncRequest<IEnumerable<IProgramInfoDto>>
    {
    }
}