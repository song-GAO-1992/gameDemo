using strange.extensions.context.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Start_Contextview: ContextView
{
    void Start()
    {
        context = new Start_MyContext(this);
    }
}
