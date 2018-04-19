using strange.extensions.context.api;
using strange.extensions.context.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Start_MyContext : MVCSContext
{
    public Start_MyContext(MonoBehaviour view) : base(view) { }
    

    protected override void mapBindings()
    {
        //数据注入
        injectionBinder.Bind<PlayerData>().ToSingleton();

        mediationBinder.Bind<LoginPanelView>().To<LoginPanelMediator>();
        mediationBinder.Bind<RegistPanelView>().To<RegistPanelMediator>();

        commandBinder.Bind(UIEvents.LoginClick).To<LoginCommand>();
        commandBinder.Bind(UIEvents.RegisterClick).To<RegistCommand>();

        commandBinder.Bind(GameEvent.ReadJson).To<ReadJsonCommand>();
        commandBinder.Bind(GameEvent.SaveJson).To<SaveJsonCommand>();
        commandBinder.Bind(ContextEvent.START).To<UIStartCommand>();
    }
}
