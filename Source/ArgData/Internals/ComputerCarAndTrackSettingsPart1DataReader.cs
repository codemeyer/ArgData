using ArgData.Entities;

namespace ArgData.Internals;

internal static class ComputerCarAndTrackSettingsPart1DataReader
{
    public static ComputerCarAndTrackSettingsPart1DataReadingResult Read(BinaryReader reader, int position)
    {
        reader.BaseStream.Position = position;

        var setup = new Setup
        {
            FrontWing = Convert.ToByte(reader.ReadByte() - 151),
            RearWing = Convert.ToByte(reader.ReadByte() - 151),
            GearRatio1 = Convert.ToByte(reader.ReadByte() - 151),
            GearRatio2 = Convert.ToByte(reader.ReadByte() - 151),
            GearRatio3 = Convert.ToByte(reader.ReadByte() - 151),
            GearRatio4 = Convert.ToByte(reader.ReadByte() - 151),
            GearRatio5 = Convert.ToByte(reader.ReadByte() - 151),
            GearRatio6 = Convert.ToByte(reader.ReadByte() - 151),
            TyreCompound = GetTyreCompound(Convert.ToByte(reader.ReadByte() - 52)),
            BrakeBalance = Convert.ToSByte(reader.ReadSByte())
        };

        var data = new ComputerCarDataAndTrackSettingsPart1
        {
            GripFactor = reader.ReadInt16(),
            ComputerCarLateBrakingFactorNonRace = reader.ReadInt16(),
            ComputerCarLateBrakingFactorRace = reader.ReadInt16(),
            TimeFactorNonRace = reader.ReadInt16(),
            Acceleration = reader.ReadInt16(),
            AirResistance = reader.ReadInt16(),
            TyreWearQualifying = reader.ReadInt16(),
            TyreWearNonQualifying = reader.ReadInt16(),
            FuelLoad = reader.ReadInt16(),
            TimeFactorRace = reader.ReadInt16(),
            ComputerCarPowerFactor = reader.ReadInt16(),
            ComputerCarLateBrakingFactorWetRace = reader.ReadInt16(),
            UnknownTrackDistance = reader.ReadInt16(),
            DefaultPitLaneViewDistance = reader.ReadInt16()
        };

        var positionAfterReading = (int)reader.BaseStream.Position;

        return new ComputerCarAndTrackSettingsPart1DataReadingResult(setup, data, positionAfterReading);
    }

    private static SetupTyreCompound GetTyreCompound(byte rawValue)
    {
        return (SetupTyreCompound)Enum.Parse(typeof(SetupTyreCompound), rawValue.ToString());
    }
}