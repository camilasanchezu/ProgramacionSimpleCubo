using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvionMovememnt : MonoBehaviour
{
    public float moveSpeed = 2f;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveInputVertical = Input.GetAxis("Vertical");
        float moveInputHorizontal = Input.GetAxis("Horizontal");

        // Calcular el vector de movimiento basado en la entrada
        Vector3 moveDirection = new Vector3(moveInputHorizontal, 0f, moveInputVertical);

        // Normalizar el vector para mantener la misma velocidad de movimiento en todas las direcciones
        moveDirection.Normalize();

        // Mover el Rigidbody en la dirección calculada
        rb.MovePosition(rb.position + moveDirection * moveSpeed * Time.fixedDeltaTime);

    }
}

