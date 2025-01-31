using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    public GameObject obj;

    public Player(GameObject obj)
    {
        this.obj = obj;
    }

    // This method checks if the player can move to the target position
    bool CanMoveTo(Vector3 newPos, Tile[][] path)
    {
        // Convert the new position to grid coordinates
        int x = (int)(newPos.x / 2);
        int z = (int)(newPos.z / 2);

        // Check if the new position is within bounds of the grid
        if (x < 0 || x >= path[0].Length || z < 0 || z >= path.Length)
        {
            return false;
        }

        // Get the tile at the specified coordinates
        Tile targetTile = path[z][x];

        // Check if the tile is blocked by a tower or wall
        if (targetTile.istower)
        {
            return false;  // Can't move to a blocked tile
        }

        return true;  // The tile is not blocked, move is allowed
    }

    // Move the player to the new position if valid
    public void Move(Vector3 newPos, Tile[][] path)
    {
        if (CanMoveTo(newPos, path))
        {
            obj.transform.position = newPos;  // Move the player to the new position
        }
    }

    // Handle movement input and apply the necessary changes to the player's position
    public void DoMove(Tile[][] path)
    {
        Vector3 newPos = obj.transform.position;  // Get current position of the player

        // Check for input and adjust the position
        if (Input.GetKeyDown(KeyCode.W))  // Move up
        {
            newPos.z += 2;
            obj.transform.rotation = Quaternion.Euler(0, 0, 0);  // Rotate player to face up
        }
        else if (Input.GetKeyDown(KeyCode.S))  // Move down
        {
            newPos.z -= 2;
            obj.transform.rotation = Quaternion.Euler(0, 180, 0);  // Rotate player to face down
        }
        else if (Input.GetKeyDown(KeyCode.A))  // Move left
        {
            newPos.x -= 2;
            obj.transform.rotation = Quaternion.Euler(0, -90, 0);  // Rotate player to face left
        }
        else if (Input.GetKeyDown(KeyCode.D))  // Move right
        {
            newPos.x += 2;
            obj.transform.rotation = Quaternion.Euler(0, 90, 0);  // Rotate player to face right
        }

        // Call the Move method to update the player's position
        Move(newPos, path);
    }
}
