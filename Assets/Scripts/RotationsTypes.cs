using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationsTypes : MonoBehaviour
{
    public Transform target;

    private enum TypesRotations { LookRotation, LookAt, RotateTowards, Slerp, AddTorque, MoveRotation, MoveAndRotatePlayer };
    [SerializeField] private TypesRotations actualrotation;
    [SerializeField] private float rotationSpeed= 1f;
    [SerializeField] private float movementSpeed= 1f;

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {

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
       
        switch (actualrotation)
        {
            case TypesRotations.LookRotation:
                RotateWithLookRotation();
                break;
            case TypesRotations.LookAt:
                RotateWithLookAt();
                break;
            case TypesRotations.RotateTowards:
                RotateWithRotateTowards();
                break;
            case TypesRotations.Slerp:
                RotateWithSlerp();
                break;
            case TypesRotations.AddTorque:
                RotateWithAddTorque();
                break;
            case TypesRotations.MoveRotation:
                RotateWithMoveRotation();
                break;
            default:
                MoveAndRotatePlayer();
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

    }

    /// <summary>
    /// Se llama después de que todas las funciones de Update han sido llamadas
    /// Se usa para:
    /// 1. Movimiento de cámara
    /// </summary>
    private void LateUpdate()
    {

    }

    /// <summary>
    /// Rota según una direccion. No una posición. Podemos pasarle un segundo parámetro para indicarle que axis debe considerar como Up
    /// </summary>
    private void RotateWithLookRotation()
    {
        Vector3 direction = target.position - transform.position;
        transform.rotation = Quaternion.LookRotation(direction);
    }

    /// <summary>
    /// Mira hacia una posición en world space. Se le puede indicar su vector up
    /// </summary>
    private void RotateWithLookAt()
    {
        transform.LookAt(target);
    }

    private void RotateWithRotateTowards()
    {
        Vector3 directionToTarget = (target.transform.position - transform.position).normalized;
        Quaternion targetRotation = Quaternion.LookRotation(directionToTarget, transform.up);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
    }

    /// <summary>
    /// significa Interpolacion esférica, es similar a linear interpolation. La diferencia entre los dos es que slerp empezará un poco lento y la mitad irá más rápido) 
    /// </summary>
    private void RotateWithSlerp()
    {
        Vector3 direction = target.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction);

        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
    }

    private void RotateWithAddTorque()
    {
        rb.AddTorque(transform.right * rotationSpeed  *Time.deltaTime);
    }

    private void RotateWithMoveRotation()
    {
        Quaternion deltaRotation = Quaternion.Euler(new Vector3(rotationSpeed,rotationSpeed,rotationSpeed) * Time.deltaTime);
        rb.MoveRotation(rb.rotation * deltaRotation);
    }

    private void MoveAndRotatePlayer()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        //transform.rotation = Quaternion.LookRotation(movement);
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), rotationSpeed);

        transform.Translate(movement * movementSpeed * Time.deltaTime, Space.World);
    }
}
