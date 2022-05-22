using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UIElements;
using UnityEngine.UI;
using Doozy.Engine.UI;
public class PageController : MonoBehaviour
{
    public GameObject[] Pages = new GameObject[9];
    public int CurrentPage_LeftID = -1;
    public int CurrentPage_RightID = -1;
    public int CurrentPageID = -1;
    public Button ButtonLeft;
    public Button ButtonRight;
    private void Start()
    {
        OpenStartingPages();
    }
    void SetInteractabelButton(Button button)
    {
        button.interactable = true;
  
    }
    void SetNonInteractabelButton(Button button)
    {
        button.interactable = false;
    }
    void OpenStartingPages()
    {
        ShowPanel(0);
    }
    void CheckButtonsInteraction(int id)
    {
        if ((id + 1) < 4) { SetInteractabelButton(ButtonRight); }
        if ((id + 1) >= 4) { SetNonInteractabelButton(ButtonRight); }
        //
        if ((id - 1) >= 0) { SetInteractabelButton(ButtonLeft); }
        if ((id - 1) < 0) { SetNonInteractabelButton(ButtonLeft); }
    }
    public void OpenLeftPage() { if ((CurrentPageID + 1) < (4)) { Debug.Log("LeftPage"); ShowPanel(CurrentPageID + 1); } }
    public void OpenRightPage() { if ((CurrentPageID - 1) >= 0) { Debug.Log("RightPage"); ShowPanel(CurrentPageID - 1); } }
    void ShowPanel(int id) { StartCoroutine(DelayShow(id, 0.75f)); }
    //void HidePanel(int id) { StartCoroutine(DelayHide(id, 0.75f)); }
    void HideAll()
    {
        for (int i=0;i<Pages.Length;i++)
        {
            StartCoroutine(DelayHide(i, 0.25f));
        }
    }
    IEnumerator DelayShow(int id, float time)
    {
        CheckButtonsInteraction(id);
        yield return new WaitForSeconds(0.15f);
        HideAll();
        yield return new WaitForSeconds(time);
        CurrentPageID = id;
        CurrentPage_LeftID = (id*2);
        CurrentPage_RightID = (id*2) + 1;
        UIView Panel = Pages[CurrentPage_LeftID].GetComponent<UIView>();
        Panel.Show(false);
        UIView Panel2 = Pages[CurrentPage_RightID].GetComponent<UIView>();
        Panel2.Show(false);
        UIView Panel3 = Pages[8].GetComponent<UIView>();
        Panel3.Show(false);
    }
    IEnumerator DelayHide(int id, float time)
    {
        yield return new WaitForSeconds(time);
        UIView Panel = Pages[id].GetComponent<UIView>(); Panel.Hide(false);
    }
}
