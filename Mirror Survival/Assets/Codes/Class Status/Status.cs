using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Status
{
    public string name;
    public float speed;
    public int current_life, max_life ,damage;

   
    public Status( string _name ,float _speed, int _max_life , int _current_life , int _damage)
    {
        name = _name;
        speed = _speed;
        max_life = _max_life;
        current_life = _current_life;
        damage = _damage;
    }

    public void Restore_Health()
    {
        current_life = max_life;
    }
}
