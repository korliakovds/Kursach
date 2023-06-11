using UnityEngine;

public class Maze
{
    public MazeGeneratorCell[,] cells; // Масив з яких робиться лабіринт
    public Vector2Int finishPosition;
}

public class MazeGeneratorCell
{
    public int X;
    public int Y;

    public bool WallLeft = true;
    public bool WallBottom = true;

    public bool Visited = false;
    public int DistanceFromStart;
}
