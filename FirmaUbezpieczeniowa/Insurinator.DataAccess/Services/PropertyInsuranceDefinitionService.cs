using Insurinator.Interfaces.Services;
using Insurinator.Models.Entities.InsuranceDefinitions;

namespace Insurinator.DataAccess.Services
{
    public class PropertyInsuranceDefinitionService : InsuranceDefinitionServiceBase<PropertyInsuranceDefinition>,
        IPropertyInsuranceDefinitionService
    {
    }
}