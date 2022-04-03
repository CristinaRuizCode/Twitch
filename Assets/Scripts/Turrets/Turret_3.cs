using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret_3 : MonoBehaviour
{
    [SerializeField] float rotationSpeed;
    Transform player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag(Constants.TAG_PLAYER).transform;
    }
    // Update is called once per frame
    void Update()
    {
        RotateWithSlerp();
    }

    /// <summary>
    /// significa Interpolacion esférica, es similar a linear interpolation. La diferencia entre los dos es que slerp empezará un poco lento y la mitad irá más rápido) 
    /// </summary>
    private void RotateWithSlerp()
    {
        Vector3 direction = player.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction);

        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
    }
}
