# ChecksumCalculator

Class used for calculating an F1GP checksum.



## Methods

| Name            | Description        |
|-----------------|--------------------|
| Calculate(Byte[] allBytes)   |  Calculates the first and second checksums for the specified file data.<br />*allBytes:* Array of all file bytes except last four.<br /> 
| UpdateChecksum(String path)   |  Updates the checksum (i.e. the last four bytes) of the specified file.<br />*path:* Path to file.<br /> 


