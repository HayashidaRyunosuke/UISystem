# 使い方
1. UICustomPanelをCanvas内のオブジェクトにアタッチする  
2. インスペクターから値を設定する  
 FadeInDuration  : フェードインに掛かる時間  
 FadeOutDuration : フェードアウトに掛かる時間  
 FadeOutAuto     : フェードインした後に自動的にフェードアウトさせるかどうか  
 WaitTime        : 自動的にフェードアウトさせる場合の待ち時間  
2. UICustomPanelをUIManagerに登録する  
3. UIManagerからSingletonでShowUIやHideUIを呼び出しUIの表示、非表示を行う  
例:  
0番のパネルを表示 : UImanager.Instance.ShowUI(0);  
表示されてるパネルを非表示 : UIManager.instance.HideUI();  

# 備考
シーン内に複数のUIManagerを配置したい場合はUIManagerBaseを継承した別クラスを作成する。  
例:  
 public class StatusUIManager:UIManagerBase<StatusUIManager>{}  
 public class ItemUIManager:UIManagerBase<ItemUIManager>{}  
