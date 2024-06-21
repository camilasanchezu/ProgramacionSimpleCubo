using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMovement : MonoBehaviour
{
    public float moveSpeed = 0.5f; // Velocidad de movimiento de la nube
    public float moveRange = 2.0f;

    private Vector3 startPos;

    void Start()
    {
        // Guardar la posición inicial de la nube
        startPos = transform.position;
    }

    void Update()
    {
        // Calcular el nuevo desplazamiento basado en el tiempo
        float newX = startPos.x + Mathf.Sin(Time.time * moveSpeed) * moveRange;

        // Aplicar el nuevo desplazamiento a la posición de la nube
        transform.position = new Vector3(newX, startPos.y, startPos.z);
    }


}
