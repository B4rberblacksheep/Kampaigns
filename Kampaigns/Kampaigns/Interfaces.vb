Imports Kampaigns.Core
Imports Kampaigns.Campaign
Public Interface ICampaign
    Sub NewMission(ByVal Mission As Mission)
    Property Missions As Mission()
    Property Money As Integer
    Property TechLevel As Byte
End Interface

Public Interface IMission
    Sub Start(ByRef Money As Integer)
    Sub Complete(ByRef Money As Integer)
    Sub Failure(ByRef Money As Integer)
    Property TimeStarted As Date
    Property TimeComplete As Date
    Property TimeLimit As Integer
    Property IsCompleted As Boolean
    Property Status As MissionStatus
    Property Cost As Integer
    Property Reward As Integer
    Property Grant As Integer
    Property Penalty As Integer
End Interface