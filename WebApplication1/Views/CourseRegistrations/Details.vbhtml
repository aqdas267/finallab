@ModelType WebApplication1.WebApplication1.CourseRegistration
@Code
    ViewData("Title") = "Details"
End Code

<h2>Details</h2>

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
</div>
<p>
    @Html.ActionLink("Edit", "Edit", New With { .id = Model.CourseRegistrationId }) |
    @Html.ActionLink("Back to List", "Index")
</p>
