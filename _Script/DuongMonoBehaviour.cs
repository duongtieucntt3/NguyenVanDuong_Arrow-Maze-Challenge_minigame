using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuongMonoBehaviour : MonoBehaviour
{
    protected virtual void Awake()
    {
        this.LoadComponents();
    }

    protected virtual void Start()
    {
        //For override
    }

    protected virtual void Reset()
    {
        this.LoadComponents();
    }

    protected virtual void LoadComponents()
    {
        //For override
    }




}
