using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PageButtonHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Sprite icon;
    public GameObject PrefabToInstantiate;
    [SerializeField] RectTransform UIDragElement;
    public RectTransform canvas;

    private Vector2 originalLocalPointerPosition;
    private Vector3 originalPanelLocalPosition;
    private Vector2 originalPosition;


    public void ButtonIconUpdate()
    {
        GetComponent<Image>().sprite = icon;
    }


    // Start is called before the first frame update
    public void OnBeginDrag(PointerEventData data)
    {
        originalPanelLocalPosition = UIDragElement.localPosition;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
          canvas,
          data.position,
          data.pressEventCamera,
          out originalLocalPointerPosition);

        GameManager.Instance.isUIDragging = true;
        print(!GameManager.Instance.isUIDragging);
    }

    public void OnDrag(PointerEventData data)
    {
        Vector2 localPointerPosition;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
          canvas,
          data.position,
          data.pressEventCamera,
          out localPointerPosition))
        {
            Vector3 offsetToOriginal =
              localPointerPosition -
              originalLocalPointerPosition;
            UIDragElement.localPosition =
              originalPanelLocalPosition +
              offsetToOriginal;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //StartCoroutine(
        //  Coroutine_MoveUIElement(
        //    UIDragElement,
        //    originalPosition,
        //    0.1f));

        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(
          Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 1000.0f))
        {
            Vector3 worldPoint = hit.point;

            //Debug.Log(worldPoint);
            CreateObject(worldPoint);
        }

        transform.parent.GetComponent<ContentFiller>().PageAreaUpdate();
        GameManager.Instance.isUIDragging = false;
        print(!GameManager.Instance.isUIDragging);

    }

    public void CreateObject(Vector3 position)
    {
        if (PrefabToInstantiate == null)
        {
            Debug.Log("No prefab to instantiate");
            return;
        }
        GameObject obj = Instantiate(
          PrefabToInstantiate,
          position,
          Quaternion.identity);
    }

    public IEnumerator Coroutine_MoveUIElement(
    RectTransform r,
    Vector2 targetPosition,
    float duration = 0.1f)
    {
        float elapsedTime = 0;
        Vector2 startingPos = r.localPosition;
        while (elapsedTime < duration)
        {
            r.localPosition =
              Vector2.Lerp(
                startingPos,
                targetPosition,
                (elapsedTime / duration));
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        r.localPosition = targetPosition;
    }

}
