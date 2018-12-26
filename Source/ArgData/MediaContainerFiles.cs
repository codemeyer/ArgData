using System;
using System.IO;
using System.Linq;
using ArgData.Entities;
using ArgData.IO;

namespace ArgData
{
    /// <summary>
    /// Reads media container files.
    /// </summary>
    public class MediaContainerFileReader
    {
        /// <summary>
        /// Reads the media container file at the specified path.
        /// </summary>
        /// <param name="path">Path to image container file.</param>
        /// <returns>MediaContainerFile.</returns>
        public MediaContainerFile Read(string path)
        {
            ValidateFile(path);

            using (var reader = new BinaryReader(StreamProvider(path)))
            {
                var signature = reader.ReadBytes(8);
                ValidateSignature(signature, path);

                var imageFile = new MediaContainerFile();

                var fileCount = reader.ReadInt16();

                for (int i = 0; i < fileCount; i++)
                {
                    var type = reader.ReadInt16();
                    var item = ItemFactory(type);
                    item.Offset = reader.ReadInt32();
                    item.Length = reader.ReadInt32();
                    item.Width = reader.ReadInt16();
                    item.Height = reader.ReadInt16();
                    imageFile.Items.Add(item);
                }

                foreach (var item in imageFile.Items)
                {
                    reader.BaseStream.Position = item.Offset;
                    item.Data = reader.ReadBytes(item.Length);
                }

                return imageFile;
            }
        }

        private static void ValidateFile(string path)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException("Could not find container file", path);
            }
        }

        private static void ValidateSignature(byte[] signature, string path)
        {
            if (!signature.SequenceEqual(MediaContainerFileConstants.Signature))
            {
                throw new ArgumentException($"The file '{path}' does not appear to be a item container file.");
            }
        }

        private static MediaFileItem ItemFactory(short type)
        {
            switch (type)
            {
                case 1768:
                    return new MediaItem1768();

                case 1769:
                    return new ImageItem1769();

                case 1774:
                    return new ImageItem1774();

                case 1776:
                    return new PaletteItem();
            }

            return null;
        }

        /// <summary>
        /// Default FileStream provider. Can be overridden in tests.
        /// </summary>
        internal Func<string, Stream> StreamProvider = FileStreamProvider.Open;
    }

    /// <summary>
    /// Class for writing to media container files, such as HELMETS.DAT.
    /// </summary>
    public class MediaContainerFileWriter
    {
        /// <summary>
        /// Writes the specified container item into the file at path.
        /// </summary>
        /// <param name="path">Path to file to create/update.</param>
        /// <param name="container">MediaContainerFile representing the data that should be written.</param>
        public void Write(string path, MediaContainerFile container)
        {
            using (var writer = new BinaryWriter(StreamProvider.Invoke(path)))
            {
                writer.Write(MediaContainerFileConstants.Signature);

                short fileCount = Convert.ToInt16(container.Items.Count);
                writer.Write(fileCount);

                int currentOffset = 10 + fileCount * 14;

                foreach (var item in container.Items)
                {
                    item.Offset = currentOffset;
                    currentOffset += item.Length;

                    writer.Write(item.Type);
                    writer.Write(item.Offset);
                    writer.Write(item.Length);
                    writer.Write(item.Width);
                    writer.Write(item.Height);
                }

                foreach (var item in container.Items)
                {
                    writer.Write(item.Data);
                }
            }
        }

        /// <summary>
        /// Default FileStream provider. Can be overridden in tests.
        /// </summary>
        internal Func<string, Stream> StreamProvider = FileStreamProvider.OpenWriter;
    }

    internal static class MediaContainerFileConstants
    {
        internal static readonly byte[] Signature = { 0x66, 0x31, 0x70, 0x63, 0x61, 0x6e, 0x69, 0x6d };     // f1pcanim
    }
}
