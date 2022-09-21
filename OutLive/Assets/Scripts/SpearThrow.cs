using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearThrow : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            StartCoroutine(spearDelay());            

        }

    }

    IEnumerator spearDelay()
    {
        yield return new WaitForSeconds(1.5f);
        Vector3 lionPosi = player.transform.position;
        Vector3 relativePosi = new Vector3(0f, 13.0f, 10.0f);
        transform.position = (lionPosi + relativePosi);
        gameObject.GetComponent<Rigidbody>().useGravity = true;
    }

 
}
