using UnityEngine;

public class GameEngine : MonoBehaviour
{
    public GameObject pigModel;
    public GameObject tileModel;
    public GameObject towerModel;
    public GameObject doorModel;
    public GameObject devilModel;
    public Camera mainCamera;

    private Player player;
    private Tile[][] path;

    void Start()
    {
        int w = 10; // Width of the grid
        int h = 10; // Height of the grid
        path = new Tile[h][];

        for (int i = 0; i < path.Length; i++)
        {
            path[i] = new Tile[w];
            for (int i2 = 0; i2 < path[i].Length; i2++)
            {
                GameObject tileObj = tileModel;
                bool istower = false;

                // Check if it's an outer wall (border)
                if (i == 0 || i == h - 1 || i2 == 0 || i2 == w - 1)
                {
                    tileObj = towerModel; // If it's a border, place a tower
                    istower = true;
                }

                // Randomly place towers in some tiles
                else if (UnityEngine.Random.value < 0.2f) // 20% chance for a tower
                {
                    tileObj = towerModel;
                    istower = true;
                }

                // Instantiate the tile and store it in the path array
                GameObject instance = MonoBehaviour.Instantiate(tileObj, new Vector3(i2 * 2, 0, i * 2), Quaternion.identity);
                path[i][i2] = new Tile(instance, istower);
            }
        }

        // Spawn the player at position (2, 2)
        GameObject playerSpawnPos = path[2][2].tileObject; // Get the GameObject at (2, 2)
        Debug.Log(playerSpawnPos.transform.position);
        GameObject playerObj = Instantiate(pigModel, playerSpawnPos.transform.position, Quaternion.identity);
        player = new Player(playerObj); // Create the player instance
    }

    void Update()
    {
        player.DoMove(path);
        mainCamera.transform.position = player.obj.transform.position + new Vector3(0, 15, 0);
    }
}
