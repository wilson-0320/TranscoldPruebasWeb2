Imports Microsoft.VisualBasic
Imports System.IO

Public Class ArchivosLib

    Public Shared Sub MoverArchivoADirectorio(ByVal sourceDirPath As String, ByVal destDirPath As String, ByVal FileName As String)
        If Not Directory.Exists(destDirPath) Then
            Directory.CreateDirectory(destDirPath)
        End If
        Dim sourceFilePath, destFilePath As String
        sourceFilePath = Path.Combine(sourceDirPath, FileName)
        destFilePath = Path.Combine(destDirPath, FileName)
        If File.Exists(destFilePath) Then
            File.Delete(destFilePath)
        End If
        File.Move(sourceFilePath, destFilePath)
        If EsPathImagen(FileName) Then
            If IO.File.Exists(obtThumbnailPath(sourceFilePath)) Then
                MoverArchivoADirectorio(sourceDirPath, destDirPath, FileName.Replace(".", "_thn."))
            Else
                CreaThumbnail(destFilePath)
            End If
        End If
    End Sub

    Public Shared Function EsPathImagen(ByVal FilePath As String) As Boolean
        Return FilePath.ToString.Length >= 3 _
            AndAlso "JPG,GIF,BMP,PNG".Contains(FilePath.ToUpper.Substring(FilePath.ToString.Length - 3)) _
            AndAlso Not FilePath.Contains("_thn.")
    End Function

    Public Shared Function obtThumbnailPath(ByVal FilePath As String) As String
        Return FilePath.Replace(".", "_thn.")
    End Function

    Public Shared Sub CreaThumbnail(ByVal FilePath As String)
        Dim fs As FileStream
        Try
            fs = New FileStream(FilePath, System.IO.FileMode.Open, System.IO.FileAccess.Read)
            Dim img As System.Drawing.Image = System.Drawing.Image.FromStream(fs)
            fs.Close()
            Dim thn As System.Drawing.Image = img.GetThumbnailImage(200, 200, Nothing, Nothing)
            fs = New FileStream(obtThumbnailPath(FilePath), FileMode.CreateNew)
            thn.Save(fs, System.Drawing.Imaging.ImageFormat.Jpeg)
            fs.Close()
        Catch ex As Exception
            Try
                fs.Close()
            Catch ex2 As Exception
            End Try
        End Try
    End Sub

    Public Shared Function ObtieneThumbnailYCreaSiNoExiste(ByVal FilePath As String) As Byte()
        Try
            If Not File.Exists(obtThumbnailPath(FilePath)) Then
                CreaThumbnail(FilePath)
            End If
            Dim fs As FileStream = New FileStream(obtThumbnailPath(FilePath), System.IO.FileMode.Open, System.IO.FileAccess.Read)
            Dim img(fs.Length) As Byte
            fs.Read(img, 0, Convert.ToInt32(fs.Length))
            fs.Close()
            Return img
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

End Class
