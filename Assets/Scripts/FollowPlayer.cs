using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    // Velocidade de movimentação, quanto maior, mais rápido
    public float velocidade = 3.0f;

    // Player em cena
    public Transform player;

    // Distância adicional do player
    [Space(10)] public Vector3 offset = Vector3.up;

    [Space(15)] public float[] xClamp = new float[2];

    public float[] yClamp = new float[2];

    // Update is called once per frame
    void Update()
    {
        // Cria uma nova variável e adiciona a posição do player a ela
        Vector3 playerPosition = player.position;

        // Obtém a posição em X
        float posX = Mathf.Clamp(playerPosition.x, xClamp[0], xClamp[1]);

        // Obtém a posição em Y
        float posY = Mathf.Clamp(playerPosition.y, yClamp[0], yClamp[1]);

        // Movimenta a cãmera suavemente até a posição do player
        transform.position = Vector3.Lerp(
            transform.position, // Posição atual
            new Vector3(posX, posY, -10f) + offset, // Nova posição com o espaço
            velocidade * Time.deltaTime
        );

        // transform.position = new Vector3(playerPosition.x, playerPosition.y, -10f);

        Debug.Log($"Position camera: {transform.position}");
    }
}