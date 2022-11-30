using SkiAPIs.Formats;

namespace SkiAPIs
{
    public static class SkiAPI
    {
        public static Interpreter GetInterpreter (APIFormat format)
        {
            return format switch
            {
                APIFormat.Powdr => new Powdr(),
                _ => throw new NotSupportedException($"APIFormat {format} is not supported") 
            };
        }
    }
}