using UnityEngine;
using System;
using System.IO;

public class DataManager : MonoBehaviour
{
    public long Synergy, SynergyOnClick, 
        PrimoCrystal, UniversalCrystal, UniversalShard, Gems,
        MiningPower, MiningLvl, CostSynergy, DroppedShards;
    public llong MiningExp = new llong(0, 10);
    public long[] SynergyCrystals;
    public long[] SynergyShards;
    public long[] CostSynergyCrystals;
    public DateTime FreeChest, PastTime;
    private string DataPath;
    private void Awake()
    {
        DataPath = Application.persistentDataPath + "/Data.json";
        LoadData();
    }
    [Serializable]
    private class Data
    {
        public long synergy, synergyOnClick, primoCrystal, universalCrystal,
            universalShard, gems, miningPower, miningLvl, costSynergy, droppedShards;
        public llong miningExp;
        public long[] synergyCrystals, synergyShards;
        public long[] costSynergyCrystals;
        public DateTime pastTime, freeChestTimeLeft;
        public Data(DataManager dt) 
        {
            synergy = dt.Synergy;
            synergyOnClick = dt.SynergyOnClick;
            primoCrystal = dt.PrimoCrystal;
            universalCrystal = dt.UniversalCrystal;
            universalShard = dt.UniversalShard;
            gems = dt.Gems;
            miningPower = dt.MiningPower;
            miningLvl = dt.MiningLvl;
            miningExp = dt.MiningExp;
            costSynergy = dt.CostSynergy;
            droppedShards = dt.DroppedShards;
            synergyCrystals = dt.SynergyCrystals;
            synergyShards = dt.SynergyShards;
            costSynergyCrystals = dt.CostSynergyCrystals;
            freeChestTimeLeft = dt.FreeChest;
            pastTime = DateTime.Now;
        }
    }
    private void LoadData()
    {
        if (File.Exists(DataPath))
        {
            Data data = JsonUtility.FromJson<Data>(File.ReadAllText(DataPath));
            Synergy = data.synergy;
            SynergyOnClick = data.synergyOnClick;
            PrimoCrystal = data.primoCrystal;
            UniversalCrystal = data.universalCrystal;
            UniversalShard = data.universalShard;
            Gems = data.gems;
            MiningPower = data.miningPower;
            MiningLvl = data.miningLvl;
            MiningExp = data.miningExp;
            CostSynergy = data.costSynergy;
            DroppedShards = data.droppedShards;
            SynergyCrystals = data.synergyCrystals;
            SynergyShards = data.synergyShards;
            CostSynergyCrystals = data.costSynergyCrystals;
            FreeChest = data.freeChestTimeLeft;
            PastTime = DateTime.Now;
        }
        else 
        {
            SynergyOnClick = 1;
            MiningPower = 1;
            CostSynergy = 10;
            CostSynergyCrystals = new long[] { 10, 10, 10, 10, 10, 10, 10, 10 };
            FreeChest = DateTime.Now.AddMinutes(30);
        }
    }
    public void SaveData()
    {
        Data data = new Data(this);
        File.WriteAllText(DataPath, JsonUtility.ToJson(data));
    }
    private void OnApplicationFocus(bool focus)
    {
        SaveData();
    }
    private void OnApplicationQuit()
    {
        SaveData();
    }
}
