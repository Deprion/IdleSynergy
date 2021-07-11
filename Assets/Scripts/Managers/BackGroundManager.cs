using UnityEngine;
using UnityEngine.UI;

public class BackGroundManager : MonoBehaviour
{
    public GameObject ClickSynergyObj;
    private Image image;
    private byte R = 200, G = 242, B = 255;
    private int index = 0;
    [SerializeField]
    private Color32[] arrayOfColors;
    private void Start()
    {
        image = ClickSynergyObj.GetComponent<Image>();
        image.color = new Color32(R, G, B, 255);
    }

    void Update()
    {
        image.color = Color32.Lerp(image.color, arrayOfColors[index], 2 * Time.deltaTime);
        if (image.color == arrayOfColors[index])
        {
            index = ++index >= arrayOfColors.Length ? 0 : index;
            print(index);
        }
    }
}
