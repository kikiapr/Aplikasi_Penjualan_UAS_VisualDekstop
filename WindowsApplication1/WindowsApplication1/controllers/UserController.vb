Imports MySql.Data.MySqlClient

Public Class UserController

    Public Function GetNewUserId() As Integer
        Dim newId As Integer = 1

        Dim sql As String = "SELECT IFNULL(MAX(id),0) + 1 FROM users"

        Using conn = OpenConnection()
            Using cmd As New MySqlCommand(sql, conn)
                newId = Convert.ToInt32(cmd.ExecuteScalar())
            End Using
        End Using

        Return newId
    End Function


    Public Function GetAll() As DataTable
        Dim dt As New DataTable()
        Dim sql As String = "SELECT id, username, role FROM users ORDER BY id DESC"

        Using conn = OpenConnection()
            Using da As New MySqlDataAdapter(sql, conn)
                da.Fill(dt)
            End Using
        End Using

        Return dt
    End Function

    Public Function GetKasir() As DataTable
        Dim dt As New DataTable()
        Dim sql As String = "SELECT id, username, role FROM users WHERE role='kasir' ORDER BY id DESC"

        Using conn = OpenConnection()
            Using da As New MySqlDataAdapter(sql, conn)
                da.Fill(dt)
            End Using
        End Using

        Return dt
    End Function

    Public Function Insert(m As UserModel) As Boolean
        Dim sql As String = "INSERT INTO users (username, fullname, password, role) VALUES (@u,@f,@p,@r)"
        Using conn = OpenConnection()
            Using cmd As New MySqlCommand(sql, conn)
                cmd.Parameters.AddWithValue("@u", m.username)
                cmd.Parameters.AddWithValue("@p", m.password)
                cmd.Parameters.AddWithValue("@r", m.role)
                Return cmd.ExecuteNonQuery() > 0
            End Using
        End Using
    End Function

    Public Function Update(m As UserModel, changePassword As Boolean) As Boolean
        Dim sql As String
        If changePassword Then
            sql = "UPDATE users SET username=@u, password=@p, role=@r WHERE id=@id"
        Else
            sql = "UPDATE users SET username=@u, role=@r WHERE id=@id"
        End If

        Using conn = OpenConnection()
            Using cmd As New MySqlCommand(sql, conn)
                cmd.Parameters.AddWithValue("@u", m.username)
                cmd.Parameters.AddWithValue("@r", m.role)
                cmd.Parameters.AddWithValue("@id", m.id)

                If changePassword Then
                    cmd.Parameters.AddWithValue("@p", m.password)
                End If

                Return cmd.ExecuteNonQuery() > 0
            End Using
        End Using
    End Function

    Public Function Delete(id As Integer) As Boolean
        Dim sql As String = "DELETE FROM users WHERE id=@id"
        Using conn = OpenConnection()
            Using cmd As New MySqlCommand(sql, conn)
                cmd.Parameters.AddWithValue("@id", id)
                Return cmd.ExecuteNonQuery() > 0
            End Using
        End Using
    End Function

End Class
