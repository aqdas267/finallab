Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Entity
Imports System.Data.Entity.Infrastructure
Imports System.Linq
Imports System.Net
Imports System.Net.Http
Imports System.Web.Http
Imports System.Web.Http.ModelBinding
Imports System.Web.Http.OData
Imports System.Web.Http.OData.Routing
Imports WebApplication1.WebApplication1

Namespace Controllers.APIControllers

    'The WebApiConfig class may require additional changes to add a route for this controller. Merge these statements into the Register method of the WebApiConfig class as applicable. Note that OData URLs are case sensitive.

    'Imports System.Web.Http.OData.Builder
    'Imports System.Web.Http.OData.Extensions
    'Imports WebApplication1.WebApplication1
    'Dim builder As New ODataConventionModelBuilder
    'builder.EntitySet(Of Course)("Courses")
    'config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel())

    Public Class CoursesController
        Inherits ODataController

        Private db As New Database1Entities

        ' GET: odata/Courses
        <EnableQuery>
        Function GetCourses() As IQueryable(Of Course)
            Return db.Courses
        End Function

        ' GET: odata/Courses(5)
        <EnableQuery>
        Function GetCourse(<FromODataUri> key As Integer) As SingleResult(Of Course)
            Return SingleResult.Create(db.Courses.Where(Function(course) course.CourseId = key))
        End Function

        ' PUT: odata/Courses(5)
        Function Put(<FromODataUri> ByVal key As Integer, ByVal patchValue As Delta(Of Course)) As IHttpActionResult
            Validate(patchValue.GetEntity())

            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If

            Dim course As Course = db.Courses.Find(key)
            If IsNothing(course) Then
                Return NotFound()
            End If

            patchValue.Put(course)

            Try
                db.SaveChanges()
            Catch ex As DbUpdateConcurrencyException
                If Not (CourseExists(key)) Then
                    Return NotFound()
                Else
                    Throw
                End If
            End Try

            Return Updated(course)
        End Function

        ' POST: odata/Courses
        Function Post(ByVal course As Course) As IHttpActionResult
            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If
                            
            db.Courses.Add(course)
            db.SaveChanges()

            Return Created(course)
        End Function

        ' PATCH: odata/Courses(5)
        <AcceptVerbs("PATCH", "MERGE")>
        Function Patch(<FromODataUri> ByVal key As Integer, ByVal patchValue As Delta(Of Course)) As IHttpActionResult
            Validate(patchValue.GetEntity())

            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If

            Dim course As Course = db.Courses.Find(key)
            If IsNothing(course) Then
                Return NotFound()
            End If

            patchValue.Patch(course)

            Try
                db.SaveChanges()
            Catch ex As DbUpdateConcurrencyException
                If Not (CourseExists(key)) Then
                    Return NotFound()
                Else
                    Throw
                End If
            End Try

            Return Updated(course)
        End Function

        ' DELETE: odata/Courses(5)
        Function Delete(<FromODataUri> ByVal key As Integer) As IHttpActionResult
            Dim course As Course = db.Courses.Find(key)
            If IsNothing(course) Then
                Return NotFound()
            End If

            db.Courses.Remove(course)
            db.SaveChanges()

            Return StatusCode(HttpStatusCode.NoContent)
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        Private Function CourseExists(ByVal key As Integer) As Boolean
            Return db.Courses.Count(Function(e) e.CourseId = key) > 0
        End Function
    End Class
End Namespace
