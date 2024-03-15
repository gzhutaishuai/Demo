--首先应该把Json表从AB包中加载出来
--加载Json文件 TextAsset对象

local txt=ABMgr:LoadRes("json","itemData",typeof(TextAsset))

--获取它的文本信息 进行json解析
local itemList=Json.decode(txt.text)

--加载出来的是一个类似于数组的结构
--不方便我们通过id去获取里面的内容，所以需要将表转存一次 
--而且这张表 新的道具表 在任何地方 都能够被使用
--一张用来存储道具信息的表
--键值对的形式 键是道具ID 值是道具表的一行信息
ItemData={}

for _,value in pairs(itemList) do
    --键是配表里面的"id"，值是配表中的整个一行对应的地址
    ItemData[value.id]=value--转存表的地址进去
end
