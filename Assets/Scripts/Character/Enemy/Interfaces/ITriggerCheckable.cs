

public interface ITriggerCheckable
{
    bool IsAggroed { get; set; }//�Ƿ���Ѳ�߷�Χ��

    bool IsInAttackDistance { get; set; }//�Ƿ��ڹ�����Χ��

    void SetAggroStatus(bool isAggroed);//�Ƿ�Ϊ׷��״̬

    void SetAttackStatus(bool isInAttackDistance);//�Ƿ�Ϊ����״̬


}
