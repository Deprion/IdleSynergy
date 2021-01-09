using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class DataManager : MonoBehaviour
{
//test
    public long Synergy, SynergyOnClick, 
        PrimoCrystal, UniversalCrystal, UniversalShard, Gems,
        MiningPower, MiningLvl, MiningExp, CostSynergy;
    public long[] SynergyCrystals;
    public long[] SynergyShards;
    public float[] CostSynergyCrystals;
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
            universalShard, gems, miningPower, miningLvl, miningExp, costSynergy;
        public long[] synergyCrystals, synergyShards;
        public float[] costSynergyCrystals;
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
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.OpenRead(DataPath);
            Data data = (Data)bf.Deserialize(file);
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
            SynergyCrystals = data.synergyCrystals;
            SynergyShards = data.synergyShards;
            CostSynergyCrystals = data.costSynergyCrystals;
            FreeChest = data.freeChestTimeLeft;
            PastTime = DateTime.Now;
            file.Close();
        }
        else 
        {
            SynergyOnClick = 1;
            MiningPower = 1;
            CostSynergy = 10;
            CostSynergyCrystals = new float[] { 10, 10, 10, 10, 10, 10, 10, 10 };
            FreeChest = DateTime.Now.AddMinutes(30);
        }
    }
    public void SaveData()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(DataPath, FileMode.OpenOrCreate);
        Data data = new Data(this);
        bf.Serialize(file, data);
        file.Close();
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
