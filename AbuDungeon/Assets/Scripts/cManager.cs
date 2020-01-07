using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cManager : MonoBehaviour
{
    public CharacterController player;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DeleteCameraFollow());
    }
    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
    }

    IEnumerator DeleteCameraFollow()
    {
        yield return new WaitForSeconds(0);
        player = FindObjectOfType<CharacterController>();
    }
}
