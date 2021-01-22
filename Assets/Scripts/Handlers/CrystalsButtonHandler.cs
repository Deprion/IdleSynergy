using UnityEngine;
using UnityEngine.UI;

public class CrystalsButtonHandler : MonoBehaviour
{
    public Button[] Buttons = new Button[8];
    public Text Name, CurrentAmount;
    public GameObject ShopPanel, BottomPanel;
    public Button CreateSmall, CreateLarge, ButtonPrefab;
    public Text[] CrystalsAmount = new Text[8];
    public Sprite[] ImagesArray = new Sprite[8];
    private DataManager dt;
    private GameManager gm;
    private string[] CrystalsNames = new string[]
    {
        "Black Crystal", "Blue Crystal", "Cyan Crystal", "Green Crystal",
        "Pink Crystal", "Red Crystal", "Yellow Crystal", "White Crystal"
    };
    void Start()
    {
        dt = GameObject.FindGameObjectWithTag("GameManager").GetComponent<DataManager>();
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        int yPos = 225;
        for (int i = 0; i < 2; i++)
        {
            yPos -= 150;
            int xPos = -225;
            for (int j = 0; j < 4; j++)
            {
                Button btn = Instantiate(ButtonPrefab, new Vector2(xPos, yPos),
                    Quaternion.identity);
                btn.transform.SetParent(BottomPanel.transform, false);
                CrystalButtonContainer container = btn.GetComponent<CrystalButtonContainer>();
                if (i == 0)
                {
                    btn.GetComponent<Image>().sprite = ImagesArray[j];
                    CrystalsAmount[j] = btn.transform.GetChild(0).GetComponent<Text>();
                    container.Number = j;
                    container.Name = CrystalsNames[j];
                }
                else
                {
                    btn.GetComponent<Image>().sprite = ImagesArray[j + 4];
                    CrystalsAmount[j + 4] = btn.transform.GetChild(0).GetComponent<Text>();
                    container.Number = j + 4;
                    container.Name = CrystalsNames[j + 4];
                }
                btn.onClick.AddListener(delegate 
                {
                    ShowShopMenu(container.Number, container.Name); 
                });
                xPos += 150;
            }
        }
    }
    private void ShowShopMenu(int type, string name)
    {
        Name.text = name;
        CurrentAmount.text = $"Current shards:{dt.SynergyShards[type]}" +
            $"\nCurrent primo:{dt.PrimoCrystal}";

        CreateSmall.onClick.RemoveAllListeners();
        CreateLarge.onClick.RemoveAllListeners();

        CreateSmall.onClick.AddListener(delegate { gm.CreateCrystals(type, 1); });
        CreateLarge.onClick.AddListener(delegate { gm.CreateCrystals(type, 10); });

        ShopPanel.SetActive(true);
    }
}
