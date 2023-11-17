using UnityEngine;

public class ContentFiller : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject pageButtonPrefab;
    public Sprite[] content;
    public GameObject[] models;
    [SerializeField] RectTransform canvas;

    private void Start()
    {
        PageAreaUpdate();
    }
    public void PageAreaUpdate()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }

        for (int i = 0; i < content.Length; i++)
        {

            PageButtonHandler handler = pageButtonPrefab.GetComponent<PageButtonHandler>();
            handler.canvas = canvas;
            handler.icon = content[i];
            handler.PrefabToInstantiate = models[i];
            handler.ButtonIconUpdate();
            GameObject go = Instantiate(pageButtonPrefab, transform, false);
            go.name = models[i].name;
            //go.layer = LayerMask.NameToLayer("UI");

        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
