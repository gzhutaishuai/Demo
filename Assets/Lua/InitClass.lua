--常用别名都在这里定位
require("Object")
require("SplitTools")
Json= require("JsonUtility")

--Unity相关的
GameObject=CS.UnityEngine.GameObject
Resources=CS.UnityEngine.Resources
Transform=CS.UnityEngine.Transform
RectTransfrom=CS.UnityEngine.RectTransfrom
TextAsset=CS.UnityEngine.TextAsset
Camera=CS.UnityEngine.Camera
Input=CS.UnityEngine.Input
--图集相关
SpriteAtlas=CS.UnityEngine.U2D.SpriteAtlas

Vector3=CS.UnityEngine.Vector3
Vector2=CS.UnityEngine.Vector2
--UI相关
UI=CS.UnityEngine.UI
Image=UI.Image
Text=UI.Text
Button=UI.Button
Toggle=UI.Toggle
ScrollRect=UI.ScrollRect
Canvas=GameObject.Find("Canvas").transform
UIBehaviour=CS.UnityEngine.EventSystems.UIBehaviour

--自己写的
ABMgr=CS.ABManager.Instance
ItemScript=CS.Item
List_Item=CS.System.Collections.Generic.List(CS.Item)
LifeCycle=CS.LifeCycle--生命周期类
E_lifeFun_Type=CS.LifeCycle.E_lifeFun_Type--注意枚举的命名空间
Player=GameObject.Find("Player").transform.gameObject
Player_Stats=Player.transform:GetComponent(typeof(CS.Character_Stats))

--几何
Vector2=CS.UnityEngine.Vector2
RectTransformUtility=CS.UnityEngine.RectTransformUtility