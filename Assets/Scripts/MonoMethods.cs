
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoMethods : MonoBehaviour
{
    /// <summary>
    /// Se llama automaticamente al iniciar. Aunque el script esté desactivado-
    /// Solo se activa una vez. Si desactivas y activas el script, no se volverá a llamar
    /// Se utiliza para inicializar variables y declarar referencias entre los scripts
    /// </summary>
    private void Awake()
    {
        //Debug.Log("Estamos en Awake");
    }

    /// <summary>
    /// Se llama al terminar el Awake o activar el script
    /// Se usa para inicializar funciones
    /// Solo se activa una vez. Si desactivas y activas el script, no se volverá a llamar
    /// Se utiliza 
    /// </summary>
    void Start()
    {
        //Debug.Log("Estamos en Start");
    }

    /// <summary>
    /// PARTE LÓGICA
    /// Se llama a Update en cada frame.
    /// Se usa para:
    /// 1. Movimiento sin fisicas
    /// 2. Recibir inputs del jugador
    /// </summary>
    void Update()
    {
      //Debug.Log("Llamando a UPDATE");
    }

    /// <summary>
    /// PARTE FÍSICA
    /// Se llama en intervalos de tiempo regulares. (Editable en Project Settings > Time)
    /// Se usa para:
    /// 1. Movimiento con físicas
    /// 2. Físicas en general
    /// 3. Control de tiempo
    /// 4. Animaciones
    /// </summary>
    private void FixedUpdate()
    {
        //Debug.Log("Llamando a FIXEDUPDATE");
    }

    /// <summary>
    /// Se llama después de que todas las funciones de Update han sido llamadas
    /// Se usa para:
    /// 1. Movimiento de cámara
    /// </summary>
    private void LateUpdate()
    {
        //Debug.Log("Llamando a LATEUPDATE");
    }

    /// <summary>
    /// Se llama cuando se activa el script
    /// </summary>
    private void OnEnable()
    {
        Debug.Log("Estamos en onEnable");

    }

    /// <summary>
    /// Se llama cuando se desactiva el script
    /// </summary>
    private void OnDisable()
    {
        Debug.Log("Estamos en onDisable");
    }
}
