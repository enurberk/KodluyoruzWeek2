using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItemController : MonoBehaviour
{
    [SerializeField] DropItemModel behaviour = new DropItemModel();
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerController>().ChangeHitPoint(behaviour.damage);
        }
        //bir yere çarptıklarında yok olacaklar;
        Destroy(this.gameObject);
    }
}
[System.Serializable]
class DropItemModel
{
    public DropType dropType;
    public int damage;
}
public enum DropType
{
    heal,
    damage
}