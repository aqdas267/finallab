@ModelType WebApplication1.WebApplication1.Student
@Code
    ViewData("Title") = "Delete"
End Code

<h2>Delete</h2>

<h3>Are you sure you want to delete this?</h3>
<div>
    <h4>Student</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.StudentName)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.StudentName)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.StudentRegNo)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.StudentRegNo)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.StudentSemester)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.StudentSemester)
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
