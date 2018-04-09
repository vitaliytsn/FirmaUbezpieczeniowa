using Insurinator.Models.Entities.InsuranceDefinitions;

namespace Insurinator.DataAccess.Services
{
    public abstract class InsuranceDefinitionServiceBase<T> : ServiceBase<T> where T : InsuranceDefinition
    {
    }
}