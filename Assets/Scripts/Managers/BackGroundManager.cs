using UnityEngine;
using UnityEngine.UI;

public class BackGroundManager : MonoBehaviour
{
    public GameObject ClickSynergyObj;
    private Image image;
    private byte R = 200, G = 242, B = 255;
    private bool check = true;
    private float waitTime = 0.2f;
    private void Start()
    {
        image = ClickSynergyObj.GetComponent<Image>();
        image.color = new Color32(R, G, B, 255);
    }

    void Update()
    {
        if (SidePanelManager.state == SidePanelManager.currentState.middle)
        {
            waitTime -= Time.deltaTime;
            if (waitTime <= 0)
            {
                if (check)
                {
                    R--;
                    G--;
                    B--;
                    if (R <= 100) check = false;
                }
                else
                {
                    R++;
                    G++;
                    B++;
                    if (R >= 200) check = true;
                }
                waitTime = 0.2f;
            }
            image.color = new Color32(R, G, B, 255);
        }
    }
}
