using UnityEngine;
using UnityEngine.Events;

public class SelectionManager : MonoBehaviour
{
    public UnityEvent<AUnit> onSelect = new UnityEvent<AUnit>();
    public UnityEvent<AUnit> onDeselect = new UnityEvent<AUnit>();

    private AUnit selected;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                var selectable = hit.collider.GetComponent<AUnit>();

                if (selectable != null)
                {
                    Select(selectable);
                }
                else
                {
                    Deselect();
                }
            }
            else
            {
                Deselect();
            }
        }
    }

    private void Select(AUnit newSelected)
    {
        Deselect();

        selected = newSelected;
        selected.OnSelect();
        onSelect?.Invoke(selected);

        var outline = selected.gameObject.AddComponent<Outline>();
        outline.OutlineMode = Outline.Mode.OutlineAll;
        outline.OutlineColor = Color.green;
        outline.OutlineWidth = 5f;
    }

    private void Deselect()
    {
        if (selected != null)
        {
            Destroy(selected.gameObject.GetComponent<Outline>());
            onDeselect?.Invoke(selected);
            selected.OnDeselect();
            selected = null;
        }
    }
}