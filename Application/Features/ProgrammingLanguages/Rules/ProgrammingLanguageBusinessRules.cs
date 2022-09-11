using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Domain.Entitties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguages.Rules
{
    public class ProgrammingLanguageBusinessRules
    {
        private readonly IProgrammingLanguageRepository _programmingLanguageRepository;

        public ProgrammingLanguageBusinessRules(IProgrammingLanguageRepository programmingLanguageRepository)
        {
            _programmingLanguageRepository = programmingLanguageRepository;
        }

        public async Task ProgrammingLanguageNameCanNotBeDuplicatedWhenInserted(string name)
        {
            IPaginate<ProgrammingLanguage> result = await _programmingLanguageRepository.GetListAsync(a => a.Name == name);
            if (result.Items.Any()) throw new BusinessException("Programming language name exists");
        }
        public async Task<ProgrammingLanguage> ProgrammingLanguageIdIsExists(int id)
        {
            ProgrammingLanguage result=await _programmingLanguageRepository.GetAsync(b=>b.Id==id);

            if (result==null) throw new BusinessException("Programming language does not exists");
            return result;
        }
    }
}
