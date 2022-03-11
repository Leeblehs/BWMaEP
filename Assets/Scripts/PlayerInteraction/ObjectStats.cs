using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ObjectStats : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI nameRef;
    [SerializeField] TextMeshProUGUI infotext1Ref;
    [SerializeField] TextMeshProUGUI infotext2Ref;
    [SerializeField] TextMeshProUGUI infotext3Ref;

    [TextArea(2, 10)] [SerializeField] string thisname;
    [TextArea(2, 10)] [SerializeField] string info1;
    [TextArea(2, 10)] [SerializeField] string info2;
    [TextArea(2, 10)] [SerializeField] string info3;

    public void ShowStats()
    {
        nameRef.text = thisname;
        infotext1Ref.text = info1;
        infotext2Ref.text = info2;
        infotext3Ref.text = info3;
    }

    
}
