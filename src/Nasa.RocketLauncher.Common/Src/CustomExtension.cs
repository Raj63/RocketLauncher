using Newtonsoft.Json;

namespace Nasa.RocketLauncher.Application
{
    public static class CustomExtension
    {
        public static bool Abort(this int? action)
        {
            return action == null || action <= 0;
        }

        public static string ToString(this object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
    }
}
