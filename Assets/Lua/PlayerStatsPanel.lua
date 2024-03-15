--新的对象
BasePanel:subClass("PlayerStatsPanel")

function PlayerStatsPanel:Init(name)
         self.base.Init(self,name)
         if self.isInitPanel==false then
            self.isInitPanel=true
            self:GetCP("btnBag","Button").onClick:AddListener(function()
             self:BtnBagOnClick()
            end)
         end
end

function PlayerStatsPanel:BtnBagOnClick()
    BagPanel:ShowSelf("BagPanel")
    MouseFollower:ShowSelf("MouseFollower")
end