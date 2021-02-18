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
    private DataManager dt;
    private MineManager mm;
    private CrystalsButtonHandler cbh;
    private void Start()
    {
        dt = GameObject.FindGameObjectWithTag("GameManager").GetComponent<DataManager>();
        mm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<MineManager>();
        cbh = GetComponent<CrystalsButtonHandler>();
        List<GameObject> tempListCave = new List<GameObject>();
        List<GameObject> tempListDrill = new List<GameObject>();
        List<GameObject> tempListPickaxe = new List<GameObject>();
        int y = 300;
        for (int i = 0; i < 3; i++)
        {
            int x = -175;
            for (int j = 0; j < 3; j++)
            {
                tempListCave.Add(CreateButton(x, y, WorldButtonPrefab, true));
                x += 175;
            }
            y -= 175;
        }
        tempListCave.Add(CreateButton(0, y, WorldButtonPrefab, true));
        CavePreset = tempListCave.ToArray();
        y = 300;
        for (int i = 0; i < 6; i++)
        {
            tempListDrill.Add(CreateButton(0, y, LevelUpPrefab, false));
            tempListPickaxe.Add(CreateButton(0, y, LevelUpPrefab, false));
        }
    }
    private GameObject CreateButton(int x, int y, GameObject prefab, bool IsMatrix)
    {
        if (IsMatrix)
        {
            GameObject obj = Instantiate(prefab,
                        new Vector2(x, y), Quaternion.identity);
            obj.transform.SetParent(PanelParent.transform, false);
            obj.SetActive(false);
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
    private void OpenLocation(byte id)
    {
        
    }
}
