Imports Microsoft.VisualBasic
Imports System.DirectoryServices
Imports System.Data



Public Class LDAPMembershipProvider
        Inherits System.Web.Security.MembershipProvider

        Private _applicationName As String
        Private _providerName As String

        Public Overrides Property ApplicationName() As String
            Get
                Return _applicationName
            End Get
            Set(ByVal value As String)
                _applicationName = value
            End Set
        End Property

        Public Overrides Sub Initialize(ByVal name As String, ByVal config As System.Collections.Specialized.NameValueCollection)
            ' Initialize values from web.config.
            If config Is Nothing Then Throw _
                New ArgumentNullException("config")

            If name Is Nothing OrElse name.Length = 0 Then _
                name = "LDAPProfileProvider"

            If String.IsNullOrEmpty(config("description")) Then
                config.Remove("description")
                config.Add("description", "LDAP Membership provider")
            End If

            ' Initialize the abstract base class.
            MyBase.Initialize(name, config)

            'If config("applicationName") Is Nothing OrElse config("applicationName").Trim() = "" Then
            '    _applicationName = System.Web.Hosting.HostingEnvironment.ApplicationVirtualPath
            'Else
            '    _applicationName = config("applicationName")
            'End If
            _applicationName = config("applicationName")
            _providerName = name
        End Sub

        Public Overrides Function ChangePassword(ByVal username As String, ByVal oldPassword As String, ByVal newPassword As String) As Boolean
            Try
                Dim trsql As New TransacSQL
                Dim n As Integer = trsql.EjecutarConsulta("aspnetdb3", "select count(*) from aspnet_Users u, aspnet_Membership m, aspnet_Applications a " + _
                                                                            "where u.UserId = m.UserId and u.ApplicationId = a.ApplicationId and u.UserName = @UserName " + _
                                                                            "and m.Password = @Password and a.ApplicationName = @AppName", New Object() { _
                                                                            New Object() {"@UserName", username}, _
                                                                            New Object() {"@Password", oldPassword}, _
                                                                            New Object() {"@AppName", _applicationName} _
                                                                            }).Tables(0).Rows(0)(0)
                If n = 1 Then
                    trsql.EjecutarConsulta("aspnetdb3", "update m set Password = @Password from aspnet_Users u, aspnet_Membership m " + _
                                                        "where u.UserId = m.UserId and u.UserName = @UserName", New Object() { _
                                                        New Object() {"@UserName", username}, _
                                                        New Object() {"@Password", newPassword} _
                                                        })
                    Return True
                End If
            Catch ex As Exception
            End Try
            Return False
        End Function

        Public Overrides Function ChangePasswordQuestionAndAnswer(ByVal username As String, ByVal password As String, ByVal newPasswordQuestion As String, ByVal newPasswordAnswer As String) As Boolean

        End Function

        Public Overrides Function CreateUser(ByVal username As String, ByVal password As String, ByVal email As String, ByVal passwordQuestion As String, ByVal passwordAnswer As String, ByVal isApproved As Boolean, ByVal providerUserKey As Object, ByRef status As System.Web.Security.MembershipCreateStatus) As System.Web.Security.MembershipUser

        End Function

        Public Overrides Function DeleteUser(ByVal username As String, ByVal deleteAllRelatedData As Boolean) As Boolean

        End Function

        Public Overrides ReadOnly Property EnablePasswordReset() As Boolean
            Get

            End Get
        End Property

        Public Overrides ReadOnly Property EnablePasswordRetrieval() As Boolean
            Get

            End Get
        End Property

        Public Overrides Function FindUsersByEmail(ByVal emailToMatch As String, ByVal pageIndex As Integer, ByVal pageSize As Integer, ByRef totalRecords As Integer) As System.Web.Security.MembershipUserCollection

        End Function

        Public Overrides Function FindUsersByName(ByVal usernameToMatch As String, ByVal pageIndex As Integer, ByVal pageSize As Integer, ByRef totalRecords As Integer) As System.Web.Security.MembershipUserCollection

        End Function

        Public Overrides Function GetAllUsers(ByVal pageIndex As Integer, ByVal pageSize As Integer, ByRef totalRecords As Integer) As System.Web.Security.MembershipUserCollection

        End Function

        Public Overrides Function GetNumberOfUsersOnline() As Integer

        End Function

        Public Overrides Function GetPassword(ByVal username As String, ByVal answer As String) As String

        End Function

        Public Overloads Overrides Function GetUser(ByVal providerUserKey As Object, ByVal userIsOnline As Boolean) As System.Web.Security.MembershipUser
            Dim trsql As New TransacSQL
            Dim dt As DataTable = trsql.EjecutarConsulta("aspnetdb3", "select m.*, u.UserName, u.LastActivityDate from aspnet_Membership m, aspnet_Users u, aspnet_Applications a " + _
                                                                        "where m.UserId = u.UserId and a.ApplicationId = u.ApplicationId " + _
                                                                        "and a.ApplicationName = @AppName and m.UserId = @UserId", New Object() { _
                                                                        New Object() {"@AppName", _applicationName}, _
                                                                        New Object() {"@UserId", providerUserKey} _
                                                                        }).Tables(0)
            If dt.Rows.Count > 0 Then
                Dim r As DataRow = dt.Rows(0)
                Return New System.Web.Security.MembershipUser(_providerName, r("UserName"), r("UserId"), r("Email"), r("PasswordQuestion"), r("Comment").ToString, _
                                                              r("IsApproved"), r("IsLockedOut"), r("CreateDate"), r("LastLoginDate"), r("LastActivityDate"), _
                                                              r("LastPasswordChangedDate"), r("LastLockoutDate"))
            End If
            Return Nothing
        End Function

        Public Overloads Overrides Function GetUser(ByVal username As String, ByVal userIsOnline As Boolean) As System.Web.Security.MembershipUser
            Dim trsql As New TransacSQL
            Dim dt As DataTable = trsql.EjecutarConsulta("aspnetdb3", "select m.*, u.LastActivityDate from aspnet_Membership m, aspnet_Users u, aspnet_Applications a " + _
                                                                        "where m.UserId = u.UserId and a.ApplicationId = u.ApplicationId " + _
                                                                        "and a.ApplicationName = @AppName and u.UserName = @UserName", New Object() { _
                                                                        New Object() {"@AppName", _applicationName}, _
                                                                        New Object() {"@UserName", username} _
                                                                        }).Tables(0)
            If dt.Rows.Count > 0 Then
                Dim r As DataRow = dt.Rows(0)
                Return New System.Web.Security.MembershipUser(_providerName, username, r("UserId"), r("Email"), r("PasswordQuestion"), r("Comment").ToString, _
                                                              r("IsApproved"), r("IsLockedOut"), r("CreateDate"), r("LastLoginDate"), r("LastActivityDate"), _
                                                              r("LastPasswordChangedDate"), r("LastLockoutDate"))
            End If
            Return Nothing
        End Function

        Public Overrides Function GetUserNameByEmail(ByVal email As String) As String
            Dim trsql As New TransacSQL
            Dim dt As DataTable = trsql.EjecutarConsulta("aspnetdb3", "select u.UserName from aspnet_Membership m, aspnet_Users u, aspnet_Applications a " + _
                                                                        "where m.UserId = u.UserId and a.ApplicationId = u.ApplicationId " + _
                                                                        "and a.ApplicationName = @AppName and m.Email = @email", New Object() { _
                                                                        New Object() {"@AppName", _applicationName}, _
                                                                        New Object() {"@email", email} _
                                                                        }).Tables(0)
            If dt.Rows.Count > 0 Then
                Dim r As DataRow = dt.Rows(0)
                Return r("UserName")
            End If
            Return Nothing
        End Function

        Public Overrides ReadOnly Property MaxInvalidPasswordAttempts() As Integer
            Get

            End Get
        End Property

        Public Overrides ReadOnly Property MinRequiredNonAlphanumericCharacters() As Integer
            Get

            End Get
        End Property

        Public Overrides ReadOnly Property MinRequiredPasswordLength() As Integer
            Get

            End Get
        End Property

        Public Overrides ReadOnly Property PasswordAttemptWindow() As Integer
            Get

            End Get
        End Property

        Public Overrides ReadOnly Property PasswordFormat() As System.Web.Security.MembershipPasswordFormat
            Get

            End Get
        End Property

        Public Overrides ReadOnly Property PasswordStrengthRegularExpression() As String
            Get

            End Get
        End Property

        Public Overrides ReadOnly Property RequiresQuestionAndAnswer() As Boolean
            Get

            End Get
        End Property

        Public Overrides ReadOnly Property RequiresUniqueEmail() As Boolean
            Get

            End Get
        End Property

        Public Overrides Function ResetPassword(ByVal username As String, ByVal answer As String) As String

        End Function

        Public Overrides Function UnlockUser(ByVal userName As String) As Boolean

        End Function

        Public Overrides Sub UpdateUser(ByVal user As System.Web.Security.MembershipUser)
            Dim trsql As New TransacSQL
            trsql.EjecutarActualizacion("aspnetdb3", "aspnet_Membership_UpdateUser", New Object() { _
                                                        New Object() {"@ApplicationName", _applicationName}, _
                                                        New Object() {"@UserName", user.UserName}, _
                                                        New Object() {"@Email", user.Email}, _
                                                        New Object() {"@Comment", user.Comment}, _
                                                        New Object() {"@IsApproved", user.IsApproved}, _
                                                        New Object() {"@LastLoginDate", user.LastLoginDate}, _
                                                        New Object() {"@LastActivityDate", user.LastActivityDate}, _
                                                        New Object() {"@UniqueEmail", True}, _
                                                        New Object() {"@CurrentTimeUtc", Now} _
                                                        }, CommandType.StoredProcedure)
        End Sub

        Private Function ValidaPorAspnetdb(ByVal username As String, ByVal pwd As String) As Boolean
            Dim trsql As New TransacSQL
            Return trsql.EjecutarConsulta("aspnetdb3", "select count(*) from aspnet_Users u, aspnet_Membership m, aspnet_Applications a " + _
                                                        "where u.UserId = m.UserId And u.ApplicationId = a.ApplicationId and m.IsLockedOut = 0 " + _
                                                        "and a.ApplicationName = @AppName and u.UserName = @UserName and m.Password = @Password", New Object() { _
                                                    New Object() {"@AppName", ApplicationName}, _
                                                    New Object() {"@UserName", username}, _
                                                    New Object() {"@Password", pwd} _
                                                    }).Tables(0).Rows(0)(0) > 0
        End Function

        Public Overrides Function ValidateUser(ByVal username As String, ByVal pwd As String) As Boolean
            'Dim _path As String = "LDAP://DC=FOGEL-GROUP,DC=COM"
            'Dim domainAndUsername As String = "FOGEL-GROUP.COM\" & username
            'Dim entry As DirectoryEntry = New DirectoryEntry(_path, domainAndUsername, pwd)

            'Try
            '    'Bind to the native AdsObject to force authentication.			
            '    Dim obj As Object = entry.NativeObject
            '    Dim search As DirectorySearcher = New DirectorySearcher(entry)

            '    search.Filter = "(SAMAccountName=" & username & ")"
            '    search.PropertiesToLoad.Add("cn")
            '    Dim result As SearchResult = search.FindOne()

            '    If Not result Is Nothing Then
            '        Return True
            '    End If
            'Catch ex As Exception
            'End Try
            ''Return False
            Return ValidaPorAspnetdb(username, pwd)
        End Function

    End Class


