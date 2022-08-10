namespace PrettyRoad.UserService.Extensions;

public static class QueryClassBuilder<T> where T:class 
{
    public static T CreateObjectFromQuery(string query) // this til .net 7 come out...
    {
        try
        {
            var queryDictionary = Microsoft.AspNetCore.WebUtilities.QueryHelpers.ParseQuery(query);
            
            T instance = (T)Activator.CreateInstance(typeof(T));

            foreach (var el in typeof(T).GetProperties())
            {
                var value = queryDictionary.Where(x => x.Key == el.Name).FirstOrDefault().Value.ToString();
                var castedValue = Convert.ChangeType(value, el.PropertyType);
                el.SetValue(instance, castedValue);
            }
            
            return instance;
        }
        catch (Exception ex)
        {
            return null;
        }
    }
}