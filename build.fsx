// include Fake lib
#r "packages/FAKE/tools/FakeLib.dll"
open Fake

Target "Restore" (fun _ -> DotNetCli.Restore id)
Target "Build" (fun _ -> DotNetCli.Build id)

RunTargetOrDefault "Build"