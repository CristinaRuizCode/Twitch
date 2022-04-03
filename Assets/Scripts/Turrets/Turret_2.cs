using UnityEngine;

public class Turret_2 : MonoBehaviour
{
    [SerializeField]
    [Range(0f, 90f)]
    float clampRotXNegative = 0f, clampRotXPositive = 90f;

    Transform player;

    [SerializeField] 
    [Tooltip("La cabeza de la torreta")] 
    Transform head;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag(Constants.TAG_PLAYER).transform;
    }

    // Update is called once per frame
    void Update()
    {
        LookPlayer();
    }

    /// <summary>
    /// Método que sirve para mirar al jugador
    /// </summary>
    private void LookPlayer()
    {
        Vector3 lookDir = player.position - transform.position;
        lookDir.y = 0f;
        head.rotation = Quaternion.LookRotation(lookDir);
    }
}
