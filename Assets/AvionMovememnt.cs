using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvionMovememnt : MonoBehaviour
{
    public float moveSpeed = 0.5f; // Velocidad de movimiento del avión
    public float limiteSuperior = 4.5f; // Límite superior del movimiento del avión
    public float limiteInferior = -4.5f; // Límite inferior del movimiento del avión
    public float limiteDerecho = 8f; // Límite derecho del movimiento del avión
    public float limiteIzquierdo = -8f; // Límite izquierdo del movimiento del avión

    private void Update()
    {
        // Movimiento horizontal
        float moveInputHorizontal = Input.GetAxis("Horizontal");
        float moveHorizontal = moveInputHorizontal * moveSpeed * Time.deltaTime;
        transform.Translate(Vector3.right * moveHorizontal);

        // Movimiento vertical
        float moveInputVertical = Input.GetAxis("Vertical");
        float moveVertical = moveInputVertical * moveSpeed * Time.deltaTime;
        transform.Translate(Vector3.up * moveVertical);

        // Movimiento hacia adelante
        float moveForward = moveSpeed * Time.deltaTime;
        transform.Translate(Vector3.forward * moveForward);

        // Limitar el movimiento del avión
        Vector3 posicionActual = transform.position;
        posicionActual.x = Mathf.Clamp(posicionActual.x, limiteIzquierdo, limiteDerecho);
        posicionActual.y = Mathf.Clamp(posicionActual.y, limiteInferior, limiteSuperior);
        transform.position = posicionActual;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Nube"))
        {
            // Aquí puedes añadir código para lo que ocurra cuando el avión colisiona con una nube
            Debug.Log("¡El avión chocó con una nube!");
            // Por ejemplo, puedes reiniciar el juego, mostrar un mensaje de game over, etc.
        }
    }

    public void SetMoveSpeed(float newSpeedAdjustment)
    {
        moveSpeed += newSpeedAdjustment;
    }
}

