using UnityEngine;

public class SidePanelManager : MonoBehaviour
{
    public RectTransform LeftPanel, RightPanel;
    private Vector2 leftTarget, rightTarget;
    private float speed = 3000;
    public static currentState state = new currentState();
    public enum currentState
    {
        middle,
        left,
        right
    }
    void Start()
    {
        leftTarget = LeftPanel.anchoredPosition;
        rightTarget = RightPanel.anchoredPosition;
        state = currentState.middle;
    }
    void Update()
    {
        MoveMenu();
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (state == currentState.middle)
            {
                state = currentState.right;
                rightTarget = new Vector2(-RightPanel.sizeDelta.x / 2,
                    RightPanel.anchoredPosition.y);
                leftTarget = new Vector2(-LeftPanel.sizeDelta.x / 2,
                    LeftPanel.anchoredPosition.y);
            }
            else if (state == currentState.left)
            {
                state = currentState.middle;
                leftTarget = new Vector2(-LeftPanel.sizeDelta.x / 2,
                    LeftPanel.anchoredPosition.y);
                rightTarget = new Vector2(RightPanel.sizeDelta.x / 2,
                    RightPanel.anchoredPosition.y);
            }
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (state == currentState.middle)
            {
                state = currentState.left;
                leftTarget = new Vector2(LeftPanel.sizeDelta.x / 2,
                    LeftPanel.anchoredPosition.y);
                rightTarget = new Vector2(RightPanel.sizeDelta.x / 2,
                    RightPanel.anchoredPosition.y);
            }
            else if (state == currentState.right)
            {
                state = currentState.middle;
                leftTarget = new Vector2(-LeftPanel.sizeDelta.x / 2,
                    LeftPanel.anchoredPosition.y);
                rightTarget = new Vector2(RightPanel.sizeDelta.x / 2,
                    RightPanel.anchoredPosition.y);
            }
        }
#endif
#if UNITY_ANDROID
        if (Input.touchCount > 0)
        {
            Touch touch = Input.touches[0];
            if (touch.deltaPosition.x > 75)
            {
                if (state == currentState.middle)
                {
                    state = currentState.right;
                    rightTarget = new Vector2(-RightPanel.sizeDelta.x / 2,
                        RightPanel.anchoredPosition.y);
                    leftTarget = new Vector2(-LeftPanel.sizeDelta.x / 2,
                        LeftPanel.anchoredPosition.y);
                }
                else if (state == currentState.left)
                {
                    state = currentState.middle;
                    leftTarget = new Vector2(-LeftPanel.sizeDelta.x / 2,
                        LeftPanel.anchoredPosition.y);
                    rightTarget = new Vector2(RightPanel.sizeDelta.x / 2,
                        RightPanel.anchoredPosition.y);
                }
            }
            if (touch.deltaPosition.x < -75)
            {
                if (state == currentState.middle)
                {
                    state = currentState.left;
                    leftTarget = new Vector2(LeftPanel.sizeDelta.x / 2,
                        LeftPanel.anchoredPosition.y);
                    rightTarget = new Vector2(RightPanel.sizeDelta.x / 2,
                        RightPanel.anchoredPosition.y);
                }
                else if (state == currentState.right)
                {
                    state = currentState.middle;
                    leftTarget = new Vector2(-LeftPanel.sizeDelta.x / 2,
                        LeftPanel.anchoredPosition.y);
                    rightTarget = new Vector2(RightPanel.sizeDelta.x / 2,
                        RightPanel.anchoredPosition.y);
                }
            }
        }
#endif
    }
    private void MoveMenu()
    {
        RightPanel.anchoredPosition = Vector2.MoveTowards(RightPanel.anchoredPosition,
                    rightTarget, speed * Time.deltaTime);
        LeftPanel.anchoredPosition = Vector2.MoveTowards(LeftPanel.anchoredPosition,
                    leftTarget, speed * Time.deltaTime);
    }
}
