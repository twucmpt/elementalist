using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.Linq;


public class SameFontSize : MonoBehaviour
{
    public List<TextMeshProUGUI> texts = new List<TextMeshProUGUI>();
    public List<TextMeshProUGUI> sizeRefs = new List<TextMeshProUGUI>();

    void Update()
    {
        float minSize = sizeRefs.Min(text => text.fontSize);
        foreach (TextMeshProUGUI text in texts) {
            text.fontSize = minSize;
        }
    }
}
