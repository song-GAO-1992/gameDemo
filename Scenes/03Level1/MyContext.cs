using strange.extensions.context.api;
using strange.extensions.context.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyContext : MVCSContext
{
    
    public MyContext(ContextView view) : base(view){
        
    }
    protected override void mapBindings()
    {

        //数据绑定，PlayerData为单例模式
        injectionBinder.Bind<PlayerData>().ToSingleton();
        //View绑定
        mediationBinder.Bind<PlayerInfoView>().To<PlayerInfoMediator>();
        mediationBinder.Bind<PlayerView>().To<PlayerMediator>();
        mediationBinder.Bind<SavePointView>().To<SavePointMediator>();
        //command绑定
        commandBinder.Bind(PlayerEventsList_V.UpdateInfo).To<PlayerUpdateCommand>();
        commandBinder.Bind(PlayerEventsList_V.UpdateEquip).To<PlayerUpdateEquipCommand>();
        commandBinder.Bind(PlayerEventsList_V.Damaged).To<PlayerDamagedCommand>();
        //读取和存储玩家信息
        commandBinder.Bind(GameEvent.LoadPlayerInfo).To<LoadPlayerInfoCommand>();
        commandBinder.Bind(GameEvent.SavePlayerInfo).To<SavePlayerInfoCommand>();
        commandBinder.Bind(GameEvent.ReturnHome).To<ReturnHomeCommand>();
        
        commandBinder.Bind(ContextEvent.START).To<StartCommand>();
            
    }

    

}
