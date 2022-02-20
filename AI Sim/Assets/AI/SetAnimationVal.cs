using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetAnimationVal : MonoBehaviour
{
    // Start is called before the first frame update
    Animator anim;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void SetAnim(string s, bool b)
    {
        anim.SetBool(s, b);
    }
    public void SetAnim(string s, int i)
    {
        anim.SetInteger(s, i);
    }
    public void SetAnim(string s, float f)
    {
        anim.SetFloat(s, f);
    }
    
}
