--玩家数据类
PlayerData={}

PlayerData.items={}

--玩家数据初始化方法
function PlayerData:Init()
    table.insert(self.items,{id=1,num=1})
    table.insert(self.items,{id=2,num=1})
    table.insert(self.items,{id=3,num=1})
    table.insert(self.items,{id=4,num=14})
    table.insert(self.items,{id=5,num=20})
    table.insert(self.items,{id=6,num=99})
end
