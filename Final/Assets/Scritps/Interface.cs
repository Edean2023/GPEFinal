using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interface : MonoBehaviour
{
    public interface Idamageable<T>
    {
        // sets health int for interface
        int Health { get; set; }
    }
}
