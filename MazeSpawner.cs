using UnityEngine;

public class MazeSpawner : MonoBehaviour
{
    public Cell CellPrefab; // Префаб комірки лабіринту
    public Vector3 CellSize = new Vector3(1, 1, 0); // Розмір комірки
   // public HintRenderer HintRenderer; // Рендерер підказок

    public Maze maze; // Створений лабіринт

    private void Start()
    {
        MazeGenerator generator = new MazeGenerator();
        maze = generator.GenerateMaze(); // Генерація лабіринту

        for (int x = 0; x < maze.cells.GetLength(0); x++)
        {
            for (int y = 0; y < maze.cells.GetLength(1); y++)
            {
                // Створення комірки на певній позиції з використанням префабу комірки
                Cell c = Instantiate(CellPrefab, new Vector3(x * CellSize.x, y * CellSize.y, y * CellSize.z), Quaternion.identity);

                // Встановлення активності стінок комірки залежно від значень у лабіринті
                c.WallLeft.SetActive(maze.cells[x, y].WallLeft);
                c.WallBottom.SetActive(maze.cells[x, y].WallBottom);
            }
        }

       // HintRenderer.DrawPath(); // Відображення шляху у лабіринті
    }
}