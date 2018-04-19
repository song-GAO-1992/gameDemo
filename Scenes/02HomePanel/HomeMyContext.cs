using strange.extensions.context.api;
using strange.extensions.context.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeMyContext : MVCSContext
{
    public HomeMyContext(MonoBehaviour view) : base(view) { }

    protected override void mapBindings()
    {

        mediationBinder.Bind<HomePanelView>().To<HomePanelMediator>();



        commandBinder.Bind(GameEvent.LoadGame).To<LoadGameEvent>();
        commandBinder.Bind(GameEvent.SaveGame).To<SaveGameEvent>();
        commandBinder.Bind(GameEvent.Settings).To<SettingsCommand>();
        commandBinder.Bind(GameEvent.ExitGame).To<ExitGameCommand>();
        commandBinder.Bind(GameEvent.ReadJson).To<ReadJsonCommand>();
        commandBinder.Bind(GameEvent.SaveJson).To<SaveJsonCommand>();

        commandBinder.Bind(ContextEvent.START).To<HomeStartCommand>().Once();
    }






}
