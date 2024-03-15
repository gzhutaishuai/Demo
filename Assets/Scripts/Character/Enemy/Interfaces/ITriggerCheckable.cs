

public interface ITriggerCheckable
{
    bool IsAggroed { get; set; }//是否处于巡逻范围内

    bool IsInAttackDistance { get; set; }//是否处于攻击范围内

    void SetAggroStatus(bool isAggroed);//是否为追逐状态

    void SetAttackStatus(bool isInAttackDistance);//是否为攻击状态


}
