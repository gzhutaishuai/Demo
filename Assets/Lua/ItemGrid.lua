BasePanel:subClass("ItemGrid")

--类成员变量
ItemGrid.grid=nil--格子实体
ItemGrid.imgIcon=nil--json格子图片
ItemGrid.txtNumber=nil--json物品数量
ItemGrid.effect=nil
ItemGrid.itemCount=nil--实际物品数量
ItemGrid.isEmpty=true--是否为空
ItemGrid.Item=nil--Item脚本
ItemGrid.toggleBG=nil
ItemGrid.toggleUse=nil--使用toggle
ItemGrid.toggleDrop=nil--丢弃toogle


--1.实例化格子对象
function ItemGrid:Init(father)
    self.grid=ABMgr:LoadRes("ui","ItemGrid",typeof(GameObject))
    self.grid.transform:SetParent(father,false)--设置父级
    self.grid:AddComponent(typeof(CS.Item))
    self.imgIcon=self.grid.transform:Find("imgIcon"):GetComponent(typeof(Image))
    self.txtNumber=self.grid.transform:Find("txtNumber"):GetComponent(typeof(Text))
    self.Item=self.grid:GetComponent(typeof(CS.Item))
    
    self.toggleBG=self.grid.transform:Find("ToggleBG").transform.gameObject
    --获取使用Toggle
    self.toggleUse=self.grid.transform:Find("ToggleBG"):Find("togUse"):GetComponent(typeof(Toggle))
    self.toggleUse.onValueChanged:AddListener(function(value)
     if value==true then
       self:UseItem()
    end
    end)
     --获取丢弃Toggle
    self.toggleDrop=self.grid.transform:Find("ToggleBG"):Find("togDrop"):GetComponent(typeof(Toggle))
    self.toggleDrop.onValueChanged:AddListener(function(value)
        if value==true then
          self:DropItem()
       end
       end)
    self.toggleBG:SetActive(false)
    self.isEmpty=false
end

--2.初始化格子信息
--data 就是外面传入的道具信息 id和num
function ItemGrid:InitGridData(data)

    --通过 道具ID 去读取道具配置表 得到 图标信息
    local itemData=ItemData[data.id]

    --设置图标
    --根据名字先加载图集 再加载图集中的图标信息
    local strs=string.split(itemData.icon,"_")
    --加载图集
    local spriteAtlas=ABMgr:LoadRes("ui",strs[1],typeof(SpriteAtlas))
    self.imgIcon.sprite=spriteAtlas:GetSprite(strs[2])
    --设置它的数量
    self.txtNumber.text=data.num--文本信息设置
    self.Item.itemIndex=data.id--初始化背包下标索引
    self.itemCount=data.num--初始化物品数量
    self.effect=itemData.effect
end

--自定义逻辑
function ItemGrid:DestroySelf()
         GameObject.Destroy(self.obj)
         self.obj=nil
end

--物品使用
function ItemGrid:UseItem()
    if self.itemCount>=1 then
       Player_Stats.CurHealth=Player_Stats.CurHealth+self.effect
    if Player_Stats.CurHealth >= Player_Stats.MaxHealth then
       Player_Stats.CurHealth=Player_Stats.MaxHealth
    end
       PlayerHealthChange=PlayerStatsPanel.panelObj:GetComponent(typeof(CS.PlayerHealthChange))
       PlayerHealthChange.delayAmount=Player_Stats.CurHealth/Player_Stats.MaxHealth
       self.itemCount=self.itemCount-1
       self.txtNumber.text=self.itemCount
    end
    if self.itemCount==0 then
       print("物品已经用完")
    end
end

function ItemGrid:DropItem()
      self.itemCount=self.itemCount-1
      self.txtNumber.text=self.itemCount
end

