using Newtonsoft.Json;

namespace MilksAndCookies
{
    /// <summary>
    /// Helper class for Httpcontext.Session
    /// Saves and gets an object by key
    /// </summary>
    public static class SessionExtensions
    {
        public static void SetObjectAsJson(this ISession session, string key, object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }
        public static T GetObjectFromJson<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default(T) :
            JsonConvert.DeserializeObject<T>(value);
        }
    }
}
