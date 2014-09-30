Imports System.Xml
Imports System.IO

Public Class NewProject

    Private VLP_Styles As VLP_Styles
    Public Name As String
    Public NameFolder As String
    Public PathFileIcon As String
    Public DestenyFile As String

    'Crea los archivos necesarios.
    Private Sub NewProject()
        Try
            If My.Computer.FileSystem.DirectoryExists( _
                My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\Visual love project") Then

                Dim nombreCarpeta As String = "\Visual love project\" & Name & "\"
                NameFolder = nombreCarpeta

                '===========================================================================================
                Dim FullPath As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments & _
                nombreCarpeta & "Icon\icon.ico"

                DestenyFile = FullPath 'Esta function se encarga de darle una ruta a la variable DestenyFile.
                '===========================================================================================

                '--------------carpeta con el nombbre del projecto----------------------------------
                My.Computer.FileSystem.CreateDirectory( _
                My.Computer.FileSystem.SpecialDirectories.MyDocuments & nombreCarpeta _
                & Name)

                '--------------------Comprueba si el projecto existe------------------------------
                If My.Computer.FileSystem.DirectoryExists( _
                     My.Computer.FileSystem.SpecialDirectories.MyDocuments & nombreCarpeta _
                     & Name) Then

                    '-------------------crea el archivo del projecto---------------------------------
                    System.IO.File.Create( _
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\Visual love project\" _
                    & Name & "\" & Name & ".vlp").Close()
                    '-------------------ccrea el archivo main.lua---------------------------------
                    System.IO.File.Create( _
                     My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\Visual love project\" _
                     & Name & "\" & Name & "\" & "main.lua").Close()
                    '-------------------ccrea el archivo conf.lua---------------------------------
                    System.IO.File.Create( _
                     My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\Visual love project\" _
                     & Name & "\" & Name & "\" & "conf.lua").Close()
                End If
            End If

            PathFileIcon = Application.StartupPath & "\Default-Ico\icon.ico"
            CopyFileToPath() 'Function para copiar el icono a la carpeta de destino.

            'Guarda las configuraciones para el archivo .vlp
            SaveLoveSetting()

        Catch ex As Exception
            MsgBox("error")
        End Try
    End Sub

    Private Sub NewProject_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Activa las personalisaciones del selector de optiones.
        VLP_Styles.SetWindowTheme(LV_Option.Handle, "explorer", Nothing)

        Name = TB_Text.Text
        CB_Version.SelectedIndex = 0
        LV_Option.Items(0).Selected = True
    End Sub

    Private Sub BT_Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Cancel.Click
        Me.Close()
    End Sub

    Private Sub TB_Text_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TB_Text.TextChanged
        Name = TB_Text.Text
    End Sub

    'Boton aceptar.
    Private Sub BT_Ok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Ok.Click
        Dim PathVLP As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments _
           & "\Visual love project\" & Name & "\" & Name & ".vlp"

        Dim PathVLPFolder As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments _
          & "\Visual love project\" & Name

        Try

            If LV_Option.SelectedItems(0).Index = 0 Then

                If My.Computer.FileSystem.FileExists(PathVLP) And My.Computer.FileSystem.DirectoryExists(PathVLPFolder) Then
                    Dim title1 As String = ""
                    Dim text1 As String = "El proyecto lla existe, Decea reemplazarlo."
                    Dim MsgStyle As MsgBoxStyle = MsgBoxStyle.YesNoCancel Or vbExclamation

                    Dim msg = MsgBox(text1, MsgStyle, title1)

                    If msg = MsgBoxResult.Yes Then
                        My.Computer.FileSystem.DeleteDirectory(PathVLPFolder, FileIO.DeleteDirectoryOption.DeleteAllContents)
                        If TB_Text.Text = "" Then
                            MsgBox("Tiene que poner un nombre.", MsgBoxStyle.Exclamation)
                            TB_Text.Focus()
                        Else
                            NewProject()
                            MainForm1.Open_Project(PathVLP)
                            Me.Close()
                        End If
                    ElseIf msg = MsgBoxResult.No Then
                        TB_Text.Focus()
                        TB_Text.SelectAll()
                    ElseIf msg = MsgBoxResult.Cancel Then
                        Exit Sub
                    End If
                Else

                    If TB_Text.Text = "" Then
                        MsgBox("Tiene que poner un nombre.", MsgBoxStyle.Exclamation)
                        TB_Text.Focus()
                    Else
                        NewProject()
                        MainForm1.Open_Project(PathVLP)
                        Me.Close()
                    End If

                End If

            End If

        Catch ex As Exception
            MsgBox("Tiene que seleccionar una opcion.", MsgBoxStyle.Exclamation)
        End Try
    End Sub

    'Carga la configuracion del archivo vlp.
    Private Sub UpdateVLP()
        Dim rutaXML As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments _
                           & "\Visual love project\" & Name & "\" & Name & ".vlp"
        'Se declara una variable para almacenar el documento XML
        Dim documento_xml As New XmlDocument
        'Cargar en la variable el fichero
        documento_xml.Load(rutaXML)
        'Se define el nodo raiz
        Dim personas As XmlNode = documento_xml.DocumentElement
        For Each persona As XmlElement In personas.ChildNodes
            PropertiesForm.TB_Ico.Text = persona.Item("Ico").InnerText '& Environment.NewLine
            PropertiesForm.TB_Author.Text = persona.Item("Autor").InnerText '& Environment.NewLine
            PropertiesForm.TB_Version.Text = persona.Item("Version").InnerText '& Environment.NewLine
            PropertiesForm.TB_Company.Text = persona.Item("Company").InnerText '& Environment.NewLine
            PropertiesForm.TB_DateCreate.Text = persona.Item("Date").InnerText '& Environment.NewLine
        Next
    End Sub

    'Guarda la configuracion para el archivo vlp.
    Private Sub SaveLoveSetting()
        Dim rutaXML As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments _
                            & "\Visual love project\" & Name & "\" & Name & ".vlp"
        'Graba las estructuras del vlp.
        Dim ContenidoVLP As String = "<?xml version=" & """1.0""" & " encoding=""utf-8""?>" & vbNewLine & _
        "<VisualLoveProject>" & vbNewLine & vbNewLine & "</VisualLoveProject>"
        Dim sr As New StreamWriter(rutaXML)
        sr.Write(ContenidoVLP)
        sr.Close()

        'Se crea una variable para acceder al documento XML.
        Dim documento_xml As New XmlDocument
        'Se indica la ubicación del fichero y se abre.
        documento_xml.Load(rutaXML)
        Dim articulo As XmlElement = documento_xml.CreateElement("Conf")
        articulo.SetAttribute("Love", "Vlp Opciones")

        Dim RutaDefault As String = DestenyFile 'Rurta para del icono por defecto.
        'Guarda Icono. 
        Dim Icono As XmlElement = documento_xml.CreateElement("Ico")
        Icono.InnerText = RutaDefault
        articulo.AppendChild(Icono)

        'Guarda Autor. 
        Dim Autor As XmlElement = documento_xml.CreateElement("Autor")
        Autor.InnerText = "VisualLoveProject"
        articulo.AppendChild(Autor)

        'Guarda Version de seleccion. 
        Dim VersionCombox As String = CB_Version.SelectedItem
        Dim limpio As String = VersionCombox.Remove(0, 5)
        Dim Version As XmlElement = documento_xml.CreateElement("Version")
        Version.InnerText = limpio
        articulo.AppendChild(Version)

        'Guarda Company. 
        Dim Company As XmlElement = documento_xml.CreateElement("Company")
        Company.InnerText = "Dark"
        articulo.AppendChild(Company)

        'Guarda Date. 
        Dim Date1 As XmlElement = documento_xml.CreateElement("Date")
        Date1.InnerText = My.Computer.Clock.LocalTime.ToString
        articulo.AppendChild(Date1)

        'Se obtiene el nodo raiz que en este caso se corresponde con la etiqueta articulos.
        Dim nodo_raiz As XmlNode = documento_xml.DocumentElement
        'Se inserta el artículo al final del archivo dentro del nodo raiz.
        nodo_raiz.InsertAfter(articulo, nodo_raiz.LastChild)
        'Guarda los codigos en el archivo vlp.
        documento_xml.Save(rutaXML)

        UpdateVLP()
    End Sub

    'Function para copiar el icono a la carpeta del proyecto creado.
    Private Sub CopyFileToPath()
        Try
            My.Computer.FileSystem.CopyFile(PathFileIcon, DestenyFile)
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical)
        End Try
    End Sub

End Class