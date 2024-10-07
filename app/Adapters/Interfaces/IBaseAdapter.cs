using app.Entities;
using app.Models;

namespace app.Adapters.Interfaces;

public interface IBaseAdapter
{
    TimeBankModel MapEntityToModel(TimeBank timeBankEntity);
    TimeBank MapModelToEntity(TimeBankModel timeBankModels);
}