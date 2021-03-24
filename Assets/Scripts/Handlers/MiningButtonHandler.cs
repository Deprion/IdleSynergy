using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiningButtonHandler : MonoBehaviour
{
    public GameObject WorldButtonPrefab;
    public GameObject LevelUpPrefab;
    public GameObject PanelParent;
    private GameObject[] CavePreset = new GameObject[10];
    private GameObject[] DrillPreset = new GameObject[6];
    private GameObject[] PickaxePreset = new GameObject[6];
    private MineManager mm;
    private Sprite[] spriteArray;
    private void Start()
    {
        mm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<MineManager>();
        spriteArray = Resources.LoadAll<Sprite>("Images");
        List<GameObject> tempListCave = new List<GameObject>();
        List<GameObject> tempListDrill = new List<GameObject>();
        List<GameObject> tempListPickaxe = new List<GameObject>();
        int y = 300;
        byte tempCount = 0;
        for (int i = 0; i < 3; i++)
        {
            int x = -175;
            for (int j = 0; j < 3; j++)
            {
                tempListCave.Add(CreateButton(x, y, tempCount, WorldButtonPrefab, true));
                tempCount++;
                x += 175;
            }
            y -= 175;
        }
        tempListCave.Add(CreateButton(0, y, tempCount, WorldButtonPrefab, true));
        CavePreset = tempListCave.ToArray();
        y = 300;
        for (int i = 0; i < 6; i++)
        {
            tempListDrill.Add(CreateButton(0, y, tempCount, LevelUpPrefab, false));
            tempListPickaxe.Add(CreateButton(0, y, tempCount, LevelUpPrefab, false));
        }
        DrillPreset = tempListDrill.ToArray();
        PickaxePreset = tempListPickaxe.ToArray();
    }
    private GameObject CreateButton(int x, int y, byte tempC, GameObject prefab, bool IsMatrix)
    {
        if (IsMatrix)
        {
            GameObject obj = Instantiate(prefab,
                        new Vector2(x, y), Quaternion.identity);
            obj.transform.SetParent(PanelParent.transform, false);
            obj.SetActive(false);
            obj.GetComponent<Image>().sprite = spriteArray[tempC];
            obj.GetComponent<Button>().onClick.AddListener( () => mm.ChangeWorld(tempC));
            return obj;
        }
        else
        {
            GameObject obj = Instantiate(prefab,
                        new Vector2(x, y), Quaternion.identity);
            obj.transform.SetParent(PanelParent.transform, false);
            obj.SetActive(false);
            return obj;
        }
    }
    private void SetArray(GameObject[] array, bool OnOrOff)
    {
        switch (OnOrOff)
        {
            case true:
                {
                    for (int i = 0; i < array.Length; i++)
                    {
                        array[i].SetActive(true);
                    }
                }
                break;
            case false:
                {
                    {
                        for (int i = 0; i < array.Length; i++)
                        {
                            array[i].SetActive(false);
                        }
                    }
                }
                break;
        }
    }
    public void OpenCavePreset()
    {
        SetArray(DrillPreset, false);
        SetArray(PickaxePreset, false);
        SetArray(CavePreset, true);
        PanelParent.SetActive(!PanelParent.activeSelf);
    }
    public void OpenDrillPreset()
    {
        SetArray(CavePreset, false);
        SetArray(PickaxePreset, false);
        SetArray(DrillPreset, true);
        PanelParent.SetActive(!PanelParent.activeSelf);
    }
    public void OpenPickaxePreset()
    {
        SetArray(CavePreset, false);
        SetArray(DrillPreset, false);
        SetArray(PickaxePreset, true);
        PanelParent.SetActive(!PanelParent.activeSelf);
    }
}
