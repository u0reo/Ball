using UnityEngine;
using System.Collections;

public class light : MonoBehaviour {
    public GameObject player;

    // Use this for initialization
    void Start () {
    }

    // Update is called once per frame
    void Update () {
        transform.position = new Vector3(player.transform.position.x,player.transform.position.y + 3, player.transform.position.z);

        /*if (player.transform.position.x <= -5.0 && player.transform.position.z <= -2.0)
        {
            transform.position = new Vector3(-5, 5, -2);
        }

        if (player.transform.position.x <= -5.0 && player.transform.position.z >= 2.0)
        {
            transform.position = new Vector3(-5, 5, 2);
        }

        if (player.transform.position.x >= 5.0 && player.transform.position.z <= -2.0)
        {
            transform.position = new Vector3(5, 5, -2);
        }
        if (player.transform.position.x >= 5.0 && player.transform.position.z >= 2.0)
        {
            transform.position = new Vector3(5, 5, 2);
        }

        if (player.transform.position.z >= 2.0 & transform.position.x <= 5.0 & transform.position.x >= -5.0)
        {
             transform.position = new Vector3(player.transform.position.x, 5, 2);
        }

        if (player.transform.position.z <= -2.0 & transform.position.x <= 5.0 & transform.position.x >= -5.0)
        {
            transform.position = new Vector3(player.transform.position.x, 5, -2);
        }

        if (player.transform.position.x >= 5.0 & transform.position.z <= 2.0 & transform.position.z >= -2.0)
        {
            transform.position = new Vector3(5, 5, player.transform.position.z);
        }

        if (player.transform.position.x <= -5.0 & transform.position.z <= 2.0 & transform.position.z >= -2.0)
        {
            transform.position = new Vector3(-5, 5, player.transform.position.z);
        }*/

    }
}
