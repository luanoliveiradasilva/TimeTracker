using app.Adapters.Interfaces;
using app.Entities;
using app.Models;

namespace app.Adapters;

public class BaseAdapter: IBaseAdapter
{
    
    public TimeBankModel  MapEntityToModel( TimeBank timeBankEntity)
     {
         var model = Activator.CreateInstance<TimeBankModel>();

         var prop = GetProperty<TimeBankModel, TimeBank>();

         foreach (var item in prop)
         {
             var value = timeBankEntity.GetType().GetProperty(item).GetValue(timeBankEntity);
             model.GetType().GetProperty(item).SetValue(model, value);
         }

         return model;
     }
    
     public TimeBank MapModelToEntity(TimeBankModel timeBankModels)
     {
         var entity = Activator.CreateInstance<TimeBank>();

         var propierties = GetProperty<TimeBank, TimeBankModel>();

         foreach (var property in propierties)
         {
             var value = timeBankModels.GetType().GetProperty(property).GetValue(timeBankModels);
             entity.GetType().GetProperty(property).SetValue(entity, value);
         }
         return entity;
     }

    private static List<string> GetProperty<TFrom, Tto>()
    {
        var from = typeof(TFrom).GetProperties();
        var to = typeof(Tto).GetProperties();
        
        var properties = new List<string>();

        foreach (var item in to)
        {
            var fromProperty = from.FirstOrDefault(x => x.Name == item.Name && x.GetType() == item.GetType());
            
            if(fromProperty != null)
                properties.Add(item.Name);
        }

        return properties;
    }
}