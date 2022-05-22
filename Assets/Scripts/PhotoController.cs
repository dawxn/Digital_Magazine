using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PhotoController : MonoBehaviour
{
    public List<Sprite> Photo = new List<Sprite>(5);
    public GameObject LeftPhoto;
    public GameObject RightPhoto;
    public GameObject LeftPanel;
    public GameObject RightPanel;
    List<GameObject> LeftPanelObjects = new List<GameObject>(3);
    List<GameObject> RightPanelObjects = new List<GameObject>(3);
    public List<Sprite> LoadedImages = new List<Sprite>();
    public Image ChangingImage;
    float timer = 0;
    int CurrentPhotoId = -1;
    public Image Background;
    Vector3 TempScale;
    Vector3 TempPosition;
    void Start()
    {
        TempScale = Background.transform.localScale;
        TempPosition = Background.transform.localPosition;
        Debug.Log(TempPosition);
        //mygtuku priskyrimas
        AssignButtons();
        //aktyvavimas pradiniu foto
        ShowPhoto(1);
        ShowPhoto(4);
        //LoadAllImages
        LoadAllPhotos();
        //LoadFirstImage
        LoadRandomImage();
    }
    void AssignButtons()
    {
        for (int i=0;i< LeftPanel.gameObject.transform.childCount; i++)
        {
            LeftPanelObjects.Add(LeftPanel.gameObject.transform.GetChild(i).gameObject);
        }
        //
        for (int i = 0; i < RightPanel.gameObject.transform.childCount; i++)
        {
            RightPanelObjects.Add(RightPanel.gameObject.transform.GetChild(i).gameObject);
        }
    }
    public void ShowPhoto(int id) {

        if (id < LeftPanelObjects.Count)
        {
            ChangePhoto(LeftPhoto, id);
            ActivateIcon(id, LeftPanelObjects);
        }
        else 
        {
            ChangePhoto(RightPhoto, id);
            ActivateIcon(id-LeftPanelObjects.Count, RightPanelObjects);
        } 
    }
    void ChangePhoto(GameObject obj, int id)
    {
        obj.gameObject.GetComponent<Image>().sprite = Photo[id];
    }
    void ActivateIcon(int id, List<GameObject>Panel)
    {
        for (int i=0; i< Panel.Count; i++) { 
            DectivateIcon(Panel[i].gameObject.transform.GetChild(0).gameObject);
        }
        Panel[id].gameObject.transform.GetChild(0).gameObject.GetComponent<Image>().enabled = true;
    }
    void DectivateIcon(GameObject obj)
    {
        obj.gameObject.GetComponent<Image>().enabled = false;
    }
    void LoadRandomImage()
    {
        int y = Random.Range(0, LoadedImages.Count);
        if (CurrentPhotoId==y) { y = Random.Range(0, LoadedImages.Count); }
        CurrentPhotoId = y;
        ChangingImage.GetComponent<Image>().sprite = LoadedImages[y];
    }
    void LoadAllPhotos()
    {
        object[] obj = Resources.LoadAll("ChangingImages", typeof(Sprite));
        for(int i=0;i<obj.Length;i++)
        {

            LoadedImages.Add(obj[i] as Sprite);
        }
    }
    private void Update()
    {
        timer = timer + Time.deltaTime;
        if (timer >= 1f) { LoadRandomImage(); timer = 0f; }
    }
    public void ZoomIn() { 
        Vector3 Scaled = new Vector3(1.5f, 1.5f, 1.5f); 
        Background.transform.localScale = Scaled;
        //
        RectTransform rectTransform = Background.GetComponent<RectTransform>();
        rectTransform.offsetMax = new Vector2(rectTransform.offsetMax.x, 5f);
        rectTransform.offsetMin = new Vector2(rectTransform.offsetMin.x, -145f);

    }
    public void ZoomOut() 
    { 
        Background.transform.localScale = TempScale;
        Background.transform.localPosition = TempPosition;
    }

    public void ExitApp() { Application.Quit(); }
}
