using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret_1 : MonoBehaviour
{
    Transform player;

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

    private void LookPlayer()
    {
        Vector3 targetPosition = new Vector3(player.position.x, transform.position.y, player.position.z);

        transform.LookAt(targetPosition);
    }
}
