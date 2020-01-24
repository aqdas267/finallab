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
    'builder.EntitySet(Of CourseRegistration)("CourseRegistrations")
    'config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel())

    Public Class CourseRegistrationsController
        Inherits ODataController

        Private db As New Database1Entities

        ' GET: odata/CourseRegistrations
        <EnableQuery>
        Function GetCourseRegistrations() As IQueryable(Of CourseRegistration)
            Return db.CourseRegistrations
        End Function

        ' GET: odata/CourseRegistrations(5)
        <EnableQuery>
        Function GetCourseRegistration(<FromODataUri> key As Integer) As SingleResult(Of CourseRegistration)
            Return SingleResult.Create(db.CourseRegistrations.Where(Function(courseRegistration) courseRegistration.CourseRegistrationId = key))
        End Function

        ' PUT: odata/CourseRegistrations(5)
        Function Put(<FromODataUri> ByVal key As Integer, ByVal patchValue As Delta(Of CourseRegistration)) As IHttpActionResult
            Validate(patchValue.GetEntity())

            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If

            Dim courseRegistration As CourseRegistration = db.CourseRegistrations.Find(key)
            If IsNothing(courseRegistration) Then
                Return NotFound()
            End If

            patchValue.Put(courseRegistration)

            Try
                db.SaveChanges()
            Catch ex As DbUpdateConcurrencyException
                If Not (CourseRegistrationExists(key)) Then
                    Return NotFound()
                Else
                    Throw
                End If
            End Try

            Return Updated(courseRegistration)
        End Function

        ' POST: odata/CourseRegistrations
        Function Post(ByVal courseRegistration As CourseRegistration) As IHttpActionResult
            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If
                            
            db.CourseRegistrations.Add(courseRegistration)
            db.SaveChanges()

            Return Created(courseRegistration)
        End Function

        ' PATCH: odata/CourseRegistrations(5)
        <AcceptVerbs("PATCH", "MERGE")>
        Function Patch(<FromODataUri> ByVal key As Integer, ByVal patchValue As Delta(Of CourseRegistration)) As IHttpActionResult
            Validate(patchValue.GetEntity())

            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If

            Dim courseRegistration As CourseRegistration = db.CourseRegistrations.Find(key)
            If IsNothing(courseRegistration) Then
                Return NotFound()
            End If

            patchValue.Patch(courseRegistration)

            Try
                db.SaveChanges()
            Catch ex As DbUpdateConcurrencyException
                If Not (CourseRegistrationExists(key)) Then
                    Return NotFound()
                Else
                    Throw
                End If
            End Try

            Return Updated(courseRegistration)
        End Function

        ' DELETE: odata/CourseRegistrations(5)
        Function Delete(<FromODataUri> ByVal key As Integer) As IHttpActionResult
            Dim courseRegistration As CourseRegistration = db.CourseRegistrations.Find(key)
            If IsNothing(courseRegistration) Then
                Return NotFound()
            End If

            db.CourseRegistrations.Remove(courseRegistration)
            db.SaveChanges()

            Return StatusCode(HttpStatusCode.NoContent)
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        Private Function CourseRegistrationExists(ByVal key As Integer) As Boolean
            Return db.CourseRegistrations.Count(Function(e) e.CourseRegistrationId = key) > 0
        End Function
    End Class
End Namespace
