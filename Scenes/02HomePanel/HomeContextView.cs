using strange.extensions.context.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeContextView : ContextView {

    private void Awake()
    {
        context = new HomeMyContext(this);
    }
}
