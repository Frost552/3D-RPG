using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UpdatePlayerUI : MonoBehaviour
{
    // Start is called before the first frame update
    public Text t_name, t_health, t_exp, t_level;
    public Slider slide_health, slider_exp;
    public Image spr_image;
    CharacterData uiData;
    void Start()
    {
        uiData = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterData>();
        t_name.text = uiData.GetName();
        spr_image.sprite = uiData.GetSprite();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateUI();
    }

    private void UpdateUI()
    {
        t_level.text = uiData.GetLevel().ToString();
        t_exp.text = uiData.GetExp().ToString() + "/" + uiData.GetExpToNext().ToString();
        slide_health.maxValue = uiData.GetMaxHealth();
        slider_exp.maxValue = uiData.GetExpToNext();
        slider_exp.value = uiData.GetExp();
        t_health.text = uiData.GetHealth().ToString() + "/" + uiData.GetMaxHealth().ToString();
        if(uiData.GetHealth() != 0)
        slide_health.value = uiData.GetHealth();
        if (uiData.GetHealth() == 0)
            slide_health.value = 0;
    }

}
