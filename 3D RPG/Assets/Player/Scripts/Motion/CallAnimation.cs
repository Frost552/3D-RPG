using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetAnimation(string anim_, bool b_)//takes a bool
    {
        anim.SetBool(anim_, b_);
    }
    public void SetAnimation(string anim_, int i_)//takes an Int
    {
        anim.SetInteger(anim_, i_);
    }
    public void SetAnimation(string anim_, float f_)//takes a float
    {
        anim.SetFloat(anim_, f_);
    }
}
