using System.Reflection;

namespace app.Adapters;

public class BaseAdapter<TEntity, TModel>
{
    public TModel MapEntityToModel(TEntity entity)
    {
        var model = Activator.CreateInstance<TModel>();

        var propierties = GetProperty<TModel, TEntity>();

        foreach (var item in propierties)
        {
            var value = entity.GetType().GetProperty(item).GetValue(entity);
            model.GetType().GetProperty(item).SetValue(model, value);
        }
        return model;
    }
    
    public TEntity MapModelToEntity(TModel model)
    {
        var entity = Activator.CreateInstance<TEntity>();

        var propierties = GetProperty<TEntity, TModel>();

        foreach (var item in propierties)
        {
            var value = model.GetType().GetProperty(item).GetValue(model);
            entity.GetType().GetProperty(item).SetValue(entity, value);
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