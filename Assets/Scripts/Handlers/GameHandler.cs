using UnityEngine;
using UnityEngine.UI;

public class GameHandler : MonoBehaviour
{
    public Image RandomShardPrefab;
    public Transform Panel;
    public Sprite[] shardsSprites;
    private Image[] shardsDrop = new Image[11];
    private int currentShardDropped = 0;
    private GameManager gm;
    private void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        for (int i = 0; i < shardsDrop.Length; i++)
        {
            Image obj = Instantiate(RandomShardPrefab, new Vector2(0, 0), Quaternion.identity);
            obj.transform.SetParent(Panel, false);
            obj.gameObject.SetActive(false);
            obj.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            obj.GetComponent<ShardDropContainer>().Determine();
            shardsDrop[i] = obj;
        }
    }
    public void GenerateRandomShardInScene(int type)
    {
        shardsDrop[currentShardDropped].GetComponent<ShardDropContainer>().Drop(shardsSprites[type]);
        currentShardDropped++;
        if (currentShardDropped >= 10) currentShardDropped = 0;
    }
    public void GenerateRandomPrimoInScene()
    {
        shardsDrop[10].GetComponent<ShardDropContainer>().Drop(shardsSprites[8]);
    }
}
