﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:4.0.30319.42000
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On


Namespace My
    
    <Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute(),  _
     Global.System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "10.0.0.0"),  _
     Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
    Partial Friend NotInheritable Class MySettings
        Inherits Global.System.Configuration.ApplicationSettingsBase
        
        Private Shared defaultInstance As MySettings = CType(Global.System.Configuration.ApplicationSettingsBase.Synchronized(New MySettings()),MySettings)
        
#Region "My.Settings Auto-Save Functionality"
#If _MyType = "WindowsForms" Then
    Private Shared addedHandler As Boolean

    Private Shared addedHandlerLockObject As New Object

    <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)> _
    Private Shared Sub AutoSaveSettings(ByVal sender As Global.System.Object, ByVal e As Global.System.EventArgs)
        If My.Application.SaveMySettingsOnExit Then
            My.Settings.Save()
        End If
    End Sub
#End If
#End Region
        
        Public Shared ReadOnly Property [Default]() As MySettings
            Get
                
#If _MyType = "WindowsForms" Then
               If Not addedHandler Then
                    SyncLock addedHandlerLockObject
                        If Not addedHandler Then
                            AddHandler My.Application.Shutdown, AddressOf AutoSaveSettings
                            addedHandler = True
                        End If
                    End SyncLock
                End If
#End If
                Return defaultInstance
            End Get
        End Property
        
        '''<summary>
        '''Databaskoppling till B2
        '''</summary>
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Configuration.SettingsDescriptionAttribute("Databaskoppling till B2"),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Data Source=sql.bus.local;Initial Catalog=B2;user id=sa;Connection Timeout=240;Pa"& _ 
            "ssword=Qvt7144")>  _
        Public ReadOnly Property DBconnectionString() As String
            Get
                Return CType(Me("DBconnectionString"),String)
            End Get
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("BUS")>  _
        Public Property PG_ALT1_Beteckning1() As String
            Get
                Return CType(Me("PG_ALT1_Beteckning1"),String)
            End Get
            Set
                Me("PG_ALT1_Beteckning1") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property PG_ALT1_Beteckning2() As String
            Get
                Return CType(Me("PG_ALT1_Beteckning2"),String)
            End Get
            Set
                Me("PG_ALT1_Beteckning2") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property PG_ALT1_Kod() As String
            Get
                Return CType(Me("PG_ALT1_Kod"),String)
            End Get
            Set
                Me("PG_ALT1_Kod") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("940156-3")>  _
        Public Property PG_ALT1_Konto() As String
            Get
                Return CType(Me("PG_ALT1_Konto"),String)
            End Get
            Set
                Me("PG_ALT1_Konto") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("K0541")>  _
        Public Property PG_ALT1_Kundnummer() As String
            Get
                Return CType(Me("PG_ALT1_Kundnummer"),String)
            End Get
            Set
                Me("PG_ALT1_Kundnummer") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Marie")>  _
        Public Property PG_ALT1_Referens() As String
            Get
                Return CType(Me("PG_ALT1_Referens"),String)
            End Get
            Set
                Me("PG_ALT1_Referens") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property PG_ALT2_Beteckning1() As String
            Get
                Return CType(Me("PG_ALT2_Beteckning1"),String)
            End Get
            Set
                Me("PG_ALT2_Beteckning1") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property PG_ALT2_Beteckning2() As String
            Get
                Return CType(Me("PG_ALT2_Beteckning2"),String)
            End Get
            Set
                Me("PG_ALT2_Beteckning2") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property PG_ALT2_Kod() As String
            Get
                Return CType(Me("PG_ALT2_Kod"),String)
            End Get
            Set
                Me("PG_ALT2_Kod") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property PG_ALT2_Konto() As String
            Get
                Return CType(Me("PG_ALT2_Konto"),String)
            End Get
            Set
                Me("PG_ALT2_Konto") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property PG_ALT2_Kundnummer() As String
            Get
                Return CType(Me("PG_ALT2_Kundnummer"),String)
            End Get
            Set
                Me("PG_ALT2_Kundnummer") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property PG_ALT2_Referens() As String
            Get
                Return CType(Me("PG_ALT2_Referens"),String)
            End Get
            Set
                Me("PG_ALT2_Referens") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Betalning från BUS")>  _
        Public Property PG_Meddelande() As String
            Get
                Return CType(Me("PG_Meddelande"),String)
            End Get
            Set
                Me("PG_Meddelande") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Property PG_Produktionsdatum() As Date
            Get
                Return CType(Me("PG_Produktionsdatum"),Date)
            End Get
            Set
                Me("PG_Produktionsdatum") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("1")>  _
        Public Property PG_Produktionsnummer() As Integer
            Get
                Return CType(Me("PG_Produktionsnummer"),Integer)
            End Get
            Set
                Me("PG_Produktionsnummer") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("1")>  _
        Public Property PG_ALT() As Integer
            Get
                Return CType(Me("PG_ALT"),Integer)
            End Get
            Set
                Me("PG_ALT") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("56557382")>  _
        Public Property BG_ALT1_BankGiro() As String
            Get
                Return CType(Me("BG_ALT1_BankGiro"),String)
            End Get
            Set
                Me("BG_ALT1_BankGiro") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property BG_ALT2_BankGiro() As String
            Get
                Return CType(Me("BG_ALT2_BankGiro"),String)
            End Get
            Set
                Me("BG_ALT2_BankGiro") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property BG_Meddelande() As String
            Get
                Return CType(Me("BG_Meddelande"),String)
            End Get
            Set
                Me("BG_Meddelande") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property BG_Nettorubrik() As String
            Get
                Return CType(Me("BG_Nettorubrik"),String)
            End Get
            Set
                Me("BG_Nettorubrik") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Property BG_Produktionsdatum() As Date
            Get
                Return CType(Me("BG_Produktionsdatum"),Date)
            End Get
            Set
                Me("BG_Produktionsdatum") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("1")>  _
        Public Property BG_Produktionsnummer() As Integer
            Get
                Return CType(Me("BG_Produktionsnummer"),Integer)
            End Get
            Set
                Me("BG_Produktionsnummer") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property BG_Rubrik() As String
            Get
                Return CType(Me("BG_Rubrik"),String)
            End Get
            Set
                Me("BG_Rubrik") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property BG_Specifikation() As String
            Get
                Return CType(Me("BG_Specifikation"),String)
            End Get
            Set
                Me("BG_Specifikation") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("1")>  _
        Public Property BG_ALT() As Integer
            Get
                Return CType(Me("BG_ALT"),Integer)
            End Get
            Set
                Me("BG_ALT") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("bankgiro.in")>  _
        Public Property BG_File_name() As String
            Get
                Return CType(Me("BG_File_name"),String)
            End Get
            Set
                Me("BG_File_name") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("c:\")>  _
        Public Property BG_File_Folder() As String
            Get
                Return CType(Me("BG_File_Folder"),String)
            End Get
            Set
                Me("BG_File_Folder") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("plusgiro.pg")>  _
        Public Property PG_File_name() As String
            Get
                Return CType(Me("PG_File_name"),String)
            End Get
            Set
                Me("PG_File_name") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("c:\")>  _
        Public Property PG_File_folder() As String
            Get
                Return CType(Me("PG_File_folder"),String)
            End Get
            Set
                Me("PG_File_folder") = value
            End Set
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("sql.bus.local")>  _
        Public ReadOnly Property Data_source() As String
            Get
                Return CType(Me("Data_source"),String)
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("B2")>  _
        Public ReadOnly Property Initial_catalog() As String
            Get
                Return CType(Me("Initial_catalog"),String)
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("sa")>  _
        Public ReadOnly Property USER_ID() As String
            Get
                Return CType(Me("USER_ID"),String)
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Qvt7144")>  _
        Public ReadOnly Property PASSWORD() As String
            Get
                Return CType(Me("PASSWORD"),String)
            End Get
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("167696103121")>  _
        Public Property KU_UG() As String
            Get
                Return CType(Me("KU_UG"),String)
            End Get
            Set
                Me("KU_UG") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Bildkonst upphovsrätt i Sverige")>  _
        Public Property KU_Namn() As String
            Get
                Return CType(Me("KU_Namn"),String)
            End Get
            Set
                Me("KU_Namn") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Teresa Tom‚ Brejnell")>  _
        Public Property KU_Kontakt() As String
            Get
                Return CType(Me("KU_Kontakt"),String)
            End Get
            Set
                Me("KU_Kontakt") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Hornsgatan 103")>  _
        Public Property KU_Adress() As String
            Get
                Return CType(Me("KU_Adress"),String)
            End Get
            Set
                Me("KU_Adress") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("11728")>  _
        Public Property KU_PostNR() As String
            Get
                Return CType(Me("KU_PostNR"),String)
            End Get
            Set
                Me("KU_PostNR") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("STOCKHOLM")>  _
        Public Property KU_PostOrt() As String
            Get
                Return CType(Me("KU_PostOrt"),String)
            End Get
            Set
                Me("KU_PostOrt") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("08-545523383")>  _
        Public Property KU_Telefon() As String
            Get
                Return CType(Me("KU_Telefon"),String)
            End Get
            Set
                Me("KU_Telefon") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("08-54553398")>  _
        Public Property KU_Fax() As String
            Get
                Return CType(Me("KU_Fax"),String)
            End Get
            Set
                Me("KU_Fax") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("teresa.tome.brejnell@bildupphovsratt.se")>  _
        Public Property KU_Email() As String
            Get
                Return CType(Me("KU_Email"),String)
            End Get
            Set
                Me("KU_Email") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("C:\")>  _
        Public Property EXCEL_Dir() As String
            Get
                Return CType(Me("EXCEL_Dir"),String)
            End Get
            Set
                Me("EXCEL_Dir") = value
            End Set
        End Property
    End Class
End Namespace

Namespace My
    
    <Global.Microsoft.VisualBasic.HideModuleNameAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute()>  _
    Friend Module MySettingsProperty
        
        <Global.System.ComponentModel.Design.HelpKeywordAttribute("My.Settings")>  _
        Friend ReadOnly Property Settings() As Global.B2.My.MySettings
            Get
                Return Global.B2.My.MySettings.Default
            End Get
        End Property
    End Module
End Namespace
