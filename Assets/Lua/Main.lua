print("启动主Lua函数")

require("InitClass")
require("ItemData")
require("PlayerData")
PlayerData:Init()

require("BasePanel")
require("PlayerStatsPanel")
PlayerStatsPanel:ShowSelf("PlayerStatsPanel")
require("ItemGrid")
require("MouseFollower")
require("BagPanel")



