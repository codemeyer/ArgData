﻿namespace ArgData
{
    /// <summary>
    /// Class used for calculating an F1GP checksum.
    /// </summary>
    public class ChecksumCalculator
    {
        /// <summary>
        /// Calculates the first and second checksums for the specified file data.
        /// </summary>
        /// <param name="allBytes">Array of all file bytes except last four.</param>
        /// <returns>GpChecksum.</returns>
        public GpChecksum Calculate(byte[] allBytes)
        {
            for (int i = 0; i <= allBytes.Length - 1; i++)
            {
                byte b = allBytes[i];
                AddToChecksum(b);
            }

            int firstChecksum = _sumOfAllBytes & 0x0000FFFF;
            int secondChecksum = _secondCalculatedValue & 0x0000FFFF;

            return new GpChecksum { Checksum1 = firstChecksum, Checksum2 = secondChecksum };
        }

        private int _sumOfAllBytes;
        private int _secondCalculatedValue;

        private void AddToChecksum(int value)
        {
            int workingValue = _secondCalculatedValue & 0x0000E000;
            workingValue = workingValue >> 13;
            _secondCalculatedValue = _secondCalculatedValue << 3;
            _secondCalculatedValue = _secondCalculatedValue | workingValue;
            _secondCalculatedValue = _secondCalculatedValue + value;

            _sumOfAllBytes += value;
        }
    }
}