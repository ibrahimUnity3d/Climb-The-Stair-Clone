using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorLerp : MonoBehaviour {

    public Color DefaultColor;
    public Color SpreadColor;

    private MaterialPropertyBlock _matBlock;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {     
            allowed = !allowed;
            _matBlock.SetColor("_SpreadColor", SpreadColor);
        }

        if (allowed)
        {
            rend.GetPropertyBlock(_matBlock);
            lerp();
        }
    }

    public bool allowed = false;

    [SerializeField]
    float speed = 1.5f;

    [Range(-1,1)]
    public float LerpTo = 1;

    [Range(0,1)]
    public float ResetTo = 0;

    private Renderer rend;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        _matBlock = new MaterialPropertyBlock();
        rend.GetPropertyBlock(_matBlock);
        _matBlock.SetColor("_SpreadColor", SpreadColor);
        _matBlock.SetColor("_DefaultColor", DefaultColor);
        _matBlock.SetFloat("_Occupy", ResetTo);
        rend.SetPropertyBlock(_matBlock);

       // SetColorForChild_Splat(SpreadColor);
    }

    private void SetColorForChild_Splat(Color color)
    {
        Renderer ren = transform.GetChild(0).GetComponent<Renderer>();
        MaterialPropertyBlock m = new MaterialPropertyBlock();
        ren.GetPropertyBlock(m);
        m.SetColor("_TintColor", color);
        ren.SetPropertyBlock(m);
    }

    private void ResetColor()
    {
        _matBlock.SetFloat("_Occupy", ResetTo);
    }

    private void lerp()
    {
        float iniVal = _matBlock.GetFloat("_Occupy");
        if (iniVal != LerpTo)
        {
            float finalVal = Mathf.Lerp(iniVal, LerpTo, Time.smoothDeltaTime * speed);
            _matBlock.SetFloat("_Occupy", finalVal);
            rend.SetPropertyBlock(_matBlock);
        }
    }
}
