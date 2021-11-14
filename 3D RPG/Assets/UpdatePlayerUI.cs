using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UpdatePlayerUI : MonoBehaviour
{
    // Start is called before the first frame update
    public Text t_name, t_health;
    public Slider slide_health;
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
        UpdateHealth();
    }

    private void UpdateHealth()
    {
        slide_health.maxValue = uiData.GetMaxHealth();
        t_health.text = uiData.GetHealth().ToString() + "/" + uiData.GetMaxHealth().ToString();
        if(uiData.GetHealth() != 0)
        slide_health.value = uiData.GetHealth();
        if (uiData.GetHealth() == 0)
            slide_health.value = 0;
    }

}
