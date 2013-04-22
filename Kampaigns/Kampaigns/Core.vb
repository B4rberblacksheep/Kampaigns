Imports Kampaigns.Campaign
Namespace Core
    Public Enum MissionStatus
        Planned = 0
        InProgress = 1
        Successful = 2
        Failure = 3
    End Enum
    Public Structure Target
        Public Name As String
    End Structure
    Public Structure MissionType
        Public Name As String
        Public Description As String
    End Structure
    Public Module CoreFunctions
        Public Function CompileMissionPacks(ByVal MissionPacks As MissionPack()) As MissionPack
            Dim m As New MissionPack
            Dim i2 As Integer = 0
            Dim i3 As Integer = 0
            For Each mm As MissionPack In MissionPacks
                For i = 0 To mm.NewMissions.Count - 1
                    Array.Resize(m.NewMissions, i2 + 1)
                    m.NewMissions(i2) = mm.NewMissions(i)
                    i2 += 1
                Next
                For i = 0 To mm.NewTargets.Count - 1
                    Array.Resize(m.NewTargets, i3 + 1)
                    m.NewTargets(i3) = mm.NewTargets(i)
                    i2 += 1
                Next
                i3 = 0
            Next
            Return m
        End Function
    End Module
End Namespace