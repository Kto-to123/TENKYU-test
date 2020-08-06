using UnityEngine;
using UnityEngine.EventSystems;

public class Controller : MonoBehaviour, IBeginDragHandler, IDragHandler
{
    public static Controller instance;

    public Transform nextPoint;

    public GameObject map;
    public GameObject player;
    public float speed = 0.01f;

    private GameObject parant;
    private GameObject oldParant;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);

        Physics.gravity = Vector3.down * 20;
    }

    public void OnBeginDrag(PointerEventData eventData) { }

    public void OnDrag(PointerEventData eventData)
    {
        Turn(parant.transform, eventData.delta);
    }

    private void Update()
    {
        if (parant != null) oldParant = parant;

        parant = new GameObject();
        parant.transform.position = player.transform.position;
        if (oldParant != null) parant.transform.rotation = oldParant.transform.rotation;

        if (map != null) map.transform.parent = parant.transform;

        Destroy(oldParant);
    }

    public void ChangeMap(GameObject map)
    {
        parant = null;
        this.map = map;
    }

    private void Turn(Transform t, Vector2 v)
    {
        var n = new Quaternion(Mathf.Clamp(t.rotation.x + v.y * speed, -0.12f, 0.12f), t.rotation.y, Mathf.Clamp(t.rotation.z + v.x * speed * -1, -0.15f, 0.12f), t.rotation.w);
        t.rotation = n;
    }
}
