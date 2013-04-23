Imports Kampaigns.Core
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
        Sub New(ByVal MissionName As String, ByVal MissionType As MissionType, ByVal VesselName As String, ByVal MissionCost As Integer, ByVal MissionReward As Integer, ByVal MissionTimeLimit As Integer, Optional ByVal MissionPenalty As Integer = 0, Optional ByVal MissionGrant As Integer = 0)
            Name = MissionName
            Type = MissionType
            ShipName = VesselName
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

        Public Property Type As MissionType Implements IMission.Type

        Public Property Name As String Implements IMission.Name

        Public Property ShipName As String Implements IMission.ShipName
    End Class
    Public NotInheritable Class MissionPack
        Implements IMissionPack
        Sub New(Optional ByVal Missions As MissionType() = Nothing, Optional ByVal Targets As Target() = Nothing)
            If IsNothing(Missions) = False Then
                NewMissions = Missions
            Else
                Dim n(0) As MissionType
                NewMissions = n
            End If
            If IsNothing(Targets) = False Then
                NewTargets = Targets
            Else
                Dim n(0) As Target
                Targets = n
            End If
        End Sub

        Public Property NewMissions As MissionType() Implements IMissionPack.NewMissions

        Public Property NewTargets As Target() Implements IMissionPack.NewTargets
    End Class
End Namespace
