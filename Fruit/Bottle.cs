using UnityEngine;

public class Bottle : Fruit
{
    [SerializeField] private int _index;

    public void SetIndex(int index)
    {
        _index = index;
    }

    public override void DeselectObject()
    {
        RaycastHit2D[] hits = new RaycastHit2D[1];

        int hit = Physics2D.RaycastNonAlloc(transform.position, Vector3.forward, hits, Mathf.Infinity, _layer);

        if (hit >= 1)
        {
            var obj = hits[0].collider.gameObject.GetComponent<Cup>();
            obj.FillCup(gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().color, _index);
            Destroy(this.gameObject);
        }
    }
}
