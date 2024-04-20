namespace ArgData.Entities;

/// <summary>
/// Points system determines how many championship points are scored per finishing position.
/// </summary>
public class PointsSystem
{
    /// <summary>
    /// Represents a points system, with the number of championship points scored for each finishing position.
    /// </summary>
    public PointsSystem()
    {
        Points = new byte[26];
    }

    /// <summary>
    /// Points per position, zero-based.
    /// </summary>
    public byte[] Points { get; }

    /// <summary>
    /// Gets or sets the number of championship points scored for finishing 1st.
    /// </summary>
    public byte PointsFor1st
    {
        get { return Points[0]; }
        set { Points[0] = value; }
    }

    /// <summary>
    /// Gets or sets the number of championship points scored for finishing 2nd.
    /// </summary>
    public byte PointsFor2nd
    {
        get { return Points[1]; }
        set { Points[1] = value; }
    }

    /// <summary>
    /// Gets or sets the number of championship points scored for finishing 3rd.
    /// </summary>
    public byte PointsFor3rd
    {
        get { return Points[2]; }
        set { Points[2] = value; }
    }

    /// <summary>
    /// Gets or sets the number of championship points scored for finishing 4th.
    /// </summary>
    public byte PointsFor4th
    {
        get { return Points[3]; }
        set { Points[3] = value; }
    }

    /// <summary>
    /// Gets or sets the number of championship points scored for finishing 5th.
    /// </summary>
    public byte PointsFor5th
    {
        get { return Points[4]; }
        set { Points[4] = value; }
    }

    /// <summary>
    /// Gets or sets the number of championship points scored for finishing 6th.
    /// </summary>
    public byte PointsFor6th
    {
        get { return Points[5]; }
        set { Points[5] = value; }
    }

    /// <summary>
    /// Gets or sets the number of championship points scored for finishing 7th.
    /// </summary>
    public byte PointsFor7th
    {
        get { return Points[6]; }
        set { Points[6] = value; }
    }

    /// <summary>
    /// Gets or sets the number of championship points scored for finishing 8th.
    /// </summary>
    public byte PointsFor8th
    {
        get { return Points[7]; }
        set { Points[7] = value; }
    }

    /// <summary>
    /// Gets or sets the number of championship points scored for finishing 9th.
    /// </summary>
    public byte PointsFor9th
    {
        get { return Points[8]; }
        set { Points[8] = value; }
    }

    /// <summary>
    /// Gets or sets the number of championship points scored for finishing 10th.
    /// </summary>
    public byte PointsFor10th
    {
        get { return Points[9]; }
        set { Points[9] = value; }
    }

    /// <summary>
    /// Gets or sets the number of championship points scored for finishing 11th.
    /// </summary>
    public byte PointsFor11th
    {
        get { return Points[10]; }
        set { Points[10] = value; }
    }

    /// <summary>
    /// Gets or sets the number of championship points scored for finishing 12th.
    /// </summary>
    public byte PointsFor12th
    {
        get { return Points[11]; }
        set { Points[11] = value; }
    }

    /// <summary>
    /// Gets or sets the number of championship points scored for finishing 13th.
    /// </summary>
    public byte PointsFor13th
    {
        get { return Points[12]; }
        set { Points[12] = value; }
    }

    /// <summary>
    /// Gets or sets the number of championship points scored for finishing 14th.
    /// </summary>
    public byte PointsFor14th
    {
        get { return Points[13]; }
        set { Points[13] = value; }
    }

    /// <summary>
    /// Gets or sets the number of championship points scored for finishing 15th.
    /// </summary>
    public byte PointsFor15th
    {
        get { return Points[14]; }
        set { Points[14] = value; }
    }

    /// <summary>
    /// Gets or sets the number of championship points scored for finishing 16th.
    /// </summary>
    public byte PointsFor16th
    {
        get { return Points[15]; }
        set { Points[15] = value; }
    }

    /// <summary>
    /// Gets or sets the number of championship points scored for finishing 17th.
    /// </summary>
    public byte PointsFor17th
    {
        get { return Points[16]; }
        set { Points[16] = value; }
    }

    /// <summary>
    /// Gets or sets the number of championship points scored for finishing 18th.
    /// </summary>
    public byte PointsFor18th
    {
        get { return Points[17]; }
        set { Points[17] = value; }
    }

    /// <summary>
    /// Gets or sets the number of championship points scored for finishing 19th.
    /// </summary>
    public byte PointsFor19th
    {
        get { return Points[18]; }
        set { Points[18] = value; }
    }

    /// <summary>
    /// Gets or sets the number of championship points scored for finishing 20th.
    /// </summary>
    public byte PointsFor20th
    {
        get { return Points[19]; }
        set { Points[19] = value; }
    }

    /// <summary>
    /// Gets or sets the number of championship points scored for finishing 21st.
    /// </summary>
    public byte PointsFor21st
    {
        get { return Points[20]; }
        set { Points[20] = value; }
    }

    /// <summary>
    /// Gets or sets the number of championship points scored for finishing 22nd.
    /// </summary>
    public byte PointsFor22nd
    {
        get { return Points[21]; }
        set { Points[21] = value; }
    }

    /// <summary>
    /// Gets or sets the number of championship points scored for finishing 23rd.
    /// </summary>
    public byte PointsFor23rd
    {
        get { return Points[22]; }
        set { Points[22] = value; }
    }

    /// <summary>
    /// Gets or sets the number of championship points scored for finishing 24th.
    /// </summary>
    public byte PointsFor24th
    {
        get { return Points[23]; }
        set { Points[23] = value; }
    }

    /// <summary>
    /// Gets or sets the number of championship points scored for finishing 25th.
    /// </summary>
    public byte PointsFor25th
    {
        get { return Points[24]; }
        set { Points[24] = value; }
    }

    /// <summary>
    /// Gets or sets the number of championship points scored for finishing 26th.
    /// </summary>
    public byte PointsFor26th
    {
        get { return Points[25]; }
        set { Points[25] = value; }
    }
}