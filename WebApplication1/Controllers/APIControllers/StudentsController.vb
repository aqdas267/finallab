Imports System.Data
Imports System.Data.Entity
Imports System.Data.Entity.Infrastructure
Imports System.Linq
Imports System.Net
Imports System.Net.Http
Imports System.Web.Http
Imports System.Web.Http.Description
Imports WebApplication1.WebApplication1

Namespace Controllers.APIControllers
    Public Class StudentsController
        Inherits System.Web.Http.ApiController

        Private db As New Database1Entities

        ' GET: api/Students
        Function GetStudents() As IQueryable(Of Student)
            Return db.Students
        End Function

        ' GET: api/Students/5
        <ResponseType(GetType(Student))>
        Function GetStudent(ByVal id As Integer) As IHttpActionResult
            Dim student As Student = db.Students.Find(id)
            If IsNothing(student) Then
                Return NotFound()
            End If

            Return Ok(student)
        End Function

        ' PUT: api/Students/5
        <ResponseType(GetType(Void))>
        Function PutStudent(ByVal id As Integer, ByVal student As Student) As IHttpActionResult
            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If

            If Not id = student.StudentId Then
                Return BadRequest()
            End If

            db.Entry(student).State = EntityState.Modified

            Try
                db.SaveChanges()
            Catch ex As DbUpdateConcurrencyException
                If Not (StudentExists(id)) Then
                    Return NotFound()
                Else
                    Throw
                End If
            End Try

            Return StatusCode(HttpStatusCode.NoContent)
        End Function

        ' POST: api/Students
        <ResponseType(GetType(Student))>
        Function PostStudent(ByVal student As Student) As IHttpActionResult
            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If

            db.Students.Add(student)
            db.SaveChanges()

            Return CreatedAtRoute("DefaultApi", New With {.id = student.StudentId}, student)
        End Function

        ' DELETE: api/Students/5
        <ResponseType(GetType(Student))>
        Function DeleteStudent(ByVal id As Integer) As IHttpActionResult
            Dim student As Student = db.Students.Find(id)
            If IsNothing(student) Then
                Return NotFound()
            End If

            db.Students.Remove(student)
            db.SaveChanges()

            Return Ok(student)
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        Private Function StudentExists(ByVal id As Integer) As Boolean
            Return db.Students.Count(Function(e) e.StudentId = id) > 0
        End Function
    End Class
End Namespace