--所有面板的基类
Object:subClass("BasePanel")

--类成员变量
BasePanel.panelObj=nil--面板的实体
--相当于模拟一个字典 键是控件名 值是控件本身
BasePanel.componentDic={}
--事件函数标识
BasePanel.isInitPanel=false

function BasePanel:Init(panelName)
    if self.panelObj==nil then

     --公共对象的实例化方法
     self.panelObj=ABMgr:LoadRes("ui",panelName,typeof(GameObject))
     self.panelObj.transform:SetParent(Canvas,false)
     
     --GetComponentsInChildren 获取子物体中某一类的所有组件
     --这里是找到了所有的继承自UIBahavior的子物体
     local allComponents=self.panelObj:GetComponentsInChildren(typeof(UIBehaviour))
     --为了只筛选出有用的控件
     --自定义规则 方便再搜寻插件时按照命名规范来寻找指定的UI控件
     for i=0,allComponents.Length-1 do
         local componentName=allComponents[i].name
         if string.find(componentName,"btn")~=nil or
            string.find(componentName,"img")~=nil or
            string.find(componentName,"sv")~=nil or
            string.find(componentName,"txt")~=nil or
            string.find(componentName,"tog")~=nil 
            then
            --为了能在得到控件时候能够确定控件的类型 所以我们需要存储类型
            --typeName的形式：Image,Button
            --allComponents[i] 已经被筛选过了 只会遍历按照自定义命名的物体
            --allComponents[i]的形式 btnBag
            local typeName=allComponents[i]:GetType().Name
            --避免出现在一个对象上，挂载多个UI控件 出现覆盖的问题
            --会被存储到一个容器里 相当于列表数组的形式
            --最终的存储形式
            --{ btnRole={ Image=控件，Button=控件},
            --  imgBag={ Image=控件 }            }

            --通过自定义索引的方式 去加一个新的成员变量
            if self.componentDic[componentName]~=nil then
               self.componentDic[componentName][typeName]=allComponents[i]          
            else
                --如果为空，新建一个表
               self.componentDic[componentName]={[typeName]=allComponents[i]}
            end
            end
        end
    end
end

--得到控件 根据控件依附对象的名字 和 控件的类型字符串名字
function BasePanel:GetCP(name,typeName)
 if self.componentDic[name]~=nil then
     local sameNameComponents=self.componentDic[name]
    if sameNameComponents[typeName]~=nil then
        return sameNameComponents[typeName]      
    end
 end
 return nil
end

function BasePanel:ShowSelf(name)
    self:Init(name)
    self.panelObj:SetActive(true)
end

function BasePanel:HideSelf(name)
    self.panelObj:SetActive(false)
end