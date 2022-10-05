using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishPhase : MonoBehaviour
{
    public Transform player;
    public Transform Cat;

    void Update()
    {
            float playerDist = Vector3.Distance(player.position, transform.position);
            float catDist = Vector3.Distance(Cat.position, transform.position);
            if (playerDist < 0.7 && catDist < 0.7)
            {
                SceneManager.LoadScene("GameOver");
            }
    }
}
