using strange.extensions.context.api;
using strange.extensions.context.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lv2_MyContext : MVCSContext
{

    public Lv2_MyContext(MonoBehaviour view) : base(view)
    {
    }

    protected override void mapBindings()
    {
        //数据绑定
        injectionBinder.Bind<PlayerData>().ToSingleton();
        
        mediationBinder.Bind<PlayerView>().To<PlayerMediator>();
        mediationBinder.Bind<PlayerInfoView>().To<PlayerInfoMediator>();
        mediationBinder.Bind<ChestView>().To<ChestMediator>();
        mediationBinder.Bind<SavePointView>().To<SavePointMediator>();
        
        commandBinder.Bind(PlayerEventsList_V.UpdateInfo).To<PlayerUpdateCommand>();
        commandBinder.Bind(PlayerEventsList_V.UpdateEquip).To<PlayerUpdateEquipCommand>();
        commandBinder.Bind(PlayerEventsList_V.UpdateLevel).To<PlayerUpdateLevelCommand>();
        commandBinder.Bind(PlayerEventsList_V.Damaged).To<PlayerDamagedCommand>();
        commandBinder.Bind(PlayerEventsList_V.Score).To<ScoreItemCommand>();
        commandBinder.Bind(PlayerEventsList_V.AddScore).To<AddScoreCommand>();
        

        commandBinder.Bind(GameEvent.LoadPlayerInfo).To<LoadPlayerInfoCommand>();
        commandBinder.Bind(GameEvent.SavePlayerInfo).To<SavePlayerInfoCommand>();
        commandBinder.Bind(GameEvent.ReturnHome).To<ReturnHomeCommand>();
        commandBinder.Bind(ContextEvent.START).To<StartCommand>().Once();
    }

}
