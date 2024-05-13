using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvionMovememnt : MonoBehaviour
{
    public float moveSpeed = 0.5f; // Velocidad de movimiento del avi�n
    public float limiteSuperior = 4.5f; // L�mite superior del movimiento del avi�n
    public float limiteInferior = -4.5f; // L�mite inferior del movimiento del avi�n
    public float limiteDerecho = 8f; // L�mite derecho del movimiento del avi�n
    public float limiteIzquierdo = -8f; // L�mite izquierdo del movimiento del avi�n

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

        // Limitar el movimiento del avi�n
        Vector3 posicionActual = transform.position;
        posicionActual.x = Mathf.Clamp(posicionActual.x, limiteIzquierdo, limiteDerecho);
        posicionActual.y = Mathf.Clamp(posicionActual.y, limiteInferior, limiteSuperior);
        transform.position = posicionActual;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Nube"))
        {
            // Aqu� puedes a�adir c�digo para lo que ocurra cuando el avi�n colisiona con una nube
            Debug.Log("�El avi�n choc� con una nube!");
            // Por ejemplo, puedes reiniciar el juego, mostrar un mensaje de game over, etc.
        }
    }

    public void SetMoveSpeed(float newSpeedAdjustment)
    {
        moveSpeed += newSpeedAdjustment;
    }
}

