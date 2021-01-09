using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ShardDropContainer : MonoBehaviour
{
    private Rigidbody2D rigid;
    private bool statusInActive = false;
    public void Determine()
    {
        rigid = GetComponent<Rigidbody2D>();
    }
    public void Drop(Sprite spr)
    {
        if (!statusInActive)
        {
            transform.localPosition = new Vector2(Random.Range(-200, 201), Random.Range(-200, 201));
            rigid.bodyType = RigidbodyType2D.Dynamic;
            rigid.AddForce(new Vector2(Random.Range(-200, 201), Random.Range(-200, 201)));
            GetComponent<Image>().sprite = spr;
            gameObject.SetActive(true);
            statusInActive = true;
            StartCoroutine(timeToOff());
        }
        else
        {
            StopCoroutine(timeToOff());
            Off();
            statusInActive = false;
            Drop(spr);
        }
    }
    private void Off()
    {
        gameObject.SetActive(false);
        rigid.bodyType = RigidbodyType2D.Static;
        statusInActive = false;
    }
    IEnumerator timeToOff()
    {
        yield return new WaitForSeconds(4.0f);
        Off();
    }
}
