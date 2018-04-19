using strange.extensions.context.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lv2_ContextView : ContextView {

    private void Awake()
    {
        context = new Lv2_MyContext(this);
    }
}
