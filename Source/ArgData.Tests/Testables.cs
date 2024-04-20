using System.Collections.Concurrent;
using System.IO;

namespace ArgData.Tests;

public class TestableMediaContainerFileReader : MediaContainerFileReader
{
    public TestableMediaContainerFileReader()
    {
        StreamProvider = MemoryStreamProvider.Open;
    }
}

public class TestableTrackReader : TrackReader
{
    public TestableTrackReader()
    {
        StreamProvider = MemoryStreamProvider.Open;
    }
}

internal static class MemoryStreamProvider
{
    private static readonly ConcurrentDictionary<string, byte[]> FilesAndBytes = new();

    public static Stream Open(string path)
    {
        var bytes = FilesAndBytes.GetOrAdd(path, File.ReadAllBytes(path));

        return new MemoryStream(bytes);
    }
}
