[System.Serializable]
public class Position
{
    public float x;
    public float y;
    public float z;
    public float width;
    public float height;

    public Position(float x, float y, float z, float width, float height)
    {
        this.x = x;
        this.y = y;
        this.z = z;
        this.width = width;
        this.height = height;
    }
}

[System.Serializable]
public class PositionWithTimestamp : Position
{
    public float timestamp;

    public PositionWithTimestamp(float x, float y, float z, float width, float height, float timestamp)
        : base(x, y, z, width, height)
    {
        this.timestamp = timestamp;
    }
}

[System.Serializable]
public class Config
{
    public Position[] runPositions;
    public Position[] testPositions;
}

[System.Serializable]
public class ExportConfig
{
    public bool isTestRun;
    public PositionWithTimestamp[] positions;

    public ExportConfig(bool isTestRun, PositionWithTimestamp[] positions)
    {
        this.isTestRun = isTestRun;
        this.positions = positions;
    }
}