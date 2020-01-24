@ModelType WebApplication1.WebApplication1.Student
@Code
    ViewData("Title") = "Details"
End Code

<h2>Details</h2>

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
</div>
<p>
    @Html.ActionLink("Edit", "Edit", New With { .id = Model.StudentId }) |
    @Html.ActionLink("Back to List", "Index")
</p>
