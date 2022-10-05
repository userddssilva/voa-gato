using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // void Update()
    // {
    //     if (Input.touchCount > 0)
    //     {
    //         Touch touchFinger = Input.GetTouch(0);
    //         
    //         // if (touchFinger.phase == TouchPhase.Moved)
    //         // {
    //         //     transform.position += (Vector3)touchFinger.deltaPosition/800;
    //         // }
    //         
    //         Vector3 newPosition = Camera.main.ScreenToWorldPoint(touchFinger.position);
    //         newPosition.z = 0;
    //         transform.position = newPosition;
    //
    //         Debug.Log($"Cam position touch: {newPosition}");
    //     }
    // }

    private Vector3 position;
    private float width;
    private float height;

    void Awake()
    {
        width = (float)Screen.width / 2.0f;
        height = (float)Screen.height / 2.0f;

        // Position used for the cube.
        position = new Vector3(0.0f, 0.0f, 0.0f);
    }

    void OnGUI()
    {
        // Compute a fontSize based on the size of the screen width.
        GUI.skin.label.fontSize = (int)(Screen.width / 25.0f);

        GUI.Label(new Rect(20, 20, width, height * 0.25f),
            "x = " + position.x.ToString("f2") +
            ", y = " + position.y.ToString("f2"));
    }

    void Update()
    {
        // Handle screen touches.
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // Move the cube if the screen has the finger moving.
            if (touch.phase == TouchPhase.Moved)
            {
                var newPosition = Camera.main.ScreenToWorldPoint(touch.position);
                position = new Vector3(newPosition.x, newPosition.y, 0f);

                // Position the cube.
                transform.position = position;
            }
        }

        if (Input.GetMouseButton(0))
        {
            Touch touch = Input.GetTouch(0);
            Debug.Log($"Position touch: {touch.position}");
            
            position = Camera.main.ScreenToWorldPoint(touch.position);
            // position.z = 0;
            // transform.position = position;
            Debug.Log($"World position: {position}");
        }
    }
}