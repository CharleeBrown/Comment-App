Imports MongoDB.Driver
Imports System
Imports MongoDB.Bson
Imports System.Runtime

Public Class Form1


    Private Sub SaveBtn_Click(sender As Object, e As EventArgs) Handles SaveBtn.Click
        ' Database connection settings
        Dim settings As MongoClientSettings
        settings = MongoClientSettings.FromConnectionString("mongodb+srv://lee:" + Environment.GetEnvironmentVariable("pwd").ToString() + "@cluster0.guc9f.mongodb.net/?retryWrites=true&w=majority")
        settings.ServerApi = New ServerApi(ServerApiVersion.V1)
        'Client to handle the entering of data
        Dim client = New MongoClient(settings)

        'variable for database
        Dim database = client.GetDatabase("CommentDB")
        'variable for collection
        Dim coll = database.GetCollection(Of BsonDocument)("comments01")

        'Try statement to enter data into the database
        Try
            'Document properties
            Dim BsonProps = New BsonDocument()
            With BsonProps
                'DateTime of comment
                .Add("date_entered", DateTime.Now)
                'Name of commmentor
                .Add("name", NameBox.Text)
                'Body of comment
                .Add("comment", CommentBox.Text)
            End With

            'Insert the document into the databas
            coll.InsertOne(BsonProps)

        Catch ex As Exception
            'Catch for possible errors
            MessageBox.Show(ex.Message)

        Finally
            'Alerting the user for completion of the task
            MessageBox.Show("Comment Saved!", "Comment App")
            'Clearing the inputs
            NameBox.Clear()
            CommentBox.Clear()

        End Try

        'Setting the focus to the name input
        NameBox.Select()
    End Sub
End Class
