using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearUp : MonoBehaviour
{
    
    private Vector3 initialPosi = new Vector3(0f, -2.54f,1.21f);
    public Animator anim;
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.K))
        {
                        
            anim.SetBool("state", true);
            StartCoroutine(spearRestart());
                        
        }

    }

    IEnumerator spearRestart()
    {
        yield return new WaitForSeconds(2f);
        anim.SetBool("state", false);
    }
}
