using System;
using System.IO;
using System.Linq;
using ArgData.Entities;

namespace ArgData
{
    /// <summary>
    /// Reads image container files.
    /// </summary>
    public static class ItemContainerFileReader
    {
        /// <summary>
        /// Reads the image container file at the specified path.
        /// </summary>
        /// <param name="path">Path to image container file.</param>
        /// <returns>ImageFileContainer.</returns>
        public static ItemContainerFile Read(string path)
        {
            ValidateFile(path);

            using (var reader = new BinaryReader(File.Open(path, FileMode.Open)))
            {
                var signature = reader.ReadBytes(8);
                ValidateSignature(signature, path);

                var imageFile = new ItemContainerFile();

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
            if (!signature.SequenceEqual(ItemContainerFileConstants.Signature))
            {
                throw new ArgumentException($"The file '{path}' does not appear to be a item container file.");
            }
        }

        private static ItemContainerFileItem ItemFactory(short type)
        {
            switch (type)
            {
                case 1768:
                    return new ContainerItem1768();

                case 1769:
                    return new ImageItem1769();

                case 1774:
                    return new ImageItem1774();

                case 1776:
                    return new PaletteItem();
            }

            return null;
        }
    }

    /// <summary>
    /// Class for writing to container files, such as HELMETS.DAT.
    /// </summary>
    public static class ItemContainerFileWriter
    {
        /// <summary>
        /// Writes the specified container item into the file at path.
        /// </summary>
        /// <param name="path">Path to file to create/update.</param>
        /// <param name="container">ItemContainerFile representing the data that should be written.</param>
        public static void Write(string path, ItemContainerFile container)
        {
            using (var writer = new BinaryWriter(File.Open(path, FileMode.Create)))
            {
                writer.Write(ItemContainerFileConstants.Signature);

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
    }

    internal static class ItemContainerFileConstants
    {
        internal static readonly byte[] Signature = { 0x66, 0x31, 0x70, 0x63, 0x61, 0x6e, 0x69, 0x6d };     // f1pcanim
    }
}
