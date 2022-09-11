using Core.Persistence.Repositories;
using Domain.Entitties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Repositories
{
    public interface IProgrammingLanguageRepository:IAsyncRepository<ProgrammingLanguage>,IRepository<ProgrammingLanguage>
    {
    }
}
