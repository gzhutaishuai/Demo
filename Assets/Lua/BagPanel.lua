BasePanel:subClass("BagPanel")

BagPanel.Content=nil

BagPanel.slots={}

BagPanel.inventorySize=10;

BagPanel.itemsList=List_Item()

BagPanel.items={}

BagPanel.count=1

BagPanel.DescriptionPanel=nil--描述面板

BagPanel.imgIcongameObject=nil
BagPanel.imgIcon=nil;--描述物品的图片

BagPanel.txtTitle=nil;--物品标头

BagPanel.txtDescription=nil--物品描述

BagPanel.currentDragItemIndex=-1--记录当前的拖拽物品


function BagPanel:Init(name)
   self.base.Init(self,name)
   if self.isInitPanel==false then
      self.isInitPanel=true;
      self:GetCP("btnClose","Button").onClick:AddListener(function()
       self:HideSelf()
      end)
      self.Content=self:GetCP("svBag","ScrollRect").transform:Find("Viewport"):Find("Content");
      self.DescriptionPanel=self.panelObj.transform:Find("DescriptionPanel")
      self.imgIcongameObject=self.DescriptionPanel.transform:Find("Icon"):Find("imgItems")
      self.imgIcon=self:GetCP("imgItems","Image")
      self.txtTitle=self:GetCP("txtTitle","Text")
      self.txtDescription=self:GetCP("txtDescripition","Text")
   end
   self:ResetDescription()
   --self:SetDescription(PlayerData.items[1])
end

--自定义函数
function BagPanel:ShowSelf(name)
    self.base.ShowSelf(self,name)
    if self.count==1 then
      self.count=2
    self:InitSlots()
 end
end

--选中格子 展示信息
function HandleItemSelection(itemScript)
      local index=-1;  
      index=itemScript.itemIndex;
      if index==-1 then
       return;
      end
      BagPanel:SetDescription(PlayerData.items[index])
      
end
--交换格子
function HandleSwap(itemScript)
  local index=-1
  index=BagPanel.itemsList:IndexOf(itemScript)
  if index==-1 then
   MouseFollower:Close()
   BagPanel.currentDragItemIndex=-1
   return
  end
  ItemSwap(index)
   MouseFollower:Close()
   BagPanel.currentDragItemIndex=-1
end

--交换的具体逻辑
function ItemSwap(index)
   local formerGrid=ItemGrid:new()
   --记录抓取的装备
   formerGrid.grid=BagPanel.itemsList[BagPanel.currentDragItemIndex].transform.gameObject
   formerGrid.imgIcon=formerGrid.grid.transform:Find("imgIcon"):GetComponent(typeof(Image))
   formerGrid.txtNumber=formerGrid.grid.transform:Find("txtNumber"):GetComponent(typeof(Text))
   formerGrid.Item=formerGrid.grid:GetComponent(typeof(CS.Item));
   --记录要被交换的装备
   local laterGrid=ItemGrid:new()
   laterGrid.grid=BagPanel.itemsList[index].transform.gameObject
   laterGrid.imgIcon=laterGrid.grid.transform:Find("imgIcon"):GetComponent(typeof(Image))
   laterGrid.txtNumber=laterGrid.grid.transform:Find("txtNumber"):GetComponent(typeof(Text))
   laterGrid.Item=laterGrid.grid:GetComponent(typeof(CS.Item));
   local tmp=formerGrid.imgIcon.sprite
   formerGrid.imgIcon.sprite=laterGrid.imgIcon.sprite
   laterGrid.imgIcon.sprite=tmp

   local tmp2=formerGrid.txtNumber.text
   formerGrid.txtNumber.text=laterGrid.txtNumber.text
   laterGrid.txtNumber.text=tmp2

   local tmp3=formerGrid.Item.itemIndex
   formerGrid.Item.itemIndex=laterGrid.Item.itemIndex
   laterGrid.Item.itemIndex=tmp3

end

--开始拖拽
function HandleBeginDrag(itemScript)
   local index=-1
   index=BagPanel.itemsList:IndexOf(itemScript)
   if index==-1 then 
      return
   end
   BagPanel.currentDragItemIndex=index
   local formerGrid=ItemGrid:new()
   --记录抓取的装备
   --formerGrid.grid=BagPanel.itemsList[BagPanel.currentDragItemIndex].transform.gameObject
   formerGrid.imgIcon=BagPanel.itemsList[index].transform:Find("imgIcon"):GetComponent(typeof(Image))

   MouseFollower:Open()
   MouseFollower:SetDataBegin(formerGrid.imgIcon.sprite)
end

--结束拖拽
function HandleEndDrag()
   MouseFollower:Close()
end
--右键单击显示功能
function HandleShowItemActions(itemScript)
   local itemTogBG=itemScript.transform:Find("ToggleBG").transform.gameObject
   if itemScript.isTogBG==false then
   itemTogBG:SetActive(true)
   itemScript.isTogBG=true
   else
   itemTogBG:SetActive(false)
   itemScript.isTogBG=false
   end
end

--1.初始化格子
function BagPanel:InitSlots()
   local nowItems=PlayerData.items
    for i=1,#nowItems do
         local Grid=ItemGrid:new()
         Grid:Init(self.Content)
         Grid:InitGridData(nowItems[i])
         Grid.Item:OnItemClicked("+",HandleItemSelection)
         Grid.Item:OnItemDroppedOn("+",HandleSwap)
         Grid.Item:OnItemBeginDrag("+",HandleBeginDrag)
         Grid.Item:OnItemEndDrag("+",HandleEndDrag)
         Grid.Item:OnItemMoseRightClick("+",HandleShowItemActions)
         table.insert(self.items,Grid)
         self.itemsList:Add(Grid.Item)--要添加脚本     
    end
end

--重置物品描述信息
function BagPanel:ResetDescription()
   self.imgIcon.enabled=false
   self.txtTitle.text=""
   self.txtDescription.text=""
end

function BagPanel:SetDescription(data)
       --通过 道具ID 去读取道具配置表 得到 图标信息
       local itemData=ItemData[data.id]

       --设置图标
       --根据名字先加载图集 再加载图集中的图标信息
       local strs=string.split(itemData.icon,"_")
       --加载图集
       local spriteAtlas=ABMgr:LoadRes("ui",strs[1],typeof(SpriteAtlas))
       self.imgIcon.enabled=true
       self.imgIcon.sprite=spriteAtlas:GetSprite(strs[2])
       --设置它的数量
       self.txtTitle.text=itemData.name
       self.txtDescription.text=itemData.tips
end