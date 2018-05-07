import win32com.client  
#新建WPS进程  
#wps、et、wpp对应的是金山文件、表格和演示  
#word、excel、powerpoint对应的是微软的文字、表格和演示   
wpsApp=win32com.client.Dispatch("et.Application")  
#设置界面可见  
wpsApp.Visible=1  
#新建一个wps工作簿  
xlBook = wpsApp.Workbooks.Add()  
#选定工作簿中活动工作表的某个单元格  
cell = xlBook.ActiveSheet.Cells(1,1)  
#设置单元格的值  
cell.Value='one'  
#保存工作簿  
xlBook.SaveAs(r"d:/HelloWorld.xls")  
xlBook.Close()  
wpsApp.Quit()  
del wpsApp  
