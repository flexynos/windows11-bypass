Imports Microsoft.Win32
Module Module1

    Sub Main()

        Try
            Dim UnReg As New Process
            UnReg.StartInfo.UseShellExecute = False
            UnReg.StartInfo.RedirectStandardOutput = True
            UnReg.StartInfo.FileName = "cmd"
            UnReg.StartInfo.Arguments = "/c reg unload HKLM\SysWinPE"
            UnReg.StartInfo.CreateNoWindow = True
            UnReg.StartInfo.StandardOutputEncoding = System.Text.Encoding.GetEncoding("cp866")
            UnReg.Start()
            Dim UnRegOut As String = UnReg.StandardOutput.ReadToEnd()
            UnReg.WaitForExit()


            Dim AddReg As New Process
            AddReg.StartInfo.UseShellExecute = False
            AddReg.StartInfo.RedirectStandardOutput = True
            AddReg.StartInfo.FileName = "cmd"
            AddReg.StartInfo.Arguments = "/c reg load HKLM\SysWinPE mount\windows\system32\config\system"
            AddReg.StartInfo.CreateNoWindow = True
            AddReg.StartInfo.StandardOutputEncoding = System.Text.Encoding.GetEncoding("cp866")
            AddReg.Start()
            Dim AddRegOut As String = AddReg.StandardOutput.ReadToEnd()
            AddReg.WaitForExit()

            My.Computer.Registry.LocalMachine.CreateSubKey("SysWinPE\Setup\LabConfig")
            My.Computer.Registry.LocalMachine.OpenSubKey("SysWinPE\Setup\LabConfig", True).SetValue("BypassTPMCheck", 1, RegistryValueKind.DWord)
            My.Computer.Registry.LocalMachine.OpenSubKey("SysWinPE\Setup\LabConfig", True).SetValue("BypassSecureBootCheck", 1, RegistryValueKind.DWord)
            My.Computer.Registry.LocalMachine.OpenSubKey("SysWinPE\Setup\LabConfig", True).SetValue("BypassRAMCheck", 1, RegistryValueKind.DWord)
            My.Computer.Registry.LocalMachine.OpenSubKey("SysWinPE\Setup\LabConfig", True).SetValue("BypassStorageCheck", 1, RegistryValueKind.DWord)
            My.Computer.Registry.LocalMachine.OpenSubKey("SysWinPE\Setup\LabConfig", True).SetValue("BypassCPUCheck", 1, RegistryValueKind.DWord)

        Catch
            MsgBox("Fail!")

        End Try
    End Sub

End Module
