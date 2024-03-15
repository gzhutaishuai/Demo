BasePanel:subClass("MouseFollower")

MouseFollower.Grid=nil--用来拖拽的格子

MouseFollower.item=nil;--子物体的Item脚本

MouseFollower.item=nil--Item类

function MouseFollower:SetData(data)
     local itemData=ItemData[data.id]
     --设置图标
     --根据名字先加载图集 再加载图集中的图标信息
     local strs=string.split(itemData.icon,"_")
     --加载图集
     local spriteAtlas=ABMgr:LoadRes("ui",strs[1],typeof(SpriteAtlas))
     self.Grid.imgIcon.sprite=spriteAtlas:GetSprite(strs[2])
     --设置它的数量
     self.Grid.txtNumber.text=""
     self.Grid.imgIcon.enabled=true
end

function MouseFollower:SetDataBegin(sprite)
    self.Grid.imgIcon.enabled=true
    self.Grid.imgIcon.sprite=sprite
end


function MouseFollower:Init(name)
    self.base.Init(self,name)
    MouseFollower.panelObj:AddComponent(typeof(CS.MouseFollow))
    if self.isInitPanel==false then
    self.isInitPanel=true
    self.Grid=ItemGrid:new()
    self.Grid:Init(self.panelObj.transform)
    self.Grid.imgIcon.enabled=false
    end
end

function MouseFollower:ShowSelf(name)
    self.base.ShowSelf(self,name)
    self:Close()
end

function MouseFollower:HideSelf()
    self.base.Init(self)
end

function MouseFollower:Close()
    self.panelObj:SetActive(false)
end

function MouseFollower:Open()
    self.panelObj:SetActive(true)
end