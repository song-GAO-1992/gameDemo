using strange.extensions.context.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootContext : ContextView
{
   
    private void Awake()
    { 
        context = new MyContext(this);       
    }
}
