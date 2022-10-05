using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using Random = System.Random;

public class PlayerController : MonoBehaviour
{
    public List<GameObject> Portals;

    private BoxCollider2D TempCollider;
    private Collider2D PlayerCollider2D;
    private Rigidbody2D PlayerRigidbody2D;

    public TilemapCollider2D WallCollider2D;

    public GameObject TempGameObject;

    public bool isReadyToMove = true;

    private Collision2D LocalCollision2D;

    private CircleMoveController _circleMoveController;

    private void Start()
    {
        PlayerCollider2D = GetComponent<Collider2D>();
        PlayerRigidbody2D = GetComponent<Rigidbody2D>();
        TempCollider = TempGameObject.GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if (LocalCollision2D != null && LocalCollision2D.gameObject.tag.Equals("Portal"))
        {
            var random = new Random();
            var portal = LocalCollision2D.gameObject;
            var copyPortals = Portals.FindAll(p => p.transform.position != portal.transform.position);
            var randomPortal = copyPortals[random.Next(copyPortals.Count)];
            // var randomPortal = copyPortals[];
            // GravityDisableRoutine(randomPortal.transform.position);
            gameObject.SetActive(false);
            gameObject.GetComponent<Rigidbody2D>().isKinematic = true;  
            transform.position = SelectValidPlayerPosition(randomPortal.transform.position);
            gameObject.GetComponent<Rigidbody2D>().isKinematic = false;  
            gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;  
            LocalCollision2D = null;
            gameObject.SetActive(true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (collision2D.gameObject.tag.Equals("Portal") && isReadyToMove)
        {
            isReadyToMove = false;

            LocalCollision2D = collision2D;

            // var random = new Random();
            // var portal = collision2D.gameObject;
            // var copyPortals = Portals.FindAll(p => p.transform.position != portal.transform.position);
            // var randomPortal = copyPortals[random.Next(copyPortals.Count)];
            // var randomPortal = copyPortals[0];

            // StartCoroutine(GravityDisableRoutine(randomPortal.transform.position));
            // GravityDisableRoutine(randomPortal.transform.position);
        }
    }

    public void GravityDisableRoutine(Vector3 portalPosition)
    {
        transform.position = SelectValidPlayerPosition(portalPosition);
        gameObject.SetActive(false);
        // PlayerRigidbody2D.isKinematic = false;
        // yield return new WaitForSeconds(1);
        gameObject.SetActive(true);
        // PlayerRigidbody2D.isKinematic = true;
    }

    private Vector3 SelectValidPlayerPosition(Vector3 portalPosition)
    {
        TempGameObject.transform.position = portalPosition + Vector3.right;
        TempCollider = TempGameObject.GetComponent<BoxCollider2D>();
        if (WallCollider2D.IsTouching(TempCollider))
        {
            Debug.Log($"Is touching");
            return portalPosition + Vector3.left;
        }
        else
        {
            Debug.Log($"Is not touching");
            return portalPosition + Vector3.right;
        }
    }

    private void OnCollisionExit2D(Collision2D collision2D)
    {
        if (collision2D.gameObject.tag.Equals("Portal") && !isReadyToMove)
        {
            isReadyToMove = true;

            // Debug.Log($"Exit collider");
            // Debug.Log($"Move =: {isReadyToMove}");
        }
    }
}