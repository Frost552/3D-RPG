using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleActiveRange : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject playerRef;
    private IEnumerator coroutine;
    public GameObject[] children;
    void Start()
    {
        playerRef = GameObject.FindGameObjectWithTag("Player"); 
    }

    // Update is called once per frame
    void LateUpdate()
    {
        coroutine = WaitAndPrint(2.0f);
        StartCoroutine(coroutine);
    }

    public void SetPlayer(GameObject obj_)
    {
        playerRef = obj_;
    }

   private IEnumerator WaitAndPrint(float f)
    {
        yield return new WaitForSeconds(f);
        if ((playerRef.transform.position - transform.position).magnitude > 50.0f)
        {
            DisableObject();
        }
        if ((playerRef.transform.position - transform.position).magnitude <= 50.0f)
        {
            EnableObject();
        }
       
    }
    private void DisableObject()
    {
        //for (int i = 0; i < children.Length; i++)
        //{
        //    children[i].gameObject.SetActive(false);
        //}
        //GetComponent<SphereCollider>().enabled = false;
    }
    private void EnableObject()
    {
        //for (int i = 0; i < children.Length; i++)
        //{
        //    children[i].gameObject.SetActive(true);
        //}
        
        
        //GetComponent<SphereCollider>().enabled = true;
    }
}
