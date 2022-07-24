using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PopUpWithDotween : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var myScale = transform.localScale;
        transform.localScale = Vector3.zero;

        transform.DOScale(myScale, 1);
    }
}
