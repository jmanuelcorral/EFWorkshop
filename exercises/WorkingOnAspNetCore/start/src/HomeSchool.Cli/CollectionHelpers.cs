using Newtonsoft.Json;
using System.Collections.Generic;

namespace HomeSchool.Cli
{
    //This is a small sample of an Extension Method that serializes a collection in JSON
    public static class CollectionHelpers
    {
        public static string DumpAsJson<T>(this List<T> collection)
        {
            return JsonConvert.SerializeObject(collection);
        }

        public static string DumpAsJson<T>(this IEnumerable<T> mycoolObj)
        {
            return JsonConvert.SerializeObject(mycoolObj);
        }
    }
}
