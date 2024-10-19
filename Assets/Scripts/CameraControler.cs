using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControler : MonoBehaviour
{
    public float cameraSpeed = 10f; // Velocidad de movimiento de la c�mara
    public float edgeSize = 10f;    // Tama�o del borde en p�xeles donde se detecta el mouse
    public float maxX = 50f;        // L�mite en el eje X de la c�mara
    public float maxY = 50f;        // L�mite en el eje Y de la c�mara
    public float minX = -50f;       // L�mite en el eje X en sentido negativo
    public float minY = -50f;       // L�mite en el eje Y en sentido negativo

    void Update()
    {
        if (LevelManager.instance.editorMode)
        {
            Vector3 pos = transform.position;

            // Obtiene la posici�n del mouse en la pantalla
            Vector3 mousePos = Input.mousePosition;

            // Si el mouse est� cerca del borde izquierdo
            if (mousePos.x <= edgeSize)
            {
                pos.x -= cameraSpeed * Time.deltaTime;
            }
            // Si el mouse est� cerca del borde derecho
            if (mousePos.x >= Screen.width - edgeSize)
            {
                pos.x += cameraSpeed * Time.deltaTime;
            }
            // Si el mouse est� cerca del borde inferior
            if (mousePos.y <= edgeSize)
            {
                pos.y -= cameraSpeed * Time.deltaTime; // Cambiado a eje Y
            }
            // Si el mouse est� cerca del borde superior
            if (mousePos.y >= Screen.height - edgeSize)
            {
                pos.y += cameraSpeed * Time.deltaTime; // Cambiado a eje Y
            }

            // Limita el movimiento de la c�mara dentro de los valores m�ximos y m�nimos
            pos.x = Mathf.Clamp(pos.x, minX, maxX);
            pos.y = Mathf.Clamp(pos.y, minY, maxY);

            // Actualiza la posici�n de la c�mara
            transform.position = pos;
        }
       
    }
}
