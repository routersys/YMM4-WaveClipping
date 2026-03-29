using System.Reflection;

namespace WaveClipping
{
    internal static class ShaderResourceLoader
    {
        private const string ShaderSuffix = "WaveClippingPS.cso";

        private static readonly Lazy<byte[]> _waveClippingPS =
            new(LoadWaveClippingPS, LazyThreadSafetyMode.ExecutionAndPublication);

        public static byte[] GetWaveClippingPS() => _waveClippingPS.Value;

        private static byte[] LoadWaveClippingPS()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var names = assembly.GetManifestResourceNames();

            string? matched = null;
            foreach (var name in names)
            {
                if (name.EndsWith(ShaderSuffix, StringComparison.Ordinal))
                {
                    matched = name;
                    break;
                }
            }

            if (matched is null)
                throw new InvalidOperationException(
                    $"Embedded resource '{ShaderSuffix}' was not found in the assembly manifest.");

            using var stream = assembly.GetManifestResourceStream(matched)!;
            var buffer = new byte[(int)stream.Length];
            stream.ReadExactly(buffer);
            return buffer;
        }
    }
}