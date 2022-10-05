using UnityEngine;

public class CircleMoveController : MonoBehaviour
{
    private Vector3 position;
    private float width;
    private float height;

    // Start is called before the first frame update
    void Start()
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

        GUI.Label(new Rect(20, 20, width + 50f, height * 0.25f),
            "x = " + position.x.ToString("f2") +
            ", y = " + position.y.ToString("f2") +
            ", z = " + position.z.ToString("f2"));
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            var touch = Input.GetTouch(0);
            FollowTouchInScreen(touch.position.x, touch.position.y);
        }

        if (Input.GetMouseButton(0))
        {
            FollowTouchInScreen(Input.mousePosition.x, Input.mousePosition.y);
        }
    }

    private void FollowTouchInScreen(float x, float y)
    {
        Vector3 gameObjectWorldPosition = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 newGameObjectWorldPosition = new Vector3(x, y, gameObjectWorldPosition.z);
        position = Camera.main.ScreenToWorldPoint(newGameObjectWorldPosition);
        transform.position = position;
    }
}