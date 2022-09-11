using Application.Features.ProgrammingLanguages.Dtos;
using Application.Features.ProgrammingLanguages.Models;
using Application.Features.ProgrammingLanguages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entitties;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguages.Queries.ProgrammingLanguageQueries
{
    public class GetByIdQuery: IRequest<ProgrammingLanguageGetByIdDto>
    {
        public int Id { get; set; }
    }
    public class GetByIdQueryHandler : IRequestHandler<GetByIdQuery, ProgrammingLanguageGetByIdDto>
    {
        private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
        private readonly IMapper _mapper;
        private readonly ProgrammingLanguageBusinessRules _programmingLanguageBusinessRules;

        public GetByIdQueryHandler(IProgrammingLanguageRepository programmingLanguageRepository, IMapper mapper, ProgrammingLanguageBusinessRules programmingLanguageBusinessRules)
        {
            _programmingLanguageRepository = programmingLanguageRepository;
            _mapper = mapper;
            _programmingLanguageBusinessRules = programmingLanguageBusinessRules;
        }

        public async Task<ProgrammingLanguageGetByIdDto> Handle(GetByIdQuery request, CancellationToken cancellationToken)
        {
            ProgrammingLanguage result=await _programmingLanguageBusinessRules.ProgrammingLanguageIdIsExists(request.Id);

            ProgrammingLanguageGetByIdDto mappedProgrammingLanguageGetByIdDto = _mapper.Map<ProgrammingLanguageGetByIdDto>(result);

            return mappedProgrammingLanguageGetByIdDto;
        }
    }
}
