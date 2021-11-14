using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UpdateTargetUI : MonoBehaviour
{
    // Start is called before the first frame update
    // Start is called before the first frame update
    public Text t_name, t_health, t_distance;
    public Slider slide_health;
    public Image spr_image, spr_border, spr_mask;
    CharacterData PlayerTarget;
    GameObject Target;
    CharacterData TargetUIData;
    Color color = Color.white;
    float distance;
    void Start()
    {
        PlayerTarget = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterData>();  
       
    }

    // Update is called once per frame
    void Update()
    {
        SetTarget();
        
        if (TargetUIData != null)
        {
            UpdateHealth();
        }
        else
        {
            slide_health.gameObject.SetActive(false);
            spr_image.enabled = false;
            t_name.enabled = false;
            t_health.enabled = false;
            t_distance.enabled = false;
            spr_border.enabled = false;
            spr_mask.enabled = false;

        }
    }

    private void UpdateHealth()
    {
       slide_health.maxValue = TargetUIData.GetMaxHealth();
       
        t_health.text = TargetUIData.GetHealth().ToString() + "/" + TargetUIData.GetMaxHealth().ToString();
        if (TargetUIData.GetHealth() != 0)
            slide_health.value = TargetUIData.GetHealth();
        if (TargetUIData.GetHealth() == 0)
            slide_health.value = 0;

        t_distance.text = PlayerTarget.GetDistance().ToString();
    }

    private void SetTarget()
    {

        Target = PlayerTarget.GetTarget();
        if (Target != null)
        {
            
            TargetUIData = Target.GetComponent<CharacterData>();
            slide_health.gameObject.SetActive(true);
            spr_image.enabled = true;
            t_name.enabled = true;
            t_health.enabled = true;
            t_distance.enabled = true;
            spr_border.enabled = true;
            spr_mask.enabled = true;
            t_name.text = TargetUIData.GetName();
            spr_image.sprite = TargetUIData.GetSprite();
            spr_image.color = color;
        }
        if(Target == null)
        {
            TargetUIData = null;
        }
    }

}
