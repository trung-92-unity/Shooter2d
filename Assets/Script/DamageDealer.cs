using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    //Set damage ban đầu là 100
    [SerializeField] int damage = 100;
    /// <summary>
    /// Contructor GetDamage
    /// </summary>
    /// <returns>giá trị damage</returns>
    public int GetDamage()
    {
        return damage;
    }

    /// <summary>
    /// Contructor Hit dùng để xóa bỏ gameObject
    /// </summary>
    public void Hit()
    {
        Destroy(gameObject);
    }
}
   

