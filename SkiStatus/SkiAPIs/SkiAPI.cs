using SkiAPIs.Formats;

namespace SkiAPIs
{
    public static partial class SkiAPI
    {
        public static Interpreter GetInterpreter (APIFormat format)
        {
            return format switch
            {
                APIFormat.Powdr => PowdrInterpreter,
                _ => throw new NotSupportedException($"APIFormat {format} is not supported") 
            };
        }

        internal static Powdr PowdrInterpreter { get; set; } = new Powdr();
    }
}