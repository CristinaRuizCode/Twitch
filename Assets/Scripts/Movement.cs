using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    /* Time.deltaTime > Es el intervalo de tiempo entre el anterior frame y el actual (Dos llamadas a Update)
     * Podemos movernos por ejemplo a 1 metro por segundo
     *  Cuando se utiliza dentro de FixedUpdate devuelve Time.fixedDeltaTime
     */

    /* Time.fixedDeltaTime > Dos llamadas a FixedUpdate. El tiempo de llamada a este método está definido.
     */


    /// <summary>
    /// transformSetPosition > Damos una nueva posicion
    /// transformTranslate > Damos una cantidad de movimiento
    /// rigidbodyForce > Añadimos una fuerza en una dirección
    /// rigidbodyMovePosition > Damos una nueva posicion
    /// rigidbodySetVelocity > 
    /// </summary>
    private enum TypesMovement { transformSetPosition, transformTranslate, rigidbodyForce, rigidbodyMovePosition, rigidbodySetVelocity};
    [SerializeField] private TypesMovement actualMovement;
    [SerializeField] private float speed;

    private Rigidbody rb;

    /// <summary>
    /// Se llama automaticamente al iniciar. Aunque el script esté desactivado
    /// Solo se activa una vez. Si desactivas y activas el script, no se volverá a llamar
    /// Se utiliza para inicializar variables y declarar referencias entre los scripts
    /// </summary>
    private void Awake()
    {
        //Debug.Log("Estamos en Awake");
        rb = GetComponent<Rigidbody>();
    }

    /// <summary>
    /// Se llama al terminar el Awake o activar el script
    /// Se usa para inicializar funciones
    /// Solo se activa una vez. Si desactivas y activas el script, no se volverá a llamar
    /// Se utiliza 
    /// </summary>
    void Start()
    {
       // Debug.Log("Estamos en Start");
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
        switch (actualMovement)
        {
            case TypesMovement.transformSetPosition:
                MoveWithTransformPosition();
                break;
            case TypesMovement.transformTranslate:
                MoveWithTransformTranslate();
                break;
        }
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

        switch (actualMovement)
        {
            case TypesMovement.rigidbodyForce:
                MoveWithRBForce();
                break;
            case TypesMovement.rigidbodyMovePosition:
                MoveWithRBMovePosition();
                break;
            case TypesMovement.rigidbodySetVelocity:
                MoveWithRBSetVelocity();
                break;
        }
    }

    /// <summary>
    /// Se llama después de que todas las funciones de Update han sido llamadas
    /// Se usa para:
    /// 1. Movimiento de cámara
    /// </summary>
    private void LateUpdate()
    {

    }


    private void MoveWithTransformPosition()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += Vector3.forward * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.position += Vector3.back * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            transform.position += new Vector3(0,1f,0) * speed * Time.deltaTime;
        }
    }

    private void MoveWithTransformTranslate()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            transform.Translate(new Vector3(0,1f,0) * speed * Time.deltaTime);
        }
    }

    private void MoveWithRBForce()
    {
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(speed * Vector3.right);
        }
        
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(speed * Vector3.left);
        }
        
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(speed * Vector3.forward);
        }

        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(speed * Vector3.back);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(speed * Vector3.up);
        }
    }

    private void MoveWithRBMovePosition()
    {
        if (Input.GetKey(KeyCode.D))
        {
            rb.MovePosition(transform.position + (speed * Vector3.right));
        }
        
        if (Input.GetKey(KeyCode.A))
        {
            rb.MovePosition(transform.position + (speed * Vector3.left));
        }
        
        if (Input.GetKey(KeyCode.W))
        {
            rb.MovePosition(transform.position + (speed * Vector3.forward));
        }

        if (Input.GetKey(KeyCode.S))
        {
            rb.MovePosition(transform.position + (speed * Vector3.back));
        }

        if (Input.GetKey(KeyCode.Space))
        {
            rb.MovePosition(transform.position + (speed * Vector3.up));
        }
    }

    private void MoveWithRBSetVelocity()
    {
        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = transform.right * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = -transform.right * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.W))
        {
            rb.velocity = transform.forward * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.S))
        {
            rb.velocity = -transform.forward * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            rb.velocity = Vector3.up * speed * Time.deltaTime;
        }
    }

    /// <summary>
    /// Se llama cuando se activa el script
    /// </summary>
    private void OnEnable()
    {
        //Debug.Log("Estamos en onEnable");
    }

    /// <summary>
    /// Se llama cuando se desactiva el script
    /// </summary>
    private void OnDisable()
    {
       // Debug.Log("Estamos en onDisable");
    }
}
