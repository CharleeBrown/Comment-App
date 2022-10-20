Imports MongoDB.Driver
Imports System
Imports MongoDB.Bson
Imports System.Runtime

Public Class Form1


    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles NameBox.TextChanged

    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles CommentBox.TextChanged

    End Sub

    Private Sub SaveBtn_Click(sender As Object, e As EventArgs) Handles SaveBtn.Click

        Dim settings As MongoClientSettings
        settings = MongoClientSettings.FromConnectionString("mongodb+srv://lee:" + Environment.GetEnvironmentVariable("pwd").ToString() + "@cluster0.guc9f.mongodb.net/?retryWrites=true&w=majority")
        settings.ServerApi = New ServerApi(ServerApiVersion.V1)
        Dim client = New MongoClient(settings)
        Dim database = client.GetDatabase("CommentDB")
        Dim coll = database.GetCollection(Of BsonDocument)("comments01")
        Try
            Dim BsonProps = New BsonDocument().Add("name", NameBox.Text).Add("comment", CommentBox.Text)
            coll.InsertOne(BsonProps)

        Catch ex As Exception
            MessageBox.Show(ex.Message)

        Finally
            MessageBox.Show("Comment Saved!")
            NameBox.Clear()
            CommentBox.Clear()
        End Try

    End Sub
End Class
