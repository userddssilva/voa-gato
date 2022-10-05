using UnityEngine;

public class CatFollower : MonoBehaviour
{
    public GameObject Player;

    private Collider2D CatCollider2D;
    private Rigidbody2D CatRigidbody2D;

    void Start()
    {
        CatCollider2D = GetComponent<Collider2D>();
        CatRigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        var playerCollider2D = Player.GetComponent<Collider2D>();
        if (CatCollider2D.IsTouching(playerCollider2D))
        {
            var newPosition = Vector3.Lerp(transform.position, Player.transform.position, Time.time);
            CatRigidbody2D.MovePosition(newPosition);
        }
    }
}