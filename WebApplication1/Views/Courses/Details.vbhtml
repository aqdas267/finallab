@ModelType WebApplication1.WebApplication1.Course
@Code
    ViewData("Title") = "Details"
End Code

<h2>Details</h2>

<div>
    <h4>Course</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.CourseCode)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.CourseCode)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.CourseName)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.CourseName)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.CreditHours)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.CreditHours)
        </dd>

    </dl>
</div>
<p>
    @Html.ActionLink("Edit", "Edit", New With { .id = Model.CourseId }) |
    @Html.ActionLink("Back to List", "Index")
</p>
