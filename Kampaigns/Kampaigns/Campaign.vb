Namespace Campaign
    Public NotInheritable Class Campaign
        Implements ICampaign

        Sub New(ByVal StartingMoney As Integer, ByVal StartingTechLevel As Byte)
            Money = StartingMoney
            TechLevel = StartingTechLevel
        End Sub
        Public Property Missions As Mission() Implements ICampaign.Missions

        Public Property Money As Integer Implements ICampaign.Money

        Public Property TechLevel As Byte Implements ICampaign.TechLevel

        Public Sub NewMission(ByVal Mission As Mission) Implements ICampaign.NewMission
            Array.Resize(Missions, Missions.Length + 1)
            Missions(Missions.Length - 1) = Mission
        End Sub
    End Class
    Public NotInheritable Class Mission
        Implements IMission
        Sub New(ByVal MissionCost As Integer, ByVal MissionReward As Integer, ByVal MissionTimeLimit As Integer, Optional ByVal MissionPenalty As Integer = 0, Optional ByVal MissionGrant As Integer = 0)
            Cost = MissionCost
            IsCompleted = False
            Reward = MissionReward
            Status = Core.MissionStatus.Planned
            TimeComplete = Nothing
            TimeLimit = MissionTimeLimit
            TimeStarted = Nothing
        End Sub
        Sub Start(ByRef Money As Integer) Implements IMission.Start
            Status = Core.MissionStatus.InProgress
            Money += Grant
            TimeStarted = Now
        End Sub

        Public Property IsCompleted As Boolean Implements IMission.IsCompleted

        Public Property Cost As Integer Implements IMission.Cost

        Public Property Reward As Integer Implements IMission.Reward

        Public Property Grant As Integer Implements IMission.Grant

        Public Property Penalty As Integer Implements IMission.Penalty

        Public Property Status As Core.MissionStatus Implements IMission.Status

        Public Property TimeComplete As Date Implements IMission.TimeComplete

        Public Property TimeLimit As Integer Implements IMission.TimeLimit

        Public Property TimeStarted As Date Implements IMission.TimeStarted

        Public Sub Complete(ByRef Money As Integer) Implements IMission.Complete
            Status = Core.MissionStatus.Successful
            Money += Reward
            TimeComplete = Now
            IsCompleted = True
        End Sub

        Public Sub Failure(ByRef Money As Integer) Implements IMission.Failure
            Status = Core.MissionStatus.Failure
            Money -= Penalty
            TimeComplete = Now
            IsCompleted = True
        End Sub
    End Class
End Namespace
