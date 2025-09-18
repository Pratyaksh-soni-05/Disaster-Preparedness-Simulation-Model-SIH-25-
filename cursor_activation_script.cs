using UnityEngine;

public class CursorController : MonoBehaviour
{
    void Start()
    {
        // Make the cursor visible
        Cursor.visible = true;
        // Unlock the cursor, allowing it to move freely within the game window
        Cursor.lockState = CursorLockMode.None;
    }

    // You can also manage cursor visibility and lock state in Update() 
    // if you need to change it dynamically during gameplay based on conditions.
    // void Update()
    // {
    //     if (Input.GetKeyDown(KeyCode.Escape)) // Example: Press Escape to toggle cursor
    //     {
    //         Cursor.visible = !Cursor.visible;
    //         Cursor.lockState = Cursor.visible ? CursorLockMode.None : CursorLockMode.Locked;
    //     }
    // }
}