Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Entity
Imports System.Linq
Imports System.Net
Imports System.Web
Imports System.Web.Mvc
Imports WebApplication1.WebApplication1

Namespace Controllers
    Public Class CourseRegistrationsController
        Inherits System.Web.Mvc.Controller

        Private db As New Database1Entities

        ' GET: CourseRegistrations
        Function Index() As ActionResult
            Return View(db.CourseRegistrations.ToList())
        End Function

        ' GET: CourseRegistrations/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim courseRegistration As CourseRegistration = db.CourseRegistrations.Find(id)
            If IsNothing(courseRegistration) Then
                Return HttpNotFound()
            End If
            Return View(courseRegistration)
        End Function

        ' GET: CourseRegistrations/Create
        Function Create() As ActionResult
            Return View()
        End Function

        ' POST: CourseRegistrations/Create
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="CourseRegistrationId,CourseId,StudentId,RegistrationTime")> ByVal courseRegistration As CourseRegistration) As ActionResult
            If ModelState.IsValid Then
                db.CourseRegistrations.Add(courseRegistration)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(courseRegistration)
        End Function

        ' GET: CourseRegistrations/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim courseRegistration As CourseRegistration = db.CourseRegistrations.Find(id)
            If IsNothing(courseRegistration) Then
                Return HttpNotFound()
            End If
            Return View(courseRegistration)
        End Function

        ' POST: CourseRegistrations/Edit/5
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="CourseRegistrationId,CourseId,StudentId,RegistrationTime")> ByVal courseRegistration As CourseRegistration) As ActionResult
            If ModelState.IsValid Then
                db.Entry(courseRegistration).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(courseRegistration)
        End Function

        ' GET: CourseRegistrations/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim courseRegistration As CourseRegistration = db.CourseRegistrations.Find(id)
            If IsNothing(courseRegistration) Then
                Return HttpNotFound()
            End If
            Return View(courseRegistration)
        End Function

        ' POST: CourseRegistrations/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim courseRegistration As CourseRegistration = db.CourseRegistrations.Find(id)
            db.CourseRegistrations.Remove(courseRegistration)
            db.SaveChanges()
            Return RedirectToAction("Index")
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub
    End Class
End Namespace
