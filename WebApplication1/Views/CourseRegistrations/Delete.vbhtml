@ModelType WebApplication1.WebApplication1.CourseRegistration
@Code
    ViewData("Title") = "Delete"
End Code

<h2>Delete</h2>

<h3>Are you sure you want to delete this?</h3>
<div>
    <h4>CourseRegistration</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.CourseId)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.CourseId)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.StudentId)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.StudentId)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.RegistrationTime)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.RegistrationTime)
        </dd>

    </dl>
    @Using (Html.BeginForm())
        @Html.AntiForgeryToken()

        @<div class="form-actions no-color">
            <input type="submit" value="Delete" class="btn btn-default" /> |
            @Html.ActionLink("Back to List", "Index")
        </div>
    End Using
</div>
